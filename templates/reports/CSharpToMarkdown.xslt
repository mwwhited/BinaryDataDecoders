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
	<xsl:output method="xml" indent="yes"/>
	<xsl:param name="files" />

	<xsl:template match="/">
		<root>
			<files>
				<xsl:apply-templates select="$files" mode="copy" />
			</files>
			<code>
				<xsl:apply-templates select="node()" mode="copy" />
			</code>
		</root>
	</xsl:template>
	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>
