﻿using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.ToolBase;
using Dev2.Common.Interfaces.ToolBase.DotNet;
using Dev2.Studio.Core.Activities.Utils;
using Warewolf.Core;

namespace Dev2.Activities.Designers2.Core.ConstructorRegion
{
    public class DotNetConstructorRegion : IConstructorRegion<IPluginConstructor>
    {
        private readonly ModelItem _modelItem;
        private readonly ISourceToolRegion<IPluginSource> _source;
        private readonly INamespaceToolRegion<INamespaceItem> _namespace;
        private bool _isEnabled;

        readonly Dictionary<string, IList<IToolRegion>> _previousRegions = new Dictionary<string, IList<IToolRegion>>();
        private Action _sourceChangedAction;
        private IPluginConstructor _selectedConstructor;
        private IPluginServiceModel _model;
        private ICollection<IPluginConstructor> _constructors;
        private bool _isConstructorEnabled;
        private bool _isRefreshing;
        private double _labelWidth;
        private IList<string> _errors;

        public DotNetConstructorRegion()
        {
            ToolRegionName = "DotNetConstructorRegion";
        }

        public DotNetConstructorRegion(IPluginServiceModel model, ModelItem modelItem,
            ISourceToolRegion<IPluginSource> source, INamespaceToolRegion<INamespaceItem> namespaceItem)
        {
            try
            {
                Errors = new List<string>();

                LabelWidth = 70;
                ToolRegionName = "DotNetConstructorRegion";
                _modelItem = modelItem;
                _model = model;
                _source = source;
                _namespace = namespaceItem;
                _namespace.SomethingChanged += SourceOnSomethingChanged;
                Dependants = new List<IToolRegion>();
                IsRefreshing = false;
                if (_source.SelectedSource != null)
                {
                    Constructors = model.GetConstructors(_source.SelectedSource, _namespace.SelectedNamespace);
                }
                if (Method != null && Constructors != null)
                {
                    IsConstructorEnabled = _source.SelectedSource != null && _namespace.SelectedNamespace != null;
                    SelectedConstructor = Constructors.FirstOrDefault(constructor => constructor.ConstructorName == Method.ConstructorName);
                }
                RefreshConstructorsCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(() =>
                {
                    IsRefreshing = true;
                    if (_source.SelectedSource != null)
                    {
                        Constructors = model.GetConstructors(_source.SelectedSource, _namespace.SelectedNamespace);
                    }
                    IsRefreshing = false;
                }, CanRefresh);

                IsEnabled = true;
                _modelItem = modelItem;
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }
        }

        IPluginConstructor Method
        {
            get
            {
                return _modelItem.GetProperty<IPluginConstructor>("Constructor");
            }
            set
            {
                _modelItem.SetProperty("Constructor", value);
            }
        }

        public double LabelWidth
        {
            get
            {
                return _labelWidth;
            }
            set
            {
                _labelWidth = value;
                OnPropertyChanged();
            }
        }

        private void SourceOnSomethingChanged(object sender, IToolRegion args)
        {
            try
            {
                Errors.Clear();
                IsRefreshing = true;
                // ReSharper disable once ExplicitCallerInfoArgument
                UpdateBasedOnNamespace();
                IsRefreshing = false;
                // ReSharper disable once ExplicitCallerInfoArgument
                OnPropertyChanged(@"IsEnabled");
            }
            catch (Exception e)
            {
                IsRefreshing = false;
                Errors.Add(e.Message);
            }
            finally
            {
                OnSomethingChanged(this);
                CallErrorsEventHandler();
            }
        }

        private void CallErrorsEventHandler()
        {
            ErrorsHandler?.Invoke(this, new List<string>(Errors));
        }

        private void UpdateBasedOnNamespace()
        {
            if (_source?.SelectedSource != null)
            {
                Constructors = _model.GetConstructors(_source.SelectedSource, _namespace.SelectedNamespace);
                SelectedConstructor = null;
                IsConstructorEnabled = true;
                IsEnabled = true;
            }
        }

        public bool CanRefresh()
        {
            IsConstructorEnabled = _source.SelectedSource != null && _namespace.SelectedNamespace != null;
            return _source.SelectedSource != null;
        }

