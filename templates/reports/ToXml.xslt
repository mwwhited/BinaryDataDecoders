<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	exclude-result-prefixes="xsl msxsl ex-path o-path ex-file o-file ex-env o-env ex-str o-str"
	
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
	
	xmlns:cs-tr="bdd:CodeAnalysis/Tree"
	xmlns:cs-n="bdd:CodeAnalysis/Node"
	xmlns:cs-t="bdd:CodeAnalysis/Token"
	xmlns:cs-r="bdd:CodeAnalysis/Trivia"
	>
	<xsl:output method="xml" indent="no"/>
	<xsl:param name="files" />

	<xsl:template match="cs-tr:Tree">
		<root>
			<xsl:attribute name="ns">
				<xsl:value-of select="namespace-uri(.)"/>
			</xsl:attribute>
			<xsl:attribute name="n">
				<xsl:value-of select="name(.)"/>
			</xsl:attribute>
			<xsl:attribute name="ln">
				<xsl:value-of select="local-name(.)"/>
			</xsl:attribute>
			<files>
				<xsl:apply-templates select="$files" mode="copy" />
			</files>
			<code>
				<xsl:apply-templates select="." mode="copy" />
			</code>
		</root>
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>

	<!--<xsl:template match="@* | node()" >
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" />
		</xsl:copy>
	</xsl:template>-->

</xsl:stylesheet>
