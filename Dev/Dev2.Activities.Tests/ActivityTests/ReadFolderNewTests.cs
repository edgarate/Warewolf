﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using ActivityUnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Common.Wrappers;
using Dev2.Common;

namespace Dev2.Tests.Activities.ActivityTests
{
    [TestClass]
    public class ReadFolderNewTests : BaseActivityUnitTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }
        string _inputPath;
        IDirectory dirHelper;

        [TestMethod]
        [TestCategory("DsfFolderRead_UpdateForEachInputs")]
        public void DsfFolderRead_Execute_Expecting_No_Out_Puts_Has_0_Records()
        {
            //------------Setup for test--------------------------
            dirHelper = new DirectoryWrapper();
            var id = Guid.NewGuid().ToString();
            _inputPath = EnvironmentVariables.ResourcePath + "\\" + id.Substring(0, 8);
            dirHelper.CreateIfNotExists(_inputPath);
            var act = new DsfFolderReadActivity { InputPath = _inputPath, Result = "[[RecordSet().File]]" };
            //------------Execute Test---------------------------
            var results = act.Execute(DataObject, 0);
            //------------Assert Results-------------------------
            Assert.IsFalse(DataObject.Environment.HasRecordSet("[[RecordSet()]]"));
        }

        [TestMethod]
        [TestCategory("DsfFolderReadActivity_UpdateForEachInputs")]
        public void DsfFolderReadActivity_UpdateForEachInputs_NullUpdates_DoesNothing()
        {
            //------------Setup for test--------------------------
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]");
            var act = new DsfFolderReadActivity { InputPath = inputPath, Result = "[[res]]" };

            //------------Execute Test---------------------------
            act.UpdateForEachInputs(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(inputPath, act.InputPath);
        }

        [TestMethod]
        [TestCategory("DsfFolderReadActivity_UpdateForEachInputs")]
        public void DsfFolderReadActivity_UpdateForEachInputs_MoreThan1Updates_DoesNothing()
        {
            //------------Setup for test--------------------------
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]");
            var act = new DsfFolderReadActivity { InputPath = inputPath, Result = "[[res]]" };

            var tuple1 = new Tuple<string, string>("Test", "Test");
            var tuple2 = new Tuple<string, string>(inputPath, "Test2");
            //------------Execute Test---------------------------
            act.UpdateForEachInputs(new List<Tuple<string, string>> { tuple1, tuple2 });
            //------------Assert Results-------------------------
            Assert.AreEqual(inputPath, act.InputPath);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfFolderReadActivity_UpdateForEachInputs")]
        public void DsfFolderReadActivity_UpdateForEachInputs_1Update_UpdateInputPath()
        {
            //------------Setup for test--------------------------
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]");
            var act = new DsfFolderReadActivity { InputPath = inputPath, Result = "[[res]]" };

            var tuple1 = new Tuple<string, string>("Test", "Test");
            //------------Execute Test---------------------------
            act.UpdateForEachInputs(new List<Tuple<string, string>> { tuple1 });
            //------------Assert Results-------------------------
            Assert.AreEqual("Test", act.InputPath);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfFolderReadActivity_UpdateForEachOutputs")]
        public void DsfFolderReadActivity_UpdateForEachOutputs_NullUpdates_DoesNothing()
        {
            //------------Setup for test--------------------------
            const string result = "[[res]]";
            var act = new DsfFolderReadActivity { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]"), Result = result };

            act.UpdateForEachOutputs(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(result, act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfFolderReadActivity_UpdateForEachOutputs")]
        public void DsfFolderReadActivity_UpdateForEachOutputs_MoreThan1Updates_DoesNothing()
        {
            //------------Setup for test--------------------------
            const string result = "[[res]]";
            var act = new DsfFolderReadActivity { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]"), Result = result };

            var tuple1 = new Tuple<string, string>("Test", "Test");
            var tuple2 = new Tuple<string, string>("Test2", "Test2");
            //------------Execute Test---------------------------
            act.UpdateForEachOutputs(new List<Tuple<string, string>> { tuple1, tuple2 });
            //------------Assert Results-------------------------
            Assert.AreEqual(result, act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfFolderReadActivity_UpdateForEachOutputs")]
        public void DsfFolderReadActivity_UpdateForEachOutputs_1Updates_UpdateCommandResult()
        {
            //------------Setup for test--------------------------
            const string result = "[[res]]";
            var act = new DsfFolderReadActivity { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]"), Result = result };

            var tuple1 = new Tuple<string, string>("[[res]]", "Test");
            //------------Execute Test---------------------------
            act.UpdateForEachOutputs(new List<Tuple<string, string>> { tuple1 });
            //------------Assert Results-------------------------
            Assert.AreEqual("Test", act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfFolderReadActivity_GetForEachInputs")]
        public void DsfFolderReadActivity_GetForEachInputs_WhenHasExpression_ReturnsInputList()
        {
            //------------Setup for test--------------------------
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]");
            var act = new DsfFolderReadActivity { InputPath = inputPath, Result = "[[res]]" };

            //------------Execute Test---------------------------
            var dsfForEachItems = act.GetForEachInputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(1, dsfForEachItems.Count);
            Assert.AreEqual(inputPath, dsfForEachItems[0].Name);
            Assert.AreEqual(inputPath, dsfForEachItems[0].Value);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfFolderReadActivity_GetForEachOutputs")]
        public void DsfFolderReadActivity_GetForEachOutputs_WhenHasResult_ReturnsOutputList()
        {
            //------------Setup for test--------------------------
            const string result = "[[res]]";
            var act = new DsfFolderReadActivity { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", "[[CompanyName]]"), Result = result };

            //------------Execute Test---------------------------
            var dsfForEachItems = act.GetForEachOutputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(1, dsfForEachItems.Count);
            Assert.AreEqual(result, dsfForEachItems[0].Name);
            Assert.AreEqual(result, dsfForEachItems[0].Value);
        }

        [TestCleanup]
        public void DeleteDir()
        {
            if (!string.IsNullOrEmpty(_inputPath) && dirHelper.Exists(_inputPath))
            {
                dirHelper.Delete(_inputPath, true);
            }
        }
    }
}