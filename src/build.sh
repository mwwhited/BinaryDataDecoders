#!/bin/bash 

export BUILD_CONFIGURATION=Release

export SANDBOX_PATH=..
export BUILD_PATH=$SAND_BOX/src
export BUILD_PROJECT=$BUILD_PATH/BinaryDataDecoders.sln
export OUTPUT_PATH=$SANDBOX_PATH/Publish
export TEST_RESULTS_PATH=$OUTPUT_PATH/TestResults
export DOCS_PATH=$OUTPUT_PATH/docs
export RESULTS_PATH=$OUTPUT_PATH/Results
export TEMPLATES_PATH=$SANDBOX_PATH/templates/reports

echo === git fetch ===
git fetch --prune

echo === GitVersion ===
dotnet tool install --local gitversion.tool
#export PATH="$PATH:/github/home/.dotnet/tools"
buildVersion=`dotnet gitversion /output json /showvariable FullSemVer`
echo GitVersion= $buildVersion
echo "::set-env name=buildVersion::$buildVersion"
  
echo === Clean ===
rm -rf "$OUTPUT_PATH"
dotnet clean "$BUILD_PROJECT"

echo === Restore ===
dotnet restore "$BUILD_PROJECT"

echo === Build ===
dotnet build "$BUILD_PROJECT" --configuration $BUILD_CONFIGURATION \
    --no-restore -p:Version=$buildVersion \
    "/bl:logfile=$OUTPUT_PATH/dotnet_build.binlog"

echo === Tests ===
for testProj in ./src/*.Tests/*.csproj; do
    echo ======= TEST! $testProj =======  
    testName=$(basename -s .csproj $testProj)
    echo ======= TEST! $testName =======  
    dotnet test "$testProj" --no-build --no-restore --nologo \
        --collect:"XPlat Code Coverage" \
        -r "$TEST_RESULTS_PATH" \
        --filter "TestCategory=Unit|TestCategory=Simulate" \
        -s "$BUILD_PATH/.runsettings" \
        /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true \
        --logger "trx;LogFileName=$testName.trx" 
done 

echo === Package ===
dotnet pack --no-build --no-restore "$BUILD_PROJECT" -o "$OUTPUT_PATH/Nuget" -p:PackageVersion=$buildVersion       

echo === Publish ===
dotnet publish --no-build --no-restore "$BUILD_PROJECT" -o "$RESULTS_PATH/Binary"

echo === Build Reports ===
dotnet tool install --local dotnet-reportgenerator-globaltool
dotnet reportgenerator "-reports:$TEST_RESULTS_PATH/**/coverage.cobertura.xml" "-targetDir:$RESULTS_PATH/Coverage" "-reportTypes:Xml" "-title:$BUILD_PROJECT - $buildVersion"

echo === Transform Reports ===
dotnet tool install --add-source "$OUTPUT_PATH/Nuget" --local BinaryDataDecoders.Xslt.Cli

ECHO ">>> BinaryDataDecoders.Xslt.Cli (TestResults) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/TestResultsToMarkdown.xslt" -i "$TEST_RESULTS_PATH/*.trx" -o "$DOCS_PATH/TestResults/*.md" -s "$SANDBOX_PATH"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (Coverage) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/CoverageToMarkdown.xslt" -i "$RESULTS_PATH/Coverage/*.xml" -o "$DOCS_PATH/Coverage/*.md"  -s "$SANDBOX_PATH"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Structured) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/XmlCommentsToStructuredXml.xslt" -i "$RESULTS_PATH/Binary/*.xml" -o "$RESULTS_PATH/Code/*.xml" -s "$SANDBOX_PATH"
ECHO ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Markdown) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/XmlCommentsToMarkdown.xslt" -i "$RESULTS_PATH/Code/*.xml" -o "$DOCS_PATH/Code/*.md" -s "$SANDBOX_PATH"

ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to Markdown) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/CSharpToMarkdown.xslt" -i "./**/*.cs" -o "$DOCS_PATH/SourceCode/*.md" -s "$SANDBOX_PATH" -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to Markdown) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/CSharpToMarkdown.xslt" -i "./**/*.vb" -o "$DOCS_PATH/SourceCode/*.md" -s "$SANDBOX_PATH" -x VB

ECHO ">>> BinaryDataDecoders.Xslt.Cli (CSharp to XML) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/ToXml.xslt" -i "./**/*.cs" -o "$RESULTS_PATH/SourceCode/*.xml" -s "$SANDBOX_PATH" -x CSharp
ECHO ">>> BinaryDataDecoders.Xslt.Cli (VB to XML) <<<"
dotnet bdd-xslt -t "$TEMPLATES_PATH/ToXml.xslt" -i "./**/*.vb" -o "$RESULTS_PATH/SourceCode/*.xml" -s "$SANDBOX_PATH" -x VB
