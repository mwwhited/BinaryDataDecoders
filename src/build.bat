
@echo off

SETLOCAL
SET TARGET_INPUT=%~1

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

REM pause

pushd
REM PAUSE

echo "Git fetch"
git fetch --prune
dotnet tool install --local gitversion.tool
dotnet tool update gitversion.tool
FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)
echo "Building Version=%BUILD_VERSION%"

:top
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%

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
dotnet tool uninstall BinaryDataDecoders.Xslt.Cli --local
dotnet tool install --add-source "%OUTPUT_PATH%\Nuget" --local BinaryDataDecoders.Xslt.Cli --version %BUILD_VERSION% --no-cache
dotnet tool update BinaryDataDecoders.Xslt.Cli --version %BUILD_VERSION% --no-cache

ECHO ">>> BinaryDataDecoders.Xslt.Cli (TestResults) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\TestResultsToMarkdown.xslt" -i "%TEST_RESULTS_PATH%\*.trx" -o "%DOCS_PATH%\TestResults\*.md" -s "%SANDBOX_PATH%"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Coverage) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\CoverageToMarkdown.xslt" -i "%RESULTS_PATH%\Coverage\*.xml" -o "%DOCS_PATH%\Coverage\*.md"  -s "%SANDBOX_PATH%"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Structured) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\XmlCommentsToStructuredXml.xslt" -i "%RESULTS_PATH%\Binary\*.xml" -o "%RESULTS_PATH%\Code\*.xml" -s "%SANDBOX_PATH%"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\XmlCommentsToMarkdown.xslt" -i "%RESULTS_PATH%\Code\*.xml" -o "%DOCS_PATH%\Code\*.md" -s "%SANDBOX_PATH%"

ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\CSharpToMarkdown.xslt" -i "%BUILD_PATH%\**\*.cs" -o "%DOCS_PATH%\SourceCode\*.md" -s "%SANDBOX_PATH%" -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\CSharpToMarkdown.xslt" -i "%BUILD_PATH%\**\*.vb" -o "%DOCS_PATH%\SourceCode\*.md" -s "%SANDBOX_PATH%" -x VB

ECHO ">>> BinaryDataDecoders.Xslt.Cli (Docs to Markdown) <<<"
dotnet bdd-xslt -t "%TEMPLATES_PATH%\PathToMarkdown.xslt" -i "%DOCS_PATH%" -o "%DOCS_PATH%\TOC.md" -s "%SANDBOX_PATH%" -x Path

REM ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to XML) <<<"
REM dotnet bdd-xslt -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%BUILD_PATH%\**\*.cs" -o "%RESULTS_PATH%\SourceCode\*.xml" -s "%SANDBOX_PATH%" -x CSharp
REM ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to XML) <<<"
REM dotnet bdd-xslt -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%BUILD_PATH%\**\*.vb" -o "%RESULTS_PATH%\SourceCode\*.xml" -s "%SANDBOX_PATH%" -x VB
REM ECHO ">>> BinaryDataDecoders.Xslt.Cli (Docs to XML) <<<"
REM dotnet bdd-xslt -t "%TEMPLATES_PATH%\ToXml.xslt" -i "%DOCS_PATH%" -o "%RESULTS_PATH%\Path.xml" -s "%SANDBOX_PATH%" -x Path

dotnet tool uninstall BinaryDataDecoders.Xslt.Cli --local
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:wiki
REM pushd
echo "Post Wiki"
REM CD /d "%WIKI_PATH%"
REM git checkout master
REM git pull
robocopy /MIR "%DOCS_PATH%" "%WIKI_PATH%"
REM git add .
REM git push
REM popd
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
popd
ENDLOCAL
echo "fin!"