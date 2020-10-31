<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	xmlns:fn="http://www.w3.org/2005/xpath-functions"
	
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	
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

	<xsl:template match="/">
		<!--<xsl:text># Test Libraries</xsl:text>&cr;&cr;

		<xsl:variable name="code-bases" select="fn:distinct_values(//tt:TestRun/tt:TestDefinitions/tt:UnitTest/tt:TestMethod/@codeBase)" />
		<xsl:for-each select="$code-bases">
			<xsl:variable name="test-assembly" select="ex-path:GetFileNameWithoutExtension(.)" />
			<xsl:text>* </xsl:text>
			<xsl:value-of select="$test-assembly"/>
			&cr;

		</xsl:for-each>
		&cr;
		&cr;-->

		<xsl:text># Test Run</xsl:text>&cr;&cr;
		<xsl:variable name="test-classes" select="//tt:TestRun/tt:TestDefinitions/tt:UnitTest/tt:TestMethod[not(@className=preceding::tt:TestMethod/@className)]/@className" />

		<xsl:for-each select="$test-classes">
			<xsl:variable name="test-assembly-path" select="../@codeBase" />
			<xsl:variable name="test-library" select="ex-path:GetFileNameWithoutExtension($test-assembly-path)" />
			<xsl:variable name="test-class-file" select="translate(concat($files/@outputPath, '/', . , '.md'),'\', '/')" />
			<xsl:variable name="test-class-file-ref" select="translate(concat(. , '.md'),'\', '/')" />
			<xsl:variable name="test-library-file" select="translate(concat($files/@outputPath, '/', $test-library, '.md'),'\', '/')" />
			<xsl:variable name="test-library-file-ref" select="translate(concat($test-library, '.md'),'\', '/')" />

			<xsl:variable name="throw-away">
				<xsl:call-template name="test-class">
					<xsl:with-param name="test-class-name" select="." />
					<xsl:with-param name="test-class-file" select="$test-class-file" />
				</xsl:call-template>
			</xsl:variable>

			<xsl:text>* [</xsl:text>
			<xsl:value-of select="."/>
			<xsl:text>](</xsl:text>
			<xsl:value-of select="$test-class-file-ref"/>
			<xsl:text>)</xsl:text>
			&cr;
		</xsl:for-each>

	</xsl:template>

	<xsl:template name="test-class">
		<xsl:param name="test-class-name" />
		<xsl:param name="test-class-file" />
		<xsl:variable name="test-report">
			<xsl:variable name="tests" select="ancestor::tt:TestRun/tt:TestDefinitions/tt:UnitTest[tt:TestMethod/@className=$test-class-name]" />
			<xsl:text>## </xsl:text><xsl:value-of select="." />&cr;
			&cr;
			<xsl:apply-templates select="$tests" />
		</xsl:variable>

		<xsl:value-of select="ex-file:WriteToFile($test-report, $test-class-file)" />
	</xsl:template>

	<xsl:template match="tt:UnitTest">
		<xsl:variable name="test-id" select="./@id" />
		<xsl:text>### </xsl:text><xsl:value-of select="./@name" />&cr;
		<xsl:text> Location: </xsl:text><xsl:value-of select="ex-path:GetFileName(./@storage)" />&cr;

		<xsl:variable name="targets" select="ex-trx:GetTestTargets(./tt:TestMethod)/o-trx:target" />

		<xsl:if test="targets">
			<xsl:text>#### Targets </xsl:text>&cr;
			<xsl:for-each select="$targets">
				<xsl:text> * </xsl:text><xsl:value-of select="@name" /><xsl:text>::</xsl:text><xsl:text>=</xsl:text><xsl:value-of select="@member" />&cr;
				<xsl:text>   * </xsl:text><xsl:value-of select="@assembly" /><xsl:text> => </xsl:text><xsl:text>=</xsl:text><xsl:value-of select="@namespace" />&cr;
			</xsl:for-each>
			&cr;
		</xsl:if>

		<xsl:variable name="test-results" select="ancestor::tt:TestRun/tt:Results/tt:UnitTestResult[@testId=$test-id]" />
		<xsl:text>| Result                   | Duration    | Test Name                                            |</xsl:text>&cr;
		<xsl:text>| :----------------------- | ----------: | :--------------------------------------------------- |</xsl:text>&cr;
		<xsl:apply-templates select="$test-results" />
		&cr;

	</xsl:template>

	<xsl:template match="tt:UnitTestResult">
		<xsl:variable name="test-output" select="./tt:Output" />
		<xsl:text>| </xsl:text>
		<xsl:choose>
			<xsl:when test="@outcome='Passed'">
				<xsl:text> ✔ Passed              </xsl:text>
			</xsl:when>
			<xsl:when test="@outcome='Failed'">
				<xsl:text> ❌ Failed             </xsl:text>
			</xsl:when>
			<xsl:when test="@outcome='NotExecuted'">
				<xsl:text> ⚠ Inconclusive       </xsl:text>
			</xsl:when>
			<xsl:otherwise>
				❓ <xsl:value-of select="substring(concat(./@outcome,'                    '),1,20)" />
			</xsl:otherwise>
		</xsl:choose>
		<xsl:text> | </xsl:text><xsl:value-of select="substring(./@duration,1,11)" />
		<xsl:text> | `</xsl:text>
		<xsl:choose>
			<xsl:when test="string-length(./@testName)&lt;60">
				<xsl:value-of select="substring(concat(./@testName,'                                                  '),1,50)" />
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="./@testName" />
			</xsl:otherwise>
		</xsl:choose>

		<xsl:text>` |</xsl:text>&cr;

		<xsl:apply-templates select="./tt:InnerResults/tt:UnitTestResult" />
	</xsl:template>

</xsl:stylesheet>
