<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	
	xmlns:fn="http://www.w3.org/2005/xpath-functions"
	
	xmlns:ex-path="bdd:ToolKit/PathExtensions"
	xmlns:o-path="bdd:ToolKit/PathExtensions:out"
	xmlns:ex-file="bdd:ToolKit/FileExtensions"
	xmlns:o-file="bdd:ToolKit/FileExtensions:out"
	xmlns:ex-env="bdd:ToolKit/EnvironmentExtensions"
	xmlns:o-env="bdd:ToolKit/EnvironmentExtensions:out"
	xmlns:ex-str="bdd:ToolKit/StringExtensions"
	xmlns:o-str="bdd:ToolKit/StringExtensions:out"

	xmlns:ex-trx="clr:BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions, BinaryDataDecoders.TestUtilities"
    xmlns:o-trx="clr:BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions, BinaryDataDecoders.TestUtilities:out"
	
	xmlns:ex-xsl="clr:BinaryDataDecoders.Xslt.Cli.XsltTransformer, BinaryDataDecoders.Xslt.Cli"
	>
	<xsl:output method="text" indent="no"/>
	<xsl:param name="files" />

	<xsl:variable name="all-tests" select="//tt:TestRun/tt:TestDefinitions/tt:UnitTest/tt:TestMethod" />

	<xsl:template match="/">

		<xsl:text># Test Libraries</xsl:text>&cr;&cr;

		<xsl:variable name="code-bases" select="fn:distinct-values($all-tests/@codeBase)" />
		<xsl:for-each select="$code-bases">
			<xsl:sort select="."/>
			<xsl:variable name="code-base" select="." />
			<xsl:variable name="test-classes" select="fn:distinct-values($all-tests[@codeBase=$code-base]/@className)" />
			<xsl:variable name="test-assembly" select="ex-path:GetFileNameWithoutExtension(.)" />
			<xsl:text>## </xsl:text>
			<xsl:value-of select="$test-assembly"/>
			&cr;&cr;

			<xsl:for-each select="$test-classes">
				<xsl:sort select="."/>
				<xsl:variable name="test-class" select="." />
				<xsl:variable name="test-class-name" select="substring(., string-length($test-assembly) + 2)" />
				<xsl:variable name="test-class-file" select="translate(concat($files/@outputPath, '/', $test-assembly, '/', $test-class-name, '.md'),'\', '/')" />
				<xsl:variable name="test-class-file-ref" select="translate(concat($test-assembly, '/', $test-class-name, '.md'),'\', '/')" />

				<xsl:variable name="test-report-results">
					<xsl:call-template name="test-class">
						<xsl:with-param name="test-class-name" select="$test-class" />
						<xsl:with-param name="test-class-file" select="$test-class-file" />
					</xsl:call-template>
				</xsl:variable>
				<xsl:variable name="output-content" select="ex-file:WriteToFile($test-report-results, $test-class-file)" />

				<xsl:text>* [</xsl:text>
				<xsl:value-of select="$test-class-name"/>
				<xsl:text>](</xsl:text>
				<xsl:value-of select="$test-class-file-ref"/>
				<xsl:text>)</xsl:text>
				&cr;

				<xsl:variable name="test-methods" select="fn:distinct-values($all-tests[@codeBase=$code-base and @className=$test-class]/@name)" />

				<xsl:for-each select="$test-methods">
					<xsl:sort select="."/>
					<xsl:variable name="test-method" select="." />
					<xsl:variable name="test-method-file-ref" select="translate(concat($test-class-file-ref, '#', $test-method),'\', '/')" />

					<xsl:text>  * [</xsl:text>
					<xsl:value-of select="$test-method"/>
					<xsl:text>](</xsl:text>
					<xsl:value-of select="$test-method-file-ref"/>
					<xsl:text>)</xsl:text>
					&cr;

				</xsl:for-each>
			</xsl:for-each>
		</xsl:for-each>
		&cr;
		&cr;

		<xsl:text>## Links</xsl:text>&cr;&cr;
		<xsl:text>* [Table of Contents](../TOC.md)</xsl:text>&cr;
	</xsl:template>

	<xsl:template name="test-class">
		<xsl:param name="test-class-name" />
		<xsl:param name="test-class-file" />

		<xsl:variable name="tests" select="$all-tests[@className=$test-class-name]/.." />
		<xsl:text># </xsl:text><xsl:value-of select="." />&cr;
		&cr;

		<xsl:apply-templates select="$tests" />

		<xsl:text>## Links</xsl:text>&cr;&cr;
		<xsl:text>* [Back to Summary](../Summary.md)</xsl:text>&cr;
		<xsl:text>* [Table of Contents](../../TOC.md)</xsl:text>&cr;

	</xsl:template>

	<xsl:template match="tt:UnitTest">
		<xsl:variable name="test-id" select="./@id" />
		<xsl:text>## </xsl:text><xsl:value-of select="./@name" />&cr;&cr;

		<xsl:variable name="targets" select="ex-trx:GetTestTargets(./tt:TestMethod)/o-trx:target" />
		<xsl:if test="$targets">
			<xsl:text>### Targets</xsl:text>&cr;&cr;
			<xsl:for-each select="$targets">
				<xsl:text>* </xsl:text><xsl:value-of select="@namespace" /><xsl:text>::</xsl:text><xsl:value-of select="@name" /><xsl:text>::</xsl:text><xsl:value-of select="@member" />&cr;
				<xsl:text>  * </xsl:text><xsl:value-of select="@assembly" />&cr;
			</xsl:for-each>
			&cr;
		</xsl:if>

		<xsl:variable name="categories" select="tt:TestCategory/tt:TestCategoryItem/@TestCategory" />
		<xsl:if test="$categories">
			<xsl:text>### Categories</xsl:text>&cr;&cr;
			<xsl:for-each select="$categories">
				<xsl:text>* </xsl:text><xsl:value-of select="." />&cr;
			</xsl:for-each>
			&cr;
		</xsl:if>

		<xsl:variable name="test-results" select="ancestor::tt:TestRun/tt:Results/tt:UnitTestResult[@testId=$test-id]" />

		<xsl:text>### Results</xsl:text>&cr;&cr;

		<xsl:choose>
			<xsl:when test="$test-results[tt:InnerResults]">
				<xsl:text>| Outcome              | Duration    | Test Name                                            |</xsl:text>&cr;
				<xsl:text>| :------------------- | ----------: | :--------------------------------------------------- |</xsl:text>&cr;
				<xsl:apply-templates select="$test-results" mode="data-test-method" />
				&cr;
			</xsl:when>
			<xsl:otherwise>
				<xsl:apply-templates select="$test-results" mode="test-method" />
			</xsl:otherwise>
		</xsl:choose>

	</xsl:template>
	<xsl:template match="@outcome">
		<xsl:choose>
			<xsl:when test=".='Passed'">
				<xsl:text>✔ Passed</xsl:text>
			</xsl:when>
			<xsl:when test=".='Failed'">
				<xsl:text>❌ Failed</xsl:text>
			</xsl:when>
			<xsl:when test=".='NotExecuted'">
				<xsl:text>⚠ Inconclusive</xsl:text>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="concat('❓ ', .)" />
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template match="tt:UnitTestResult" mode="test-method">

		<xsl:text>* Outcome: </xsl:text><xsl:apply-templates  select="@outcome" />&cr;
		<xsl:text>* Duration: </xsl:text><xsl:value-of  select="substring(./@duration,1,11)" />&cr;
		&cr;

		<xsl:if test="tt:Output/tt:StdOut">
			<xsl:text>#### Standard Out</xsl:text>&cr;&cr;
			<xsl:text>```</xsl:text>&cr;
			<xsl:value-of select="tt:Output/tt:StdOut" disable-output-escaping="yes" />&cr;
			<!--<xsl:value-of select="ex-str:Unescape(tt:Output/tt:StdOut)" disable-output-escaping="yes" />&cr;-->
			<xsl:text>```</xsl:text>&cr;
			&cr;
		</xsl:if>

		<xsl:if test="tt:Output/tt:StdErr">
			<xsl:text>#### Error Out</xsl:text>&cr;&cr;
			<xsl:text>```</xsl:text>&cr;
			<xsl:value-of  select="tt:Output/tt:StdErr" disable-output-escaping="yes" />&cr;
			<xsl:text>```</xsl:text>&cr;
			&cr;
		</xsl:if>

	</xsl:template>

	<xsl:template match="tt:UnitTestResult" mode="data-test-method">
		<xsl:variable name="test-output" select="./tt:Output" />
		<xsl:variable name="outcome">
			<xsl:apply-templates  select="@outcome" />
		</xsl:variable>

		<xsl:text>| </xsl:text>
		<xsl:value-of select="ex-str:PadRight($outcome, 20)"/>
		<xsl:text> | </xsl:text>
		<xsl:value-of select="substring(./@duration,1,11)" />
		<xsl:text> | </xsl:text>
		<xsl:value-of select="ex-str:PadRight(concat('`',@testName,'`'), 52)" />
		<xsl:text> |</xsl:text>&cr;

		<xsl:apply-templates select="./tt:InnerResults/tt:UnitTestResult" mode="data-test-method" />
	</xsl:template>

</xsl:stylesheet>
