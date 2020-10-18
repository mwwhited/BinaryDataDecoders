
@echo off

SETLOCAL
SET TARGET_INPUT=%~1

SET Configuration=Release

SET SANDBOX_PATH=..
SET BUILD_PATH=%SANDBOX_PATH%\src
SET BUILD_PROJECT=%BUILD_PATH%\BinaryDataDecoders.sln
SET OUTPUT_PATH=%SANDBOX_PATH%\Publish
SET TEST_RESULTS_PATH=%OUTPUT_PATH%\TestResults
SET DOCS_PATH=%OUTPUT_PATH%\docs
SET RESULTS_PATH=%OUTPUT_PATH%\Results
SET TEMPLATES_PATH=%SANDBOX_PATH%\templates\reports

SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT
SET VsInstallRoot=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional
 
:top
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%

:fetch
echo "Git fetch"
git fetch --prune

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:clean
IF "%DO_NOT_CLEAN%"=="1" GOTO skip_clean
echo "Clean Packages"
dotnet clean "%BUILD_PROJECT%"
rmdir /s/q "%OUTPUT_PATH%"
:skip_clean
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:restore
echo "Restore Packages"
dotnet restore "%BUILD_PROJECT%""

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:build
echo "Build Packages"
dotnet tool install --local gitversion.tool
dotnet tool update gitversion.tool

FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)

REM https://github.com/laurenprinn/MSBuildStructuredLog
dotnet build "%BUILD_PROJECT%" --configuration %Configuration% --no-restore /p:Version=%BUILD_VERSION% "/bl:logfile=%OUTPUT_PATH%\dotnet_build.binlog"
REM "/flp:v=detailed;logfile=%OUTPUT_PATH%\dotnet_build.binlog"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:test
echo "Run Tests"
FOR /D %%T IN ("%BUILD_PATH%\*.Tests") DO ^
dotnet test "%%T" --no-build --no-restore ^
--collect:"XPlat Code Coverage" -r "%TEST_RESULTS_PATH%" ^
--nologo --filter "TestCategory=Unit|TestCategory=Simulate" ^
-s .runsettings /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true ^
--logger "trx;LogFileName=%%~nxT.trx"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:pack
echo "Pack Projects"
dotnet pack "%BUILD_PROJECT%" --configuration %Configuration% --no-build --no-restore -o "%OUTPUT_PATH%\Nuget" -p:PackageVersion=%BUILD_VERSION%

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:publish
echo "Pack Projects"
dotnet publish "%BUILD_PROJECT%" --configuration %Configuration% --no-build --no-restore -o "%RESULTS_PATH%\Binary"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:report
echo "Build Reports"
dotnet tool install --local dotnet-reportgenerator-globaltool
dotnet tool update dotnet-reportgenerator-globaltool
dotnet reportgenerator "-reports:%TEST_RESULTS_PATH%\**\coverage.cobertura.xml" "-targetDir:%RESULTS_PATH%\Coverage" "-reportTypes:Xml" "-title:%BUILD_PROJECT% - (%BUILD_VERSION%)"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:transform
echo "Transform Reports"
dotnet tool install --add-source "%OUTPUT_PATH%\Nuget" --local BinaryDataDecoders.Xslt.Cli --version $buildVersion
dotnet tool update BinaryDataDecoders.Xslt.Cli --version $buildVersion

ECHO ">>> BinaryDataDecoders.Xslt.Cli (TestResults) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\TestResultsToMarkdown.xslt" -i "%TEST_RESULTS_PATH%\*.trx" -o "%DOCS_PATH%\TestResults\*.md" -s "%SANDBOX_PATH%"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Coverage) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\CoverageToMarkdown.xslt" -i "%RESULTS_PATH%\Coverage\*.xml" -o "%DOCS_PATH%\Coverage\*.md"  -s "%SANDBOX_PATH%"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Structured) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\XmlCommentsToStructuredXml.xslt" -i "%RESULTS_PATH%\Binary\*.xml" -o "%RESULTS_PATH%\Code\*.xml" -s "%SANDBOX_PATH%"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\XmlCommentsToMarkdown.xslt" -i "%RESULTS_PATH%\Code\*.xml" -o "%DOCS_PATH%\Code\*.md" -s "%SANDBOX_PATH%"

ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\CSharpToMarkdown.xslt" -i ".\**\*.cs" -o "%DOCS_PATH%\SourceCode\*.md" -s "%SANDBOX_PATH%" -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\CSharpToMarkdown.xslt" -i ".\**\*.vb" -o "%DOCS_PATH%\SourceCode\*.md" -s "%SANDBOX_PATH%" -x VB

ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to XML) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\ToXml.xslt" -i ".\**\*.cs" -o "%RESULTS_PATH%\SourceCode\*.xml" -s "%SANDBOX_PATH%" -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to XML) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\ToXml.xslt" -i ".\**\*.vb" -o "%RESULTS_PATH%\SourceCode\*.xml" -s "%SANDBOX_PATH%" -x VB

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:show
code "%OUTPUT_PATH%"
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

GOTO done_with_it

:noclean
SET DO_NOT_CLEAN=1
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

:debug
SET Configuration=Debug

:check_next_arg
SHIFT
SET TARGET_INPUT=%~1
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%

:done_with_it
ENDLOCAL
echo "fin!"