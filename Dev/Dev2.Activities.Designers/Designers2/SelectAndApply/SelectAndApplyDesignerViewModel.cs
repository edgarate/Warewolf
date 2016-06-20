/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Dev2.Activities.Designers2.Core;
using Dev2.Common;
using Dev2.Interfaces;
using Dev2.Models;
using Dev2.Studio.Core;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Core.Factories;
using Dev2.Studio.Core.Interfaces;
using Dev2.Utils;
using Microsoft.CSharp.RuntimeBinder;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Dev2.Common.Interfaces;

// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

namespace Dev2.Activities.Designers2.SelectAndApply
{
    public class SelectAndApplyDesignerViewModel : ActivityDesignerViewModel
    {

        public SelectAndApplyDesignerViewModel(ModelItem modelItem)
            : base(modelItem)
        {
            AddTitleBarLargeToggle();
           
        }


        public override void Validate()
        {
        }

        public override void UpdateHelpDescriptor(string helpText)
        {
            var mainViewModel = CustomContainer.Get<IMainViewModel>();
            if (mainViewModel != null)
            {
                mainViewModel.HelpViewModel.UpdateHelpText(helpText);
            }
        }


        public bool SetModelItemForServiceTypes(IDataObject dataObject)
        {
            if (dataObject != null && (dataObject.GetDataPresent(GlobalConstants.ExplorerItemModelFormat) || dataObject.GetDataPresent(GlobalConstants.UpgradedExplorerItemModelFormat)))
            {
                var explorerItemModel = dataObject.GetData(GlobalConstants.ExplorerItemModelFormat);
                Guid envID = new Guid();
                Guid resourceID = new Guid(); 
                if (explorerItemModel != null)
                {
                    
                    ExplorerItemModel itemModel = explorerItemModel as ExplorerItemModel;
                    if (itemModel != null)
                    {
                        envID = itemModel.EnvironmentId;
                        resourceID = itemModel.ResourceId;
                    }
                }
                if (explorerItemModel == null)
                {
                    explorerItemModel = dataObject.GetData(GlobalConstants.UpgradedExplorerItemModelFormat);
                    if (explorerItemModel == null)
                    {
                        return false;
                    }
                    IExplorerItemViewModel itemModel = explorerItemModel as IExplorerItemViewModel;
                    if (itemModel != null)
                    {
                        if(itemModel.Server != null)
                            envID = itemModel.Server.EnvironmentID;
                        resourceID = itemModel.ResourceId;
                    }
                }
                try
                {

                    IEnvironmentModel environmentModel = EnvironmentRepository.Instance.FindSingle(c => c.ID == envID);
                    if (environmentModel != null)
                    {
                        var resource = environmentModel.ResourceRepository.FindSingle(c => c.ID == resourceID) as IContextualResourceModel;

                        if (resource != null)
                        {
                            DsfActivity d = DsfActivityFactory.CreateDsfActivity(resource, null, true, EnvironmentRepository.Instance, true);
                            d.ServiceName = d.DisplayName = d.ToolboxFriendlyName = resource.Category;
                            d.IconPath = resource.IconPath;
                            if (Application.Current != null && Application.Current.Dispatcher.CheckAccess() && Application.Current.MainWindow != null)
                            {
                                dynamic mvm = Application.Current.MainWindow.DataContext;
                                if (mvm != null && mvm.ActiveItem != null)
                                {
                                    WorkflowDesignerUtils.CheckIfRemoteWorkflowAndSetProperties(d, resource, mvm.ActiveItem.Environment);
                                }
                            }

                            ModelItem modelItem = ModelItemUtils.CreateModelItem(d);
                            if (modelItem != null)
                            {
                                dynamic mi = ModelItem;
                                mi.ApplyActivityFunc.Handler = d;
                                return true;
                            }
                        }
                    }
                }
                catch (RuntimeBinderException e)
                {
                    Dev2Logger.Error(e);
                }
            }
            return false;
        }

        public bool DoDrop(IDataObject dataObject)
        {
            var formats = dataObject.GetFormats();
            if (!formats.Any())
            {
                return false;
            }
            dynamic mi = ModelItem;
            var modelItemString = formats.FirstOrDefault(s => s.IndexOf("ModelItemsFormat", StringComparison.Ordinal) >= 0);
            if (!String.IsNullOrEmpty(modelItemString))
            {
                var objectData = dataObject.GetData(modelItemString);
                var data = objectData as List<ModelItem>;
                if (data != null && data.Count >= 1)
                {
                    foreach (var item in data)
                    {
                        mi.ApplyActivityFunc.Handler = item;
                    }
                    return true;
                }
            }
            return SetModelItemForServiceTypes(dataObject);
        }

    }
}
