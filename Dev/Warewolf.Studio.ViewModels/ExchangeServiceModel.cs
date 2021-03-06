﻿using System.Collections.ObjectModel;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.ToolBase.ExchangeEmail;
using Dev2.Studio.Interfaces;

namespace Warewolf.Studio.ViewModels
{
    public class ExchangeServiceModel : IExchangeServiceModel
    {
        readonly IStudioUpdateManager _updateRepository;
        readonly IQueryManager _queryProxy;
        readonly IShellViewModel _shell;

        public ExchangeServiceModel(IStudioUpdateManager updateRepository, IQueryManager queryProxy, IShellViewModel shell, IServer server)
        {
            _updateRepository = updateRepository;
            _queryProxy = queryProxy;
            _shell = shell;
            shell.SetActiveServer(server.EnvironmentID);
        }
        public ObservableCollection<IExchangeSource> RetrieveSources() => new ObservableCollection<IExchangeSource>(_queryProxy.FetchExchangeSources());

        public void CreateNewSource()
        {
            _shell.NewExchangeSource(string.Empty);
        }

        public void EditSource(IExchangeSource selectedSource)
        {
            _shell.EditResource(selectedSource);
        }
        

        public IStudioUpdateManager UpdateRepository => _updateRepository;
    }
}
