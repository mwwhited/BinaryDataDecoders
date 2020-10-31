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

	<xsl:variable name="all-tests" select="//tt:TestRun/tt:TestDefinitions/tt:UnitTest/tt:TestMethod" />

	<xsl:template match="/">

		<xsl:text># Test Libraries</xsl:text>&cr;&cr;

		<xsl:variable name="code-bases" select="fn:distinct_values($all-tests/@codeBase)" />
		<xsl:for-each select="$code-bases">
			<xsl:sort select="."/>
			<xsl:variable name="code-base" select="." />
			<xsl:variable name="test-classes" select="fn:distinct_values($all-tests[@codeBase=$code-base]/@className)" />
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

				<xsl:variable name="test-methods" select="fn:distinct_values($all-tests[@codeBase=$code-base and @className=$test-class]/@name)" />
				<!--<xsl:message>
					<xsl:value-of select="$code-base"/>
					<xsl:text>|</xsl:text>
					<xsl:value-of select="$test-class"/>
					<xsl:text>|</xsl:text>
					<xsl:value-of select="count($test-methods)"/>
				</xsl:message>-->
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



		<xsl:apply-templates select="$tests" />&cr;
		&cr;

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
		<!--<xsl:message>
			<xsl:value-of select="$categories" />
		</xsl:message>-->
		<xsl:if test="$categories">
			<xsl:text>### Categories</xsl:text>&cr;&cr;
			<xsl:for-each select="$categories">
				<xsl:text>* </xsl:text><xsl:value-of select="." />&cr;
			</xsl:for-each>
			&cr;
		</xsl:if>

		<xsl:variable name="test-results" select="ancestor::tt:TestRun/tt:Results/tt:UnitTestResult[@testId=$test-id]" />
		<xsl:text>### Results</xsl:text>&cr;&cr;
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
