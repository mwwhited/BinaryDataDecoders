
@echo off

SET TestProject=BinaryDataDecoders.ExpressionCalculator.Tests.csproj

dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL
rmdir /s/q ".\TestResults"
REM /Coverage/Reports
dotnet test %TestProject% --configuration Release --collect:"XPlat Code Coverage" -r .\TestResults --nologo
REM -s .runsettings  --filter TestCategory:Unit  
reportgenerator "-reports:.\TestResults/**/coverage.cobertura.xml" "-targetDir:./TestResults/Coverage/Reports" -reportTypes:HtmlInline;Cobertura "-title:%TestProject% - (%USERNAME%)"
start ./TestResults/Coverage/Reports\index.html

exit
