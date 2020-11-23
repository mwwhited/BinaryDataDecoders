<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
	<!ENTITY tab "<xsl:text>    </xsl:text>">
	<!ENTITY sp "<xsl:text> </xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	exclude-result-prefixes="xsl msxsl ex-path o-path ex-file o-file ex-env o-env ex-str o-str ex-xml o-xml"
	
	xmlns:ex-path="bdd:ToolKit/PathExtensions"
	xmlns:o-path="bdd:ToolKit/PathExtensions:out"
	xmlns:ex-file="bdd:ToolKit/FileExtensions"
	xmlns:o-file="bdd:ToolKit/FileExtensions:out"
	xmlns:ex-env="bdd:ToolKit/EnvironmentExtensions"
	xmlns:o-env="bdd:ToolKit/EnvironmentExtensions:out"
	xmlns:ex-str="bdd:ToolKit/StringExtensions"
	xmlns:o-str="bdd:ToolKit/StringExtensions:out"
	xmlns:ex-xml="bdd:ToolKit/XmlExtensions"
	xmlns:o-xml="bdd:ToolKit/XmlExtensions:out"

	xmlns:ex-trx="clr:BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions, BinaryDataDecoders.TestUtilities"
    xmlns:o-trx="clr:BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions, BinaryDataDecoders.TestUtilities:out"
	
	xmlns:ex-xsl="clr:BinaryDataDecoders.Xslt.Cli.XsltTransformer, BinaryDataDecoders.Xslt.Cli"
	
	xmlns:cs-n="bdd:CodeAnalysis/Node"
	xmlns:cs-t="bdd:CodeAnalysis/Token"
	xmlns:cs-r="bdd:CodeAnalysis/Trivia"
	xmlns:cs-tr="bdd:CodeAnalysis/Tree"
	
	>
	<xsl:output method="text" indent="no"/>
	<xsl:param name="files" />

	<xsl:template match="/">
    <xsl:text># Database </xsl:text>&cr;
    &cr;
    <xsl:apply-templates select="TSqlModel/Schema" mode="schema" />    
  </xsl:template>

  <xsl:template match="Schema" mode="schema">
    <xsl:variable name="schema-name" select="Name/Parts/String[1]" />
    <xsl:variable name="children" select="../*[count(Name/Parts/String)=2 and Name/Parts/String[1]/text()=$schema-name]" />
    <xsl:text>## Schema - </xsl:text><xsl:value-of select="$schema-name"/>&cr;
    &cr;

    <xsl:for-each select="$children">
      <!--Name/Parts/String[2]"/>-->
      <xsl:text>### </xsl:text><xsl:value-of select="local-name(.)"/><xsl:text> - </xsl:text><xsl:value-of select="Name/Parts/String[2]" />&cr;
    </xsl:for-each>
    &cr;
  </xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>
