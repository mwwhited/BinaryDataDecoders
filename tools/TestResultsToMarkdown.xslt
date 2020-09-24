<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	>
	<xsl:output method="text" indent="no"/>

	<xsl:template match="/">
		<xsl:text># Test Run - </xsl:text><xsl:value-of select="tt:TestRun/@name" />&cr;&cr;
		<xsl:text>Run Time - </xsl:text>
		<xsl:value-of select="tt:TestRun/tt:Times/@start" />
		<xsl:text> to </xsl:text>
		<xsl:value-of select="tt:TestRun/tt:Times/@finish" />
		&cr;&cr;

		<xsl:variable name="test-classes" select="tt:TestRun/tt:TestDefinitions/tt:UnitTest/tt:TestMethod[not(@className=preceding::tt:TestMethod/@className)]/@className" />

		<xsl:for-each select="$test-classes">
			<xsl:variable name="test-class-name" select="." />
			<xsl:variable name="tests" select="/tt:TestRun/tt:TestDefinitions/tt:UnitTest[tt:TestMethod/@className=$test-class-name]" />
			<xsl:text>## </xsl:text><xsl:value-of select="." />&cr;&cr;

			<xsl:apply-templates select="$tests" />
		</xsl:for-each>

	</xsl:template>

	<xsl:template match="tt:UnitTest">
		<xsl:variable name="test-id" select="./@id" />
		<xsl:text>### </xsl:text><xsl:value-of select="./@name" />
		<!--<xsl:text> (</xsl:text>
		<xsl:value-of select="./tt:TestMethod/@name" />
		<xsl:text>)</xsl:text>-->
		&cr;&cr;
		<xsl:text>Categories: </xsl:text>
		<xsl:for-each select="tt:TestCategory/tt:TestCategoryItem/@TestCategory">
			<xsl:value-of select="." />
			<xsl:if test="not(last())">
				<xsl:text>, </xsl:text>
			</xsl:if>
		</xsl:for-each>&cr;
		&cr;

		<xsl:variable name="test-results" select="/tt:TestRun/tt:Results/tt:UnitTestResult[@testId=$test-id]" />
		<xsl:apply-templates select="$test-results" />

		&cr;

	</xsl:template>

	<xsl:template match="tt:UnitTestResult">
		<xsl:variable name="test-output" select="./tt:Output" />
		<xsl:text>#### </xsl:text><xsl:value-of select="./@testName" />&cr;&cr;

		<xsl:text> * Result: </xsl:text><xsl:value-of select="./@outcome" />&cr;
		<xsl:if test="./@resultType">
			<xsl:text> * Type: </xsl:text><xsl:value-of select="./@resultType" />&cr;
		</xsl:if>
		<xsl:text> * Duration: </xsl:text><xsl:value-of select="./@duration" />&cr;

		<xsl:if test="$test-output">

			<xsl:for-each select="$test-output/*">
				&cr;
				<xsl:text>```</xsl:text>
				<xsl:choose>
					<xsl:when test="local-name()='StdOut'">
						<xsl:text>Standard-Out</xsl:text>
					</xsl:when>
					<xsl:when test="local-name()='StdErr'">
						<xsl:text>Standard-Error</xsl:text>
					</xsl:when>
					<xsl:when test="local-name()='ErrorInfo'">
						<xsl:text>Exception-Message</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="local-name()" />
					</xsl:otherwise>
				</xsl:choose>
				&cr;
				<xsl:choose>
					<xsl:when test="./tt:Message">
						<xsl:value-of select="./tt:Message" />&cr;
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="." />&cr;
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>```</xsl:text>&cr;
			</xsl:for-each>
		</xsl:if>

		<xsl:apply-templates select="./tt:InnerResults/tt:UnitTestResult" />
	</xsl:template>

	<!--<xsl:template match="/persons">
		<root>
			<xsl:apply-templates select="person"/>
		</root>
	</xsl:template>

	<xsl:template match="person">
		<name username="{@username}">
			<xsl:value-of select="name" />
		</name>
	</xsl:template>-->

</xsl:stylesheet>
