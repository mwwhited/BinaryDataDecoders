
@REM SET
@echo off

SET TestProject=BinaryDataDecoders.sln
SET Configuration=Debug

REM VisualStudioVersion=16.0
REM              VSAPPIDDIR=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\
REM SET SQLDBExtensionsRefPath=%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Professional\MSBuild\Microsoft\VisualStudio\v16.0\SSDT
SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT

dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL
rmdir /s/q ".\TestResults"
REM /Coverage/Reports
dotnet test %TestProject% --configuration %Configuration% --collect:"XPlat Code Coverage" -r .\TestResults --nologo --filter "TestCategory=Unit|TestCategory=Simulate" -s .runsettings
SET TEST_ERR=%ERRORLEVEL%
reportgenerator "-reports:.\TestResults\**\coverage.cobertura.xml" "-targetDir:.\TestResults\Coverage\Reports" -reportTypes:HtmlInline;Cobertura "-title:%TestProject% - (%USERNAME%)"
start ./TestResults/Coverage/Reports\index.html

ECHO TEST_ERR=%TEST_ERR%
IF %TEST_ERR%==0 (
	ECHO "No Errors :)"
	EXIT 0
)
PAUSE
