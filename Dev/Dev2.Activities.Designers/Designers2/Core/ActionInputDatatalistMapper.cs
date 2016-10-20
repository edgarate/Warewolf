using System;
using System.Collections.Generic;
using System.Linq;
using Dev2.Common.Interfaces.DB;
using Dev2.Data.Util;
using Dev2.Studio.Core;

namespace Dev2.Activities.Designers2.Core
{
    public class ActionInputDatatalistMapper : IActionInputDatatalistMapper
    {
        #region Implementation of IActionInputDatatalistMapper

        public void MappInputsToDatalist(IEnumerable<IServiceInput> inputs)
        {
            if (inputs != null)
            {
                foreach (var serviceInput in inputs)
                {

                    if (DataListSingleton.ActiveDataList != null)
                    {
                        if (DataListSingleton.ActiveDataList.ScalarCollection != null)
                        {
                            var value = serviceInput?.Name;
                            if(value != null)
                            {
                                value = value.Split('(').First().TrimEnd(' ');
                                var alreadyExists = DataListSingleton.ActiveDataList.ScalarCollection.Count(model => model.Name.Equals(value, StringComparison.InvariantCulture));
                                if (alreadyExists < 1)
                                {
                                    var variable = DataListUtil.AddBracketsToValueIfNotExist(value);
                                    serviceInput.Value = variable;
                                }
                                else
                                {
                                    var variable = DataListUtil.AddBracketsToValueIfNotExist(value);
                                    serviceInput.Value = variable;
                                }
                            }
                        }
                    }


                }
            }
        }

        #endregion
    }
}