<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	
	xmlns:ex-path="oobdev://BinaryDataDecoders/ToolKit/v1/PathExtensions"
	xmlns:o-path="oobdev://BinaryDataDecoders/ToolKit/v1/PathExtensions:out"	
	xmlns:ex-file="oobdev://BinaryDataDecoders/ToolKit/v1/FileExtensions"
	xmlns:o-file="oobdev://BinaryDataDecoders/ToolKit/v1/FileExtensions:out"	
	xmlns:ex-env="oobdev://BinaryDataDecoders/ToolKit/v1/EnvironmentExtensions"
	xmlns:o-env="oobdev://BinaryDataDecoders/ToolKit/v1/EnvironmentExtensions:out"
	xmlns:ex-str="oobdev://BinaryDataDecoders/ToolKit/v1/StringExtensions"
	xmlns:o-str="oobdev://BinaryDataDecoders/ToolKit/v1/StringExtensions:out"

	xmlns:ex-trx="clr:BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions, BinaryDataDecoders.TestUtilities"
    xmlns:o-trx="clr:BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions, BinaryDataDecoders.TestUtilities:out"
	
	xmlns:ex-xsl="clr:BinaryDataDecoders.Xslt.Cli.XsltTransformer, BinaryDataDecoders.Xslt.Cli"
	>
	<xsl:output method="text" indent="no"/>

	<xsl:template match="/">
		<xsl:text># Test Run - </xsl:text><xsl:value-of select="tt:TestRun/@name" />&cr;
		&cr;
		<xsl:text>Run Time - </xsl:text>
		<xsl:value-of select="tt:TestRun/tt:Times/@start" />
		<xsl:text> to </xsl:text>
		<xsl:value-of select="tt:TestRun/tt:Times/@finish" />
		&cr;&cr;

		<xsl:variable name="test-classes" select="tt:TestRun/tt:TestDefinitions/tt:UnitTest/tt:TestMethod[not(@className=preceding::tt:TestMethod/@className)]/@className" />

		<xsl:for-each select="$test-classes">
			<xsl:variable name="test-class-name" select="." />
			<xsl:variable name="test-report">
				<xsl:variable name="tests" select="/tt:TestRun/tt:TestDefinitions/tt:UnitTest[tt:TestMethod/@className=$test-class-name]" />
				<xsl:text>## </xsl:text><xsl:value-of select="." />&cr;
				&cr;
				<xsl:apply-templates select="$tests" />
			</xsl:variable>

			<xsl:value-of select="ex-file:WriteToFile($test-report, concat($test-class-name, '.md'))" />
		</xsl:for-each>
		<xsl:if test="not($test-classes)">
			<xsl:text>## No Test Results Found</xsl:text>&cr;
		</xsl:if>

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

		<!--
		<xsl:text>Categories: </xsl:text>
		<xsl:for-each select="tt:TestCategory/tt:TestCategoryItem/@TestCategory">
			<xsl:value-of select="." />
			<xsl:if test="not(last())">
				<xsl:text>, </xsl:text>
			</xsl:if>
		</xsl:for-each>&cr;
		&cr;
		-->

		<xsl:variable name="test-results" select="/tt:TestRun/tt:Results/tt:UnitTestResult[@testId=$test-id]" />
		<xsl:text>| Result                   | Duration         | Test Name                                          |</xsl:text>&cr;
		<xsl:text>| :----------------------- | ---------------: | :--------------------------------------------------- |</xsl:text>&cr;
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
		<xsl:text> | </xsl:text><xsl:value-of select="./@duration" />
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
