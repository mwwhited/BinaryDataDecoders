<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
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

	<xsl:template match="/" >
		<xsl:text># Documentation </xsl:text>&cr;
		&cr;
		<xsl:apply-templates select="Directory" />
	</xsl:template>
	
	<xsl:template match="Directory">

		<xsl:value-of select="substring('                              ', 1, count(ancestor::*)*2)"/>		
		<xsl:text>* </xsl:text>
		<xsl:value-of  select="@Name" />&cr;

		<xsl:apply-templates select="*" />
	
	</xsl:template>

	<xsl:template match="File">

		<xsl:value-of select="substring('                              ', 1, count(ancestor::*)*2)"/>
		<xsl:text>* </xsl:text>
		<xsl:text>[</xsl:text>
		<xsl:value-of  select="@WithoutExtension" />
		<xsl:text>](</xsl:text>
		<xsl:value-of  select="concat('.', translate(@RelativeName, '\', '/'))" />
		<xsl:text>)</xsl:text> &cr;

		<xsl:apply-templates select="*" />

	</xsl:template>

	
</xsl:stylesheet>
