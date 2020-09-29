
@REM SET
REM @echo off

SET TestProject=BinaryDataDecoders.sln
SET Configuration=Debug
SET OutputPath=..\Publish
SET TestOutput=TestResults

SET SQLDBExtensionsRefPath=%VSAPPIDDIR%\..\..\MSBuild\Microsoft\VisualStudio\v%VisualStudioVersion%\SSDT

echo "Git fetch"
git fetch --prune

:clean_plus
echo "Clean Packages"
dotnet clean "%TestProject%"
rmdir /s/q "%TestOutput%"
rmdir /s/q "%OutputPath%"

:restore_plus
echo "Restore Packages"
dotnet restore "%TestProject%""

:build
echo "Build Packages"
dotnet tool install --global gitversion.tool 2>NUL
FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)

dotnet build "%TestProject%" --configuration %Configuration% --no-restore /p:Version=%BUILD_VERSION%

:test_plus
echo "Run Tests"
FOR /D %%T IN (*.Tests) DO ^
dotnet test "%%T" --no-build --no-restore ^
--collect:"XPlat Code Coverage" -r "%TestOutput%" ^
--nologo --filter "TestCategory=Unit|TestCategory=Simulate" ^
-s .runsettings /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true ^
--logger "trx;LogFileName=%%T.trx"

:pack_plus
echo "Pack Projects"
dotnet pack --no-build --no-restore "%TestProject%" -o "%OutputPath%/Nuget"

:pack_plus
echo "Pack Projects"
dotnet publish --no-build --no-restore "%TestProject%" -o "%OutputPath%/Results/Binary"

:report_plus
echo "Build Reports"
dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL
reportgenerator "-reports:%TestOutput%\**\coverage.cobertura.xml" "-targetDir:%OutputPath%\Results\Coverage" "-reportTypes:Xml" "-title:%TestProject% - (%BUILD_VERSION%)"
REM "-reportTypes:HtmlInline;Badges;Xml;Cobertura"

dotnet publish BinaryDataDecoders.Xslt.Cli -o "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli" --no-build --no-restore 
FOR %%T IN ("%TestOutput%\*.trx") DO "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\TestResultsToMarkdown.xslt" -i "%%T" -o "%OutputPath%\docs\TestResults\%%~nT\index.md"
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\CoverageToMarkdown.xslt" -i "%OutputPath%\Results\Coverage\*.xml" -o "%OutputPath%\docs\Coverage\*.md" 
"%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\XmlCommentsToStructuredXml.xslt" -i "..\Publish\Results\Binary\*.xml" -o "..\Publish\Results\Code\*.xml" -s ".."
REM "%OutputPath%\Tools\BinaryDataDecoders.Xslt.Cli\BinaryDataDecoders.Xslt.Cli" -t "..\templates\reports\XmlCommentsToMarkdown.xslt" -i "..\Publish\Results\Code\*.xml" -o "..\Publish\docs\Code\*.md" -s ".."

:show_plus
code "%OutputPath%"
