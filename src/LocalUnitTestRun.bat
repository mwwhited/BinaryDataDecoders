
@REM SET
REM @echo off

SET TestProject=BinaryDataDecoders.sln
SET Configuration=Debug
SET OutputPath=..\Publish
SET TestOutput=TestResults

SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT

echo "Install Report Generator"
dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL

rmdir /s/q "%TestOutput%"
rmdir /s/q "%OutputPath%"

mkdir "%OutputPath%\Nuget"
mkdir "%OutputPath%\Coverage"
mkdir "%OutputPath%\Results"
mkdir "%OutputPath%\Documents"
mkdir "%OutputPath%\Tools"

echo "Git fetch"
git fetch --prune

echo "Clean Packages"
dotnet clean "%TestProject%"

echo "Restore Packages"
dotnet restore "%TestProject%""

echo "Build Packages"
dotnet build "%TestProject%" --configuration %Configuration% --no-restore

echo "Run Tests"
dotnet test "%TestProject%" --no-build --no-restore --collect:"XPlat Code Coverage" -r "%TestOutput%" --nologo --filter "TestCategory=Unit|TestCategory=Simulate" -s .runsettings
REM --logger trx
SET TEST_ERR=%ERRORLEVEL%
reportgenerator "-reports:%TestOutput%\**\coverage.cobertura.xml" "-targetDir:%TestOutput%\Coverage\Reports" "-reportTypes:HtmlInline" "-title:%TestProject% - (%USERNAME%)"
REM start "%TestOutput%\Coverage\Reports\index.html" ;PngChart;Xml;Badges

REM echo "Pack Projects"
REM dotnet pack --no-build --no-restore "%TestProject%" -o "%OutputPath%/Nuget"

REM echo "Output Test Reports"
REM copy "%TestOutput%\Coverage\Reports\*.html" "%OutputPath%\Coverage" /Y
REM copy "%TestOutput%\Coverage\Reports\*.xml" "%OutputPath%\Coverage" /Y
REM copy "%TestOutput%\Coverage\Reports\*.png" "%OutputPath%\Coverage" /Y  
REM copy "%TestOutput%\*.trx" "%OutputPath%\Results" /Y

echo "Build Reports"
dotnet publish BinaryDataDecoders.Xslt.Cli -o "%OutputPath%\Tools" --no-build --no-restore 
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\TestResultsToMarkdown.xslt" -i "%TestOutput%\TestResult.trx" -o "%OutputPath%\docs\TestResults\index.md"


ECHO TEST_ERR=%TEST_ERR%
IF %TEST_ERR%==0 (
	ECHO "No Errors :)"
	REM EXIT 0
)
REM Pause
