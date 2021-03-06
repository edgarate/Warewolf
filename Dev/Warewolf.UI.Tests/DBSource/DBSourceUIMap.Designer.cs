﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Warewolf.UI.Tests.DBSource.DBSourceUIMapClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class DBSourceUIMap
    {
        
        #region Properties
        public MainStudioWindow MainStudioWindow
        {
            get
            {
                if ((this.mMainStudioWindow == null))
                {
                    this.mMainStudioWindow = new MainStudioWindow();
                }
                return this.mMainStudioWindow;
            }
        }
        #endregion
        
        #region Fields
        private MainStudioWindow mMainStudioWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MainStudioWindow : WpfWindow
    {
        
        public MainStudioWindow()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.Name, "Warewolf", PropertyExpressionOperator.Contains));
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public DockManager DockManager
        {
            get
            {
                if ((this.mDockManager == null))
                {
                    this.mDockManager = new DockManager(this);
                }
                return this.mDockManager;
            }
        }
        #endregion
        
        #region Fields
        private DockManager mDockManager;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class DockManager : WpfCustom
    {
        
        public DockManager(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.XamDockManager";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "DockManager";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public SplitPaneMiddle SplitPaneMiddle
        {
            get
            {
                if ((this.mSplitPaneMiddle == null))
                {
                    this.mSplitPaneMiddle = new SplitPaneMiddle(this);
                }
                return this.mSplitPaneMiddle;
            }
        }
        #endregion
        
        #region Fields
        private SplitPaneMiddle mSplitPaneMiddle;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class SplitPaneMiddle : WpfCustom
    {
        
        public SplitPaneMiddle(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SplitPane";
            this.SearchProperties[WpfControl.PropertyNames.Instance] = "2";
            this.SearchConfigurations.Add(SearchConfiguration.NextSibling);
            this.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public TabManSplitPane TabManSplitPane
        {
            get
            {
                if ((this.mTabManSplitPane == null))
                {
                    this.mTabManSplitPane = new TabManSplitPane(this);
                }
                return this.mTabManSplitPane;
            }
        }
        #endregion
        
        #region Fields
        private TabManSplitPane mTabManSplitPane;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class TabManSplitPane : WpfCustom
    {
        
        public TabManSplitPane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SplitPane";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "UI_SplitPane_AutoID";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public TabMan TabMan
        {
            get
            {
                if ((this.mTabMan == null))
                {
                    this.mTabMan = new TabMan(this);
                }
                return this.mTabMan;
            }
        }
        #endregion
        
        #region Fields
        private TabMan mTabMan;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class TabMan : WpfTabList
    {
        
        public TabMan(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "UI_TabManager_AutoID";
            this.WindowTitles.Add("Warewolf");
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public DBSourceTab DBSourceTab
        {
            get
            {
                if ((this.mDBSourceTab == null))
                {
                    this.mDBSourceTab = new DBSourceTab(this);
                }
                return this.mDBSourceTab;
            }
        }
        #endregion
        
        #region Fields
        private DBSourceTab mDBSourceTab;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class DBSourceTab : WpfTabPage
    {
        
        public DBSourceTab(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabPage.PropertyNames.Name] = "Dev2.ViewModels.SourceViewModel`1[Dev2.Common.Interfaces.ServerProxyLayer.IDbSour" +
                "ce]";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public WorkSurfaceContext WorkSurfaceContext
        {
            get
            {
                if ((this.mWorkSurfaceContext == null))
                {
                    this.mWorkSurfaceContext = new WorkSurfaceContext(this);
                }
                return this.mWorkSurfaceContext;
            }
        }
        
        public WpfScrollBar VerticalScrollBar
        {
            get
            {
                if ((this.mVerticalScrollBar == null))
                {
                    this.mVerticalScrollBar = new WpfScrollBar(this);
                    #region Search Criteria
                    this.mVerticalScrollBar.SearchProperties[WpfScrollBar.PropertyNames.AutomationId] = "VerticalScrollBar";
                    this.mVerticalScrollBar.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mVerticalScrollBar;
            }
        }
        
        public WpfScrollBar HorizontalScrollBar
        {
            get
            {
                if ((this.mHorizontalScrollBar == null))
                {
                    this.mHorizontalScrollBar = new WpfScrollBar(this);
                    #region Search Criteria
                    this.mHorizontalScrollBar.SearchProperties[WpfScrollBar.PropertyNames.AutomationId] = "HorizontalScrollBar";
                    this.mHorizontalScrollBar.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mHorizontalScrollBar;
            }
        }
        
        public WpfButton CloseButton
        {
            get
            {
                if ((this.mCloseButton == null))
                {
                    this.mCloseButton = new WpfButton(this);
                    #region Search Criteria
                    this.mCloseButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "closeBtn";
                    this.mCloseButton.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mCloseButton;
            }
        }
        #endregion
        
        #region Fields
        private WorkSurfaceContext mWorkSurfaceContext;
        
        private WpfScrollBar mVerticalScrollBar;
        
        private WpfScrollBar mHorizontalScrollBar;
        
        private WpfButton mCloseButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class WorkSurfaceContext : WpfCustom
    {
        
        public WorkSurfaceContext(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.ContentPane";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "Dev2.Studio.ViewModels.WorkSurface.WorkSurfaceContextViewModel";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public ManageDatabaseSourceControl ManageDatabaseSourceControl
        {
            get
            {
                if ((this.mManageDatabaseSourceControl == null))
                {
                    this.mManageDatabaseSourceControl = new ManageDatabaseSourceControl(this);
                }
                return this.mManageDatabaseSourceControl;
            }
        }
        
        public WpfButton TestConnectionButton
        {
            get
            {
                if ((this.mTestConnectionButton == null))
                {
                    this.mTestConnectionButton = new WpfButton(this);
                    #region Search Criteria
                    this.mTestConnectionButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "TestConnectionButton";
                    this.mTestConnectionButton.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mTestConnectionButton;
            }
        }
        
        public ErrorText ErrorText
        {
            get
            {
                if ((this.mErrorText == null))
                {
                    this.mErrorText = new ErrorText(this);
                }
                return this.mErrorText;
            }
        }
        
        public WpfEdit PasswordTextBox
        {
            get
            {
                if ((this.mPasswordTextBox == null))
                {
                    this.mPasswordTextBox = new WpfEdit(this);
                    #region Search Criteria
                    this.mPasswordTextBox.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "PasswordTextBox";
                    this.mPasswordTextBox.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mPasswordTextBox;
            }
        }
        
        public WpfEdit UserNameTextBox
        {
            get
            {
                if ((this.mUserNameTextBox == null))
                {
                    this.mUserNameTextBox = new WpfEdit(this);
                    #region Search Criteria
                    this.mUserNameTextBox.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "UserNameTextBox";
                    this.mUserNameTextBox.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mUserNameTextBox;
            }
        }
        
        public WpfRadioButton UserRadioButton
        {
            get
            {
                if ((this.mUserRadioButton == null))
                {
                    this.mUserRadioButton = new WpfRadioButton(this);
                    #region Search Criteria
                    this.mUserRadioButton.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "UserRadioButton";
                    this.mUserRadioButton.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mUserRadioButton;
            }
        }
        
        public WpfRadioButton WindowsRadioButton
        {
            get
            {
                if ((this.mWindowsRadioButton == null))
                {
                    this.mWindowsRadioButton = new WpfRadioButton(this);
                    #region Search Criteria
                    this.mWindowsRadioButton.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "WindowsRadioButton";
                    this.mWindowsRadioButton.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mWindowsRadioButton;
            }
        }
        
        public WpfButton CancelTestButton
        {
            get
            {
                if ((this.mCancelTestButton == null))
                {
                    this.mCancelTestButton = new WpfButton(this);
                    #region Search Criteria
                    this.mCancelTestButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "CancelTestButton";
                    this.mCancelTestButton.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mCancelTestButton;
            }
        }
        
        public WpfImage ConnectionPassedImage
        {
            get
            {
                if ((this.mConnectionPassedImage == null))
                {
                    this.mConnectionPassedImage = new WpfImage(this);
                    #region Search Criteria
                    this.mConnectionPassedImage.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mConnectionPassedImage.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mConnectionPassedImage;
            }
        }
        
        public WpfCustom Spinner
        {
            get
            {
                if ((this.mSpinner == null))
                {
                    this.mSpinner = new WpfCustom(this);
                    #region Search Criteria
                    this.mSpinner.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.CircularProgressBar";
                    this.mSpinner.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mSpinner.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mSpinner;
            }
        }
        #endregion
        
        #region Fields
        private ManageDatabaseSourceControl mManageDatabaseSourceControl;
        
        private WpfButton mTestConnectionButton;
        
        private ErrorText mErrorText;
        
        private WpfEdit mPasswordTextBox;
        
        private WpfEdit mUserNameTextBox;
        
        private WpfRadioButton mUserRadioButton;
        
        private WpfRadioButton mWindowsRadioButton;
        
        private WpfButton mCancelTestButton;
        
        private WpfImage mConnectionPassedImage;
        
        private WpfCustom mSpinner;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ManageDatabaseSourceControl : WpfCustom
    {
        
        public ManageDatabaseSourceControl(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.ManageDatabaseSourceControl";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public ServerComboBox ServerComboBox
        {
            get
            {
                if ((this.mServerComboBox == null))
                {
                    this.mServerComboBox = new ServerComboBox(this);
                }
                return this.mServerComboBox;
            }
        }
        
        public DatabaseComboxBox DatabaseComboxBox
        {
            get
            {
                if ((this.mDatabaseComboxBox == null))
                {
                    this.mDatabaseComboxBox = new DatabaseComboxBox(this);
                }
                return this.mDatabaseComboxBox;
            }
        }
        
        public WpfButton TestConnectionButton
        {
            get
            {
                if ((this.mTestConnectionButton == null))
                {
                    this.mTestConnectionButton = new WpfButton(this);
                    #region Search Criteria
                    this.mTestConnectionButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "TestConnectionButton";
                    this.mTestConnectionButton.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mTestConnectionButton;
            }
        }
        #endregion
        
        #region Fields
        private ServerComboBox mServerComboBox;
        
        private DatabaseComboxBox mDatabaseComboxBox;
        
        private WpfButton mTestConnectionButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ServerComboBox : WpfComboBox
    {
        
        public ServerComboBox(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "ServerTextBox";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public WpfListItem RSAKLFSVRDEV
        {
            get
            {
                if ((this.mRSAKLFSVRDEV == null))
                {
                    this.mRSAKLFSVRDEV = new WpfListItem(this);
                    #region Search Criteria
                    this.mRSAKLFSVRDEV.SearchProperties[WpfListItem.PropertyNames.Name] = "RSAKLFSVRDEV";
                    this.mRSAKLFSVRDEV.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mRSAKLFSVRDEV;
            }
        }
        
        public WpfEdit Textbox
        {
            get
            {
                if ((this.mTextbox == null))
                {
                    this.mTextbox = new WpfEdit(this);
                    #region Search Criteria
                    this.mTextbox.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "Text";
                    this.mTextbox.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mTextbox;
            }
        }
        #endregion
        
        #region Fields
        private WpfListItem mRSAKLFSVRDEV;
        
        private WpfEdit mTextbox;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class DatabaseComboxBox : WpfCustom
    {
        
        public DatabaseComboxBox(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.XamComboEditor";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "DatabaseComboxBox";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public WpfText UIDev2TestingDBText
        {
            get
            {
                if ((this.mUIDev2TestingDBText == null))
                {
                    this.mUIDev2TestingDBText = new WpfText(this);
                    #region Search Criteria
                    this.mUIDev2TestingDBText.SearchProperties[WpfText.PropertyNames.Name] = "Dev2TestingDB";
                    this.mUIDev2TestingDBText.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mUIDev2TestingDBText;
            }
        }
        
        public WpfText UIPostgresText
        {
            get
            {
                if ((this.mUIPostgresText == null))
                {
                    this.mUIPostgresText = new WpfText(this);
                    #region Search Criteria
                    this.mUIPostgresText.SearchProperties[WpfText.PropertyNames.Name] = "postgres";
                    this.mUIPostgresText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mUIPostgresText;
            }
        }
        
        public WpfText UIHRText
        {
            get
            {
                if ((this.mUIHRText == null))
                {
                    this.mUIHRText = new WpfText(this);
                    #region Search Criteria
                    this.mUIHRText.SearchProperties[WpfText.PropertyNames.Name] = "HR";
                    this.mUIHRText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mUIHRText;
            }
        }
        
        public WpfText UIExcelFilesText
        {
            get
            {
                if ((this.mUIExcelFilesText == null))
                {
                    this.mUIExcelFilesText = new WpfText(this);
                    #region Search Criteria
                    this.mUIExcelFilesText.SearchProperties[WpfText.PropertyNames.Name] = "Excel Files";
                    this.mUIExcelFilesText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mUIExcelFilesText;
            }
        }
        
        public WpfText UIMysqlText
        {
            get
            {
                if ((this.mUIMysqlText == null))
                {
                    this.mUIMysqlText = new WpfText(this);
                    #region Search Criteria
                    this.mUIMysqlText.SearchProperties[WpfText.PropertyNames.Name] = "mysql";
                    this.mUIMysqlText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mUIMysqlText;
            }
        }
        
        public WpfText MSAccessDatabaseText
        {
            get
            {
                if ((this.mMSAccessDatabaseText == null))
                {
                    this.mMSAccessDatabaseText = new WpfText(this);
                    #region Search Criteria
                    this.mMSAccessDatabaseText.SearchProperties[WpfText.PropertyNames.Name] = "MS Access Database";
                    this.mMSAccessDatabaseText.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mMSAccessDatabaseText;
            }
        }
        
        public WpfButton ToggleButton
        {
            get
            {
                if ((this.mToggleButton == null))
                {
                    this.mToggleButton = new WpfButton(this);
                    #region Search Criteria
                    this.mToggleButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "ToggleButton";
                    this.mToggleButton.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mToggleButton;
            }
        }
        
        public WpfText TestDBText
        {
            get
            {
                if ((this.mTestDBText == null))
                {
                    this.mTestDBText = new WpfText(this);
                    #region Search Criteria
                    this.mTestDBText.SearchProperties[WpfText.PropertyNames.Name] = "TestDB";
                    this.mTestDBText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mTestDBText;
            }
        }
        
        public WpfText masterText
        {
            get
            {
                if ((this.mmasterText == null))
                {
                    this.mmasterText = new WpfText(this);
                    #region Search Criteria
                    this.mmasterText.SearchProperties[WpfText.PropertyNames.Name] = "master";
                    this.mmasterText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mmasterText;
            }
        }
        
        public WpfText testText
        {
            get
            {
                if ((this.mtestText == null))
                {
                    this.mtestText = new WpfText(this);
                    #region Search Criteria
                    this.mtestText.SearchProperties[WpfText.PropertyNames.Name] = "test";
                    this.mtestText.WindowTitles.Add("Warewolf (DEV2\\DYLAN.DELPORT)");
                    #endregion
                }
                return this.mtestText;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIDev2TestingDBText;
        
        private WpfText mUIPostgresText;
        
        private WpfText mUIHRText;
        
        private WpfText mUIExcelFilesText;
        
        private WpfText mUIMysqlText;
        
        private WpfText mMSAccessDatabaseText;
        
        private WpfButton mToggleButton;
        
        private WpfText mTestDBText;
        
        private WpfText mmasterText;
        
        private WpfText mtestText;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ErrorText : WpfText
    {
        
        public ErrorText(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.AutomationId] = "ErrorTextBlock";
            this.WindowTitles.Add("Warewolf");
            #endregion
        }
        
        #region Properties
        public WpfCustom Spinner
        {
            get
            {
                if ((this.mSpinner == null))
                {
                    this.mSpinner = new WpfCustom(this);
                    #region Search Criteria
                    this.mSpinner.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.CircularProgressBar";
                    this.mSpinner.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mSpinner.WindowTitles.Add("Warewolf");
                    #endregion
                }
                return this.mSpinner;
            }
        }
        #endregion
        
        #region Fields
        private WpfCustom mSpinner;
        #endregion
    }
}
