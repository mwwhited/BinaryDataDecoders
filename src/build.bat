
@echo off

SETLOCAL
SET TARGET_INPUT=%~1
SET NO_XML_TRANSFORM=1
SET DO_NOT_CLEAN=0
SET XSLT_CMD=dotnet bdd-xslt
SET USE_LOCAL=0

SET Configuration=Release

SET SANDBOX_PATH=%~dp0..
SET BUILD_PATH=%SANDBOX_PATH%\src
SET BUILD_PROJECT=%BUILD_PATH%\BinaryDataDecoders.sln
SET OUTPUT_PATH=%SANDBOX_PATH%\Publish
SET TEST_RESULTS_PATH=%OUTPUT_PATH%\TestResults
SET DOCS_PATH=%OUTPUT_PATH%\docs
SET RESULTS_PATH=%OUTPUT_PATH%\Results
SET TEMPLATES_PATH=%SANDBOX_PATH%\templates\reports
SET WIKI_PATH=%SANDBOX_PATH%\docs
SET TEST_RUN_SETTINGS=%BUILD_PATH%\.runsettings
SET BUILD_LOG=%OUTPUT_PATH%\dotnet_build.binlog

REM java is required for antlr4
SET JAVA_EXEC=%JAVA_HOME%\bin\java.exe

REM SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT
REM SET VsInstallRoot=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional

echo "=== configured ==="
ECHO TARGET_INPUT="%TARGET_INPUT%"
ECHO Configuration="%Configuration%"
Echo Directory = %~dp0
ECHO SANDBOX_PATH="%SANDBOX_PATH%"
ECHO BUILD_PATH="%BUILD_PATH%"
ECHO BUILD_PROJECT="%BUILD_PROJECT%"
ECHO OUTPUT_PATH="%OUTPUT_PATH%"
ECHO TEST_RESULTS_PATH="%TEST_RESULTS_PATH%"
ECHO DOCS_PATH="%DOCS_PATH%"
ECHO RESULTS_PATH="%RESULTS_PATH%"
ECHO TEMPLATES_PATH="%TEMPLATES_PATH%"
ECHO WIKI_PATH="%WIKI_PATH%"
ECHO JAVA_EXEC="%JAVA_EXEC%"
ECHO TEST_RUN_SETTINGS="%TEST_RUN_SETTINGS%"
ECHO BUILD_LOG="%BUILD_LOG%"

pushd
REM PAUSE

echo "Git fetch"
git fetch --prune
dotnet tool install --local gitversion.tool
dotnet tool update gitversion.tool
FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)
if "%BUILD_VERSION%"=="" GOTO error
echo "Building Version=%BUILD_VERSION%"

:top
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%

:clean
IF "%DO_NOT_CLEAN%"=="1" GOTO skip_clean
echo "Clean Packages"
dotnet clean "%BUILD_PROJECT%" -v m
rmdir /s/q "%OUTPUT_PATH%"
:skip_clean
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:restore
echo "Restore Packages"
dotnet restore "%BUILD_PROJECT%""
IF %errorlevel% NEQ 0 GOTO error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:build
echo "Build Packages"

