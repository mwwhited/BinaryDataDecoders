
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
mkdir "%OutputPath%\Results"
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
FOR /D %%T IN (*.Tests) DO ^
dotnet test "%%T" --no-build --no-restore ^
--collect:"XPlat Code Coverage" -r "%TestOutput%" ^
--nologo --filter "TestCategory=Unit|TestCategory=Simulate" ^
-s .runsettings /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true ^
--logger "trx;LogFileName=%%T.trx"


SET TEST_ERR=%ERRORLEVEL%
reportgenerator "-reports:%TestOutput%\**\coverage.cobertura.xml" "-targetDir:%OutputPath%\docs\Coverage" "-reportTypes:HtmlInline;Badges" "-title:%TestProject% - (%USERNAME%)"
REM start "%TestOutput%\Coverage\Reports\index.html" ;PngChart;Xml;Badges

echo "Pack Projects"
dotnet pack --no-build --no-restore "%TestProject%" -o "%OutputPath%/Nuget"

echo "Build Reports"
dotnet publish BinaryDataDecoders.Xslt.Cli -o "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli" --no-build --no-restore 
FOR %%T IN ("%TestOutput%\*.trx") DO "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\TestResultsToMarkdown.xslt" -i "%%T" -o "%OutputPath%\docs\TestResults\%%~nT\index.md"

ECHO TEST_ERR=%TEST_ERR%
IF %TEST_ERR%==0 (
	ECHO "No Errors :)"
	REM EXIT 0
)
REM Pause
