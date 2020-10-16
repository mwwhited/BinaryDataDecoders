#!/bin/sh 
#-v 

BUILD_CONFIGURATION=Release

SANDBOX_PATH=..
BUILD_PATH=$SANDBOX_PATH/src
BUILD_PROJECT=$BUILD_PATH/BinaryDataDecoders.sln
OUTPUT_PATH=$SANDBOX_PATH/Publish
TEST_RESULTS_PATH=$OUTPUT_PATH/TestResults
DOCS_PATH=$OUTPUT_PATH/docs
RESULTS_PATH=$OUTPUT_PATH/Results
TEMPLATES_PATH=$SANDBOX_PATH/templates/reports

fetch() {
	echo === git fetch ===
	git fetch --prune
}

version() {
	echo === GitVersion ===
	dotnet tool install --local gitversion.tool
	#export PATH="$PATH:/github/home/.dotnet/tools"
	buildVersion=`dotnet gitversion /output json /showvariable FullSemVer`
	echo GitVersion= $buildVersion
	echo "::set-env name=buildVersion::$buildVersion"
}

clean() {  
	echo === Clean ===
	rm -rf "$OUTPUT_PATH"
	dotnet clean "$BUILD_PROJECT"
}

restore() {
	echo === Restore ===
	dotnet restore "$BUILD_PROJECT"
}

build() {
	echo === Build $BUILD_PROJECT ===
	dotnet build "$BUILD_PROJECT" --configuration $BUILD_CONFIGURATION --no-restore -p:Version=$buildVersion "/bl:logfile=$OUTPUT_PATH/dotnet_build.binlog"
}

test() {
	echo === Tests ===
	for testProj in $BUILD_PATH/*.Tests/*.csproj; do
	    testName=$(basename -s .csproj $testProj)
	    echo ======= TEST! $testName: $testProj =======  
	    dotnet test "$testProj" \
	    	 --configuration $BUILD_CONFIGURATION \
	    	--no-build --no-restore --nologo \
	        --collect:"XPlat Code Coverage" \
	        -r "$TEST_RESULTS_PATH" \
	        --filter "TestCategory=Unit|TestCategory=Simulate" \
	        -s "$BUILD_PATH/.runsettings" \
	        /p:CollectCoverage=true /p:CopyLocalLockFileAssemblies=true \
	        --logger "trx;LogFileName=$testName.trx" 
	done 
}

pack() {
	echo === Package ===
	dotnet pack "$BUILD_PROJECT" --configuration $BUILD_CONFIGURATION --no-build --no-restore -o "$OUTPUT_PATH/Nuget" -p:PackageVersion=$buildVersion       
}

publish() {
	echo === Publish ===
	dotnet publish "$BUILD_PROJECT" --configuration $BUILD_CONFIGURATION  --no-build --no-restore -o "$RESULTS_PATH/Binary"
}

report() {
	echo === Build Reports ===
	dotnet tool install --local dotnet-reportgenerator-globaltool
	dotnet reportgenerator "-reports:$TEST_RESULTS_PATH/**/coverage.cobertura.xml" "-targetDir:$RESULTS_PATH/Coverage" "-reportTypes:Xml" "-title:$BUILD_PROJECT - $buildVersion"
}

transform() {
	echo === Transform Reports ===
	dotnet tool install --add-source "$OUTPUT_PATH/Nuget" --local BinaryDataDecoders.Xslt.Cli

	echo ">>> BinaryDataDecoders.Xslt.Cli (TestResults) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/TestResultsToMarkdown.xslt" -i "$TEST_RESULTS_PATH/*.trx" -o "$DOCS_PATH/TestResults/*.md" -s "$SANDBOX_PATH"
	echo ">>> BinaryDataDecoders.Xslt.Cli (Coverage) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/CoverageToMarkdown.xslt" -i "$RESULTS_PATH/Coverage/*.xml" -o "$DOCS_PATH/Coverage/*.md"  -s "$SANDBOX_PATH"
	echo ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Structured) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/XmlCommentsToStructuredXml.xslt" -i "$RESULTS_PATH/Binary/*.xml" -o "$RESULTS_PATH/Code/*.xml" -s "$SANDBOX_PATH"
	echo ">>> BinaryDataDecoders.Xslt.Cli (XmlComments to Markdown) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/XmlCommentsToMarkdown.xslt" -i "$RESULTS_PATH/Code/*.xml" -o "$DOCS_PATH/Code/*.md" -s "$SANDBOX_PATH"

	echo ">>> BinaryDataDecoders.Xslt.Cli (CSharp to Markdown) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/CSharpToMarkdown.xslt" -i "./**/*.cs" -o "$DOCS_PATH/SourceCode/*.md" -s "$SANDBOX_PATH" -x CSharp
	echo ">>> BinaryDataDecoders.Xslt.Cli (VB to Markdown) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/CSharpToMarkdown.xslt" -i "./**/*.vb" -o "$DOCS_PATH/SourceCode/*.md" -s "$SANDBOX_PATH" -x VB

	echo ">>> BinaryDataDecoders.Xslt.Cli (CSharp to XML) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/ToXml.xslt" -i "./**/*.cs" -o "$RESULTS_PATH/SourceCode/*.xml" -s "$SANDBOX_PATH" -x CSharp
	echo ">>> BinaryDataDecoders.Xslt.Cli (VB to XML) <<<"
	dotnet bdd-xslt -t "$TEMPLATES_PATH/ToXml.xslt" -i "./**/*.vb" -o "$RESULTS_PATH/SourceCode/*.xml" -s "$SANDBOX_PATH" -x VB
}

fetch
version
clean
restore
build
test
pack
publish
report
transform

echo "fin!"
