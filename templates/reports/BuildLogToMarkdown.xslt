<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
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
		<xsl:text># Build Log</xsl:text>&cr;&cr;
		<xsl:message>
			<xsl:text>???</xsl:text>
			<xsl:value-of select="count($files)"/>
			<xsl:text>???</xsl:text>
			<xsl:value-of select="count($files/@*)"/>
			<xsl:text>???</xsl:text>
			&cr;
			<xsl:for-each select="$files/*">
				<xsl:copy-of select="."/>
				&cr;
			</xsl:for-each>
		</xsl:message>
		
		<xsl:apply-templates select="//CscTask//Folder/Warning | //VscTask//Folder/Warning" />
		&cr;
	</xsl:template>

	<xsl:template match="Warning">
		<w>
		<xsl:message>
			<xsl:value-of select="@Text"/>
			<xsl:text> !!! </xsl:text>
			<xsl:value-of select="@File"/>
		</xsl:message>
		<xsl:text>* </xsl:text>
		<xsl:if test="@Code">
			<xsl:choose>
				<xsl:when test="local-name()='Warning'">
					<xsl:text>⚠ </xsl:text>
				</xsl:when>
				<xsl:when test="local-name()='Message'">
					<xsl:text>✔ </xsl:text>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>⁉</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text> </xsl:text>
			<xsl:value-of select="@Text"/>&cr;
			<xsl:text>  * </xsl:text>
			<xsl:value-of select="@File"/>
			<xsl:if test="@LineNumber">
				<xsl:text> (</xsl:text>
				<xsl:value-of select="@LineNumber"/>
				<xsl:if test="@ColumnNumber">
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@ColumnNumber"/>
				</xsl:if>
				<xsl:text>)</xsl:text>
			</xsl:if>
			&cr;
			<xsl:text>  * </xsl:text>
			<xsl:value-of select="@ProjectFile"/>&cr;
		</xsl:if>
		</w>
	</xsl:template>

</xsl:stylesheet>
