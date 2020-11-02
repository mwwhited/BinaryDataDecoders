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
	<xsl:variable name="basePath" select="$files/@sandbox" />

	<xsl:template match="/">
		<xsl:text># Build Log</xsl:text>&cr;&cr;

		<xsl:apply-templates select="//CscTask//Folder/Warning | //VscTask//Folder/Warning" />
		&cr;

		<xsl:text>## Links</xsl:text>&cr;&cr;
		<xsl:text>* [Table of Contents](./TOC.md)</xsl:text>&cr;
	</xsl:template>

	<xsl:template match="Warning">
		<xsl:variable name="projectFile" select="substring(@ProjectFile, string-length($basePath)+1)" />
		<xsl:variable name="projectFilePath" select="concat('..', $projectFile)" />
		<xsl:variable name="projectBasePath" select="ex-path:GetDirectoryName($projectFilePath)" />
		<xsl:variable name="codeFile" select="translate(concat($projectBasePath, '\', @File), '\', '/')" />

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
			<xsl:text>  * [</xsl:text>
			<xsl:value-of select="@File"/>
			<xsl:text>](</xsl:text>
			<xsl:value-of select="$codeFile"/>
			<xsl:if test="@LineNumber">
				<xsl:text>#</xsl:text>
				<xsl:value-of select="@LineNumber"/>
			</xsl:if>
			<xsl:text>)</xsl:text>
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
		</xsl:if>
	</xsl:template>

</xsl:stylesheet>