        public IPluginConstructor SelectedConstructor
        {
            get
            {
                return _selectedConstructor;
            }
            set
            {
                if (!Equals(value, _selectedConstructor) && _selectedConstructor != null)
                {
                    if (!string.IsNullOrEmpty(_selectedConstructor.ConstructorName))
                        StorePreviousValues(_selectedConstructor.GetIdentifier());
                }
                if (Dependants != null)
                {
                    var outputs = Dependants.FirstOrDefault(a => a is IOutputsToolRegion);
                    var region = outputs as OutputsRegion;
                    if (region != null)
                    {
                        region.Outputs = new ObservableCollection<IServiceOutputMapping>();
                        region.RecordsetName = string.Empty;
                        region.ObjectResult = string.Empty;
                        region.IsObject = false;
                        region.ObjectName = string.Empty;
                    }
                }
                RestoreIfPrevious(value);
                OnPropertyChanged();
            }
        }

        private void RestoreIfPrevious(IPluginConstructor value)
        {
            if (IsAPreviousValue(value) && _selectedConstructor != null)
            {
                RestorePreviousValues(value);
                SetSelectedConstructor(value);
            }
            else
            {
                SetSelectedConstructor(value);
                SourceChangedAction();
                OnSomethingChanged(this);
            }
            var delegateCommand = RefreshConstructorsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand;
            delegateCommand?.RaiseCanExecuteChanged();

            _selectedConstructor = value;
        }

        public ICollection<IPluginConstructor> Constructors
        {
            get
            {
                return _constructors;
            }
            set
            {
                _constructors = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshConstructorsCommand { get; set; }

        public bool IsConstructorEnabled
        {
            get
            {
                return _isConstructorEnabled;
            }
            set
            {
                _isConstructorEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public Action SourceChangedAction
        {
            get
            {
                return _sourceChangedAction ?? (() => { });
            }
            set
            {
                _sourceChangedAction = value;
            }
        }
        public event SomethingChanged SomethingChanged;

        #region Implementation of IToolRegion

        public string ToolRegionName { get; set; }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
        public IList<IToolRegion> Dependants { get; set; }

        public IToolRegion CloneRegion()
        {
            return new DotNetConstructorRegion
            {
                IsEnabled = IsEnabled,
                SelectedConstructor = SelectedConstructor == null ? null : new PluginConstructor
                {
                    Inputs = SelectedConstructor.Inputs,
                    ConstructorName = SelectedConstructor.ConstructorName,
                    ReturnObject = SelectedConstructor.ReturnObject
                }
            };
        }

        public void RestoreRegion(IToolRegion toRestore)
        {
            var region = toRestore as DotNetConstructorRegion;
            if (region != null)
            {
                SelectedConstructor = region.SelectedConstructor;
                RestoreIfPrevious(region.SelectedConstructor);
                IsEnabled = region.IsEnabled;
                OnPropertyChanged("SelectedConstructor");
            }
        }

        public EventHandler<List<string>> ErrorsHandler
        {
            get;
            set;
        }

        #endregion

        #region Implementation of IConstructorRegion<IPluginConstructor>

        private void SetSelectedConstructor(IPluginConstructor value)
        {
            _selectedConstructor = value;
            SavedConstructor = value;
            if (value != null)
            {
                Method = value;
            }

            OnPropertyChanged("SelectedConstructor");
        }


        private void StorePreviousValues(string constructorName)
        {
            _previousRegions.Remove(constructorName);
            _previousRegions[constructorName] = new List<IToolRegion>(Dependants.Select(a => a.CloneRegion()));
        }

        private void RestorePreviousValues(IPluginConstructor value)
        {
            var toRestore = _previousRegions[value.GetIdentifier()];
            foreach (var toolRegion in Dependants.Zip(toRestore, (a, b) => new Tuple<IToolRegion, IToolRegion>(a, b)))
            {
                toolRegion.Item1.RestoreRegion(toolRegion.Item2);
            }
        }

        private bool IsAPreviousValue(IPluginConstructor value)
        {
            return value != null && _previousRegions.Keys.Any(a => a == value.GetIdentifier());
        }

        public IList<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                OnPropertyChanged();
            }
        }

        public IPluginConstructor SavedConstructor
        {
            get
            {
                return _modelItem.GetProperty<IPluginConstructor>("SavedConstructor");
            }
            set
            {
                _modelItem.SetProperty("SavedConstructor", value);
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnSomethingChanged(IToolRegion args)
        {
            var handler = SomethingChanged;
            handler?.Invoke(this, args);
        }
    }
}
