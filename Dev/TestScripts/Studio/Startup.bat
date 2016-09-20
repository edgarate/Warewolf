REM ********************************************************************************************************************
REM * Hi-Jack the Auto Build Variables by QtAgent since this is injected after it has REM * setup
REM * Open the autogenerated qtREM * setup in the test run location of
REM * C:\Users\IntegrationTester\AppData\Local\VSEQT\QTAgent\...
REM * For example:
REM * set DeploymentDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\DEPLOY~1
REM * set TestRunDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1
REM * set TestRunResultsDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results\RSAKLF~1
REM * set TotalAgents=5
REM * set AgentWeighting=100
REM * set AgentLoadDistributor=Microsoft.VisualStudio.TestTools.Execution.AgentLoadDistributor
REM * set AgentId=1
REM * set TestDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1
REM * set ResultsDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results
REM * set DataCollectionEnvironmentContext=Microsoft.VisualStudio.TestTools.Execution.DataCollectionEnvironmentContext
REM * set TestLogsDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results\RSAKLF~1
REM * set ControllerName=rsaklfsvrtfsbld:6901
REM * set TestDeploymentDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\DEPLOY~1
REM * set AgentName=RSAKLFTST7X64-3
REM ********************************************************************************************************************

REM ** Check for admin **
@echo off
echo Administrative permissions required. Detecting permissions...
REM using the "net session" command to detect admin, it requires elevation in the most operating systems - Ashley
IF EXIST %windir%\nircmd.exe (nircmd elevate net session >nul 2>&1) else (net session >nul 2>&1)
if %errorLevel% == 0 (
	echo Success: Administrative permissions confirmed.
) else (
	echo Failure: Current permissions inadequate.
	exit 1
)
@echo on

REM ** Cleanup
set /a LoopCounter=0
:RetryClean
IF NOT EXIST "%PROGRAMDATA%\Warewolf\Resources" IF NOT EXIST "%PROGRAMDATA%\Warewolf\Workspaces" IF NOT EXIST "%PROGRAMDATA%\Warewolf\Server Settings" GOTO StopRetryingClean

REM ** Kill The Warewolf ;) **
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Studio.exe" /fi "STATUS eq RUNNING") else (taskkill /f /im "Warewolf Studio.exe" /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq RUNNING") else (taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Studio.vshost.exe" /fi "STATUS eq RUNNING") else (taskkill /f /im "Warewolf Studio.vshost.exe" /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq RUNNING") else (taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq RUNNING") else (taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Studio.exe" /fi "STATUS eq UNKNOWN") else (taskkill /f /im "Warewolf Studio.exe" /fi "STATUS eq UNKNOWN")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq UNKNOWN") else (taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq UNKNOWN")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Studio.vshost.exe" /fi "STATUS eq UNKNOWN") else (taskkill /f /im "Warewolf Studio.vshost.exe" /fi "STATUS eq UNKNOWN")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN") else (taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq UNKNOWN") else (taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq UNKNOWN")

REM ** Delete the Warewolf ProgramData folder
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Resources") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Resources")
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Workspaces") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Workspaces")
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings\") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings")
@echo off
IF EXIST "%PROGRAMDATA%\Warewolf\Resources" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Resources
IF EXIST "%PROGRAMDATA%\Warewolf\Workspaces" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Workspaces
IF EXIST "%PROGRAMDATA%\Warewolf\Server Settings" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Server Settings
@echo on

set /a LoopCounter=LoopCounter+1
IF %LoopCounter% EQU 30 exit 1
rem wait for 5 seconds before trying again
@echo %AgentName% is attempting number %LoopCounter% out of 30: Waiting 5 more seconds for "%PROGRAMDATA%\Warewolf" folder cleanup...
waitfor ProgramDataClean /t 5 
set errorlevel=0
goto RetryClean

:StopRetryingClean

