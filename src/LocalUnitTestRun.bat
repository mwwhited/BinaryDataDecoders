
@REM SET
@echo off

SET TARGET_INPUT=%~1

SET TestProject=BinaryDataDecoders.sln
SET Configuration=Release
SET OutputPath=..\Publish
SET TestOutput=TestResults

SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT

:top
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%

:fetch
echo "Git fetch"
git fetch --prune

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:clean
echo "Clean Packages"
dotnet clean "%TestProject%"
rmdir /s/q "%TestOutput%"
rmdir /s/q "%OutputPath%"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:restore
echo "Restore Packages"
dotnet restore "%TestProject%""

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:build
echo "Build Packages"
dotnet tool install --global gitversion.tool 2>NUL
FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)

dotnet build "%TestProject%" --configuration %Configuration% --no-restore /p:Version=%BUILD_VERSION%

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:test
echo "Run Tests"
FOR /D %%T IN (*.Tests) DO ^
dotnet test "%%T" --no-build --no-restore ^
--collect:"XPlat Code Coverage" -r "%TestOutput%" ^
--nologo --filter "TestCategory=Unit|TestCategory=Simulate" ^
-s .runsettings /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true ^
--logger "trx;LogFileName=%%T.trx"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:pack
echo "Pack Projects"
dotnet pack --no-build --no-restore "%TestProject%" -o "%OutputPath%/Nuget" -p:PackageVersion=%BUILD_VERSION%

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:publish
echo "Pack Projects"
dotnet publish --no-build --no-restore "%TestProject%" -o "%OutputPath%/Results/Binary"

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:report
echo "Build Reports"
dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL
reportgenerator "-reports:%TestOutput%\**\coverage.cobertura.xml" "-targetDir:%OutputPath%\Results\Coverage" "-reportTypes:Xml" "-title:%TestProject% - (%BUILD_VERSION%)"
REM "-reportTypes:HtmlInline;Badges;Xml;Cobertura"


IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:report_transform
echo "Transform Reports"
dotnet publish BinaryDataDecoders.Xslt.Cli -o "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli" --no-build --no-restore 

ECHO ">>> BinaryDataDecoders.Xslt.Cli (TestResults) <<<"
FOR %%T IN ("%TestOutput%\*.trx") DO "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\TestResultsToMarkdown.xslt" -i "%%T" -o "%OutputPath%\docs\TestResults\%%~nT\index.md" -s ".."
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Coverage) <<<"
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\CoverageToMarkdown.xslt" -i "%OutputPath%\Results\Coverage\*.xml" -o "%OutputPath%\docs\Coverage\*.md"  -s ".."
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Structured) <<<"
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\XmlCommentsToStructuredXml.xslt" -i "..\Publish\Results\Binary\*.xml" -o "..\Publish\Results\Code\*.xml" -s ".."
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Markdown) <<<"
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\XmlCommentsToMarkdown.xslt" -i "..\Publish\Results\Code\*.xml" -o "..\Publish\docs\Code\*.md" -s ".."

ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to Markdown) <<<"
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\CSharpToMarkdown.xslt" -i ".\**\*.cs" -o "..\Publish\docs\SourceCode\*.md" -s ".." -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to Markdown) <<<"
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\CSharpToMarkdown.xslt" -i ".\**\*.vb" -o "..\Publish\docs\SourceCode\*.md" -s ".." -x VB

IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

:show
code "%OutputPath%"
IF NOT "%TARGET_INPUT%"=="" GOTO check_next_arg

GOTO done_with_it

:all
SHIFT
SET TARGET_INPUT=%~1
GOTO top

:debug
SET Configuration=Debug

:check_next_arg
SHIFT
SET TARGET_INPUT=%~1
IF NOT "%TARGET_INPUT%"=="" GOTO %TARGET_INPUT%

:done_with_it
echo "fin!"