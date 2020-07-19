
@echo off

SET TestProject=BinaryDataDecoders.ExpressionCalculator.Tests.csproj

dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL
dotnet test %TestProject% --configuration Release --collect:"XPlat Code Coverage" -r .\TestResults --nologo -v d
REM -s .runsettings  --filter TestCategory:Unit  
reportgenerator "-reports:.\TestResults/**/coverage.cobertura.xml" "-targetDir:./TestResults/Coverage/Reports" -reportTypes:HtmlSummary;Cobertura "-title:%TestProject% - (%USERNAME%)"
start ./TestResults/Coverage/Reports\summary.html