REM Init paths to Warewolf server under test
IF EXIST "%DeploymentDirectory%\DebugServer.zip" powershell.exe -nologo -noprofile -command "& { Expand-Archive '%DeploymentDirectory%\DebugServer.zip' '%DeploymentDirectory%\Server' -Force }"
IF EXIST "%DeploymentDirectory%\DebugStudio.zip" powershell.exe -nologo -noprofile -command "& { Expand-Archive '%DeploymentDirectory%\DebugStudio.zip' '%DeploymentDirectory%\Studio' -Force }"
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0..\..\Dev2.Server\bin\Debug\Warewolf Server.exe" SET DeploymentDirectory=%~dp0..\..\Dev2.Server\bin\Debug
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0Server\Warewolf Server.exe" SET DeploymentDirectory=%~dp0Server
IF EXIST "%DeploymentDirectory%\Server\Warewolf Server.exe" SET DeploymentDirectory=%DeploymentDirectory%\Server

REM ** Try refresh server bin resources
IF NOT EXIST "%DeploymentDirectory%\Resources" IF EXIST "%~dp0..\..\Resources - Debug\Resources" echo d | xcopy /S /Y "%~dp0..\..\Resources - Debug\Resources" "%DeploymentDirectory%\Resources"

REM ** Start Warewolf server from deployed binaries **
IF EXIST "%DeploymentDirectory%\ServerStarted" DEL "%DeploymentDirectory%\ServerStarted"
IF EXIST %windir%\nircmd.exe (nircmd elevate "%DeploymentDirectory%\Warewolf Server.exe") else (START "%DeploymentDirectory%\Warewolf Server.exe" /D "%DeploymentDirectory%" "Warewolf Server.exe")
@echo Started "%DeploymentDirectory%\Warewolf Server.exe".

REM Try use Default Workspace Layout
IF EXIST "%DeploymentDirectory%\DefaultWorkspaceLayout.xml" COPY /Y "%DeploymentDirectory%\DefaultWorkspaceLayout.xml" "%LocalAppData%\Warewolf\UserInterfaceLayouts\WorkspaceLayout.xml"
IF EXIST "%DeploymentDirectory%\..\DefaultWorkspaceLayout.xml" COPY /Y "%DeploymentDirectory%\..\DefaultWorkspaceLayout.xml" "%LocalAppData%\Warewolf\UserInterfaceLayouts\WorkspaceLayout.xml"
IF EXIST "%~dp0..\..\Warewolf.UITests\Properties\DefaultWorkspaceLayout.xml" COPY /Y "%DeploymentDirectory%\..\DefaultWorkspaceLayout.xml" "%LocalAppData%\Warewolf\UserInterfaceLayouts\WorkspaceLayout.xml"
REM Init paths to Warewolf studio under test
IF NOT EXIST "%DeploymentDirectory%\..\Studio\Warewolf Studio.exe" IF EXIST "%~dp0..\..\Dev2.Studio\bin\Debug\Warewolf Studio.exe" SET DeploymentDirectory=%~dp0..\..\Dev2.Studio\bin\Debug
IF EXIST "%DeploymentDirectory%\..\Studio\Warewolf Studio.exe" SET DeploymentDirectory=%DeploymentDirectory%\..\Studio

REM ** Start Warewolf studio from deployed binaries **
@echo off
:WaitForServerStart
set /a LoopCounter=0
:MainLoopBody
IF EXIST "%~dp0Dev2.Server\bin\Debug\ServerStarted" goto StartStudio
set /a LoopCounter=LoopCounter+1
IF %LoopCounter% EQU 30 echo Timed out waiting for the Warewolf server to start. &exit /b
@echo Waiting 2 more seconds for server start...
waitfor ServerStart /t 2 
goto MainLoopBody

:StartStudio
@echo on
IF EXIST %windir%\nircmd.exe (nircmd elevate "%DeploymentDirectory%\Warewolf Studio.exe") else (START "%DeploymentDirectory%\Warewolf Studio.exe" /D "%DeploymentDirectory%" "Warewolf Studio.exe")
@echo Started "%DeploymentDirectory%\Warewolf Studio.exe".

exit 0
