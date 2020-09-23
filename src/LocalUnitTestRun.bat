
@REM SET
@echo off

SET TestProject=BinaryDataDecoders.sln
SET Configuration=Debug
SET OutputPath=Publish

SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT

echo "Install Report Generator"
dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL

rmdir /s/q ".\TestResults"
rmdir /s/q "%OutputPath%"

echo "Git fetch"
git fetch --prune

echo "Clean Packages"
dotnet clean "%TestProject%"

echo "Restore Packages"
dotnet restore "%TestProject%""

echo "Build Packages"
dotnet build "%TestProject%" --configuration %Configuration% --no-restore

echo "Run Tests"
dotnet test "%TestProject%" --no-build --no-restore --collect:"XPlat Code Coverage" -r .\TestResults --nologo --filter "TestCategory=Unit|TestCategory=Simulate" -s .runsettings
SET TEST_ERR=%ERRORLEVEL%
reportgenerator "-reports:.\TestResults\**\coverage.cobertura.xml" "-targetDir:.\TestResults\Coverage\Reports" -reportTypes:HtmlInline;Cobertura "-title:%TestProject% - (%USERNAME%)"
start ./TestResults/Coverage/Reports\index.html

echo "Pack Projects"
dotnet pack --no-build --no-restore "%TestProject%"  -o "%OutputPath%/Nuget"

ECHO TEST_ERR=%TEST_ERR%
IF %TEST_ERR%==0 (
	ECHO "No Errors :)"
	REM EXIT 0
)
PAUSE