REM https://github.com/laurenprinn/MSBuildStructuredLog
dotnet build "%BUILD_PROJECT%" --configuration %Configuration% --no-restore /p:Version=%BUILD_VERSION% "/bl:logfile=%BUILD_LOG%"
IF %errorlevel% NEQ 0 GOTO error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:test
echo "Run Tests"
FOR /D %%T IN ("%BUILD_PATH%\*.Tests") DO (
dotnet test "%%T" --no-build --no-restore ^
--collect:"XPlat Code Coverage" -r "%TEST_RESULTS_PATH%" ^
--nologo --filter "TestCategory=Unit|TestCategory=Simulate" ^
-s "%TEST_RUN_SETTINGS%" /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true ^
--logger "trx;LogFileName=%%~nxT.trx"
IF %errorlevel% NEQ 0 GOTO error
)
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:pack
echo "Pack Projects"
dotnet pack "%BUILD_PROJECT%" --configuration %Configuration% --no-build --no-restore -o "%OUTPUT_PATH%\Nuget" -p:PackageVersion=%BUILD_VERSION%
IF %errorlevel% NEQ 0 GOTO error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:publish
echo "Pack Projects"
dotnet publish "%BUILD_PROJECT%" --configuration %Configuration% --no-build --no-restore -o "%RESULTS_PATH%\Binary"
IF %errorlevel% NEQ 0 GOTO error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:report
echo "Build Reports"
dotnet tool install --local dotnet-reportgenerator-globaltool
dotnet tool update dotnet-reportgenerator-globaltool
dotnet reportgenerator "-reports:%TEST_RESULTS_PATH%\**\coverage.cobertura.xml" "-targetDir:%RESULTS_PATH%\Coverage" "-reportTypes:Xml" "-title:%BUILD_PROJECT% - (%BUILD_VERSION%)"
IF %errorlevel% NEQ 0 GOTO error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:transform
echo "Transform Reports"
dotnet tool uninstall BinaryDataDecoders.Xslt.Cli --global
dotnet tool uninstall BinaryDataDecoders.Xslt.Cli --local
dotnet tool install --add-source "%OUTPUT_PATH%\Nuget" --local BinaryDataDecoders.Xslt.Cli --version %BUILD_VERSION% --no-cache
REM dotnet tool update BinaryDataDecoders.Xslt.Cli --version %BUILD_VERSION% --no-cache

ECHO ">>> BinaryDataDecoders.Xslt.Cli (TestResults) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\TestResultsToMarkdown.xslt" -i "%TEST_RESULTS_PATH%\*.trx" -o "%DOCS_PATH%\TestReports\*.md" -s "%SANDBOX_PATH%"
IF %errorlevel% NEQ 0 GOTO error

ECHO ">>> BinaryDataDecoders.Xslt.Cli (Coverage) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\CoverageToMarkdown.xslt" -i "%RESULTS_PATH%\Coverage\*.xml" -o "%DOCS_PATH%\Coverage\*.md"  -s "%SANDBOX_PATH%"
IF %errorlevel% NEQ 0 GOTO error

ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Structured) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\XmlCommentsToStructuredXml.xslt" -i "%RESULTS_PATH%\Binary\*.xml" -o "%RESULTS_PATH%\Code\*.xml" -s "%SANDBOX_PATH%"
IF %errorlevel% NEQ 0 GOTO error

ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Markdown) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\XmlCommentsToMarkdown.xslt" -i "%RESULTS_PATH%\Code\*.xml" -o "%DOCS_PATH%\Code\*.md" -s "%SANDBOX_PATH%"
IF %errorlevel% NEQ 0 GOTO error
ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to Markdown) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\CSharpToMarkdown.xslt" -i "%BUILD_PATH%\**\*.cs" -o "%DOCS_PATH%\SourceCode\*.md" -s "%SANDBOX_PATH%" -x CSharp
IF %errorlevel% NEQ 0 GOTO error

ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to Markdown) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\CSharpToMarkdown.xslt" -i "%BUILD_PATH%\**\*.vb" -o "%DOCS_PATH%\SourceCode\*.md" -s "%SANDBOX_PATH%" -x VB
IF %errorlevel% NEQ 0 GOTO error

ECHO ">>> BinaryDataDecoders.Xslt.Cli (Build Log to Markdown) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\BuildLogToMarkdown.xslt" -i "%BUILD_LOG%" -o "%DOCS_PATH%\BuildLog.md" -s "%SANDBOX_PATH%" -x MSBuildStructuredLog
IF %errorlevel% NEQ 0 GOTO error

REM This should be the last of the markdown files
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Docs to Markdown) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\PathToMarkdown.xslt" -i "%DOCS_PATH%" -o "%DOCS_PATH%\TOC.md" -s "%SANDBOX_PATH%" -x Path
IF %errorlevel% NEQ 0 GOTO error

IF "%NO_XML_TRANSFORM%"=="1" GOTO skip_xml_out
:transform_xml
ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to XML) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%BUILD_PATH%\**\*.cs" -o "%RESULTS_PATH%\SourceCode\*.xml" -s "%SANDBOX_PATH%" -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to XML) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%BUILD_PATH%\**\*.vb" -o "%RESULTS_PATH%\SourceCode\*.xml" -s "%SANDBOX_PATH%" -x VB
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Docs to XML) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%DOCS_PATH%" -o "%RESULTS_PATH%\Path.xml" -s "%SANDBOX_PATH%" -x Path
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Build Log to XML) <<<"
%XSLT_CMD% -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%BUILD_LOG%" -o "%RESULTS_PATH%\BuildLog.xml" -s "%SANDBOX_PATH%" -x MSBuildStructuredLog
:skip_xml_out

dotnet tool uninstall BinaryDataDecoders.Xslt.Cli --local
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:wiki
REM pushd
echo "Post Wiki"
robocopy /MIR "%DOCS_PATH%" "%WIKI_PATH%"
REM https://ss64.com/nt/robocopy-exit.html
if %ERRORLEVEL% EQU 16 echo ***FATAL ERROR*** & goto error
if %ERRORLEVEL% EQU 15 echo OKCOPY + FAIL + MISMATCHES + XTRA & goto error
if %ERRORLEVEL% EQU 14 echo FAIL + MISMATCHES + XTRA & goto error
if %ERRORLEVEL% EQU 13 echo OKCOPY + FAIL + MISMATCHES & goto error
if %ERRORLEVEL% EQU 12 echo FAIL + MISMATCHES & goto error
if %ERRORLEVEL% EQU 11 echo OKCOPY + FAIL + XTRA & goto error
if %ERRORLEVEL% EQU 10 echo FAIL + XTRA & goto error
if %ERRORLEVEL% EQU 9 echo OKCOPY + FAIL & goto error
if %ERRORLEVEL% EQU 8 echo FAIL & goto error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:show
code "%OUTPUT_PATH%"
IF %errorlevel% NEQ 0 GOTO error
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:check_next_arg
SHIFT
SET TARGET_INPUT=%~1
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%
GOTO done_with_it

:noclean
SET DO_NOT_CLEAN=1
echo DO NOT CLEAN
GOTO all

:allowxml
SET NO_XML_TRANSFORM=0
echo Enable XML Transform
GOTO all

:debug
SET Configuration=Debug
echo Configure as DEBUG
GOTO all

:uselocal
SET XSLT_CMD="%OUTPUT_PATH%\Results\Binary\BinaryDataDecoders.Xslt.Cli.exe"
SET USE_LOCAL=1
echo Local command instead of tool
GOTO all

:all
SHIFT 
SET TARGET_INPUT=%~1
GOTO top

:push
@echo off
SET /P NUGET_API_KEY=<%USERPROFILE%\BinaryDataDecoders.Nuget.Key
dotnet nuget push "%OUTPUT_PATH%\Nuget\*.nupkg" -k %NUGET_API_KEY% -s https://api.nuget.org/v3/index.json --skip-duplicate
SET NUGET_API_KEY=
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:help
echo.
echo Extension Options
echo.
echo	"uselocal"		= switch from dotnet tool to local command for xslt transform
echo	"debug"			= switch to DEBUG configuration
echo	"allowxml"		= switch to enable XML outputs from with transforms
echo	"noclean"		= skip 'otnet clean'
echo.
echo Step Chains
echo.
echo	"clean"			= clean build folders and outputs
echo	"build"			= build application code
echo	"test"			= run unit and simulation tests
echo	"pack"			= build nuget packages
echo	"publish"		= publish binary outputs
echo	"report"		= generate reports over test results
echo	"transform"		= use transformations to generate documentation
echo	"transform_xml"	= use transformations to generate documentation
echo	"wiki"			= copy generated documentation to docs\
echo	"show"			= launch visual studio code
echo.
echo Special Step Chains
echo.
echo	"all"			= start over from the top
echo	"push"			= deploy nuget packages to Nuget.org (not on by default)


goto done_with_it

:error
echo oopz
PAUSE

:done_with_it
popd
echo Finished - %BUILD_VERSION%
ENDLOCAL