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
	<xsl:param name="files" />

	<xsl:template match="/" >
		<xsl:text># Assembly - </xsl:text><xsl:value-of select="Assembly/@name" />&cr;
		&cr;
		<xsl:apply-templates select="Assembly/Type" mode="members" />
	</xsl:template>

	<xsl:template match="Type" mode="members" >
		<xsl:text>## Type - </xsl:text><xsl:value-of select="@name" />&cr;
		&cr;

		<xsl:apply-templates select="Comments/*" mode="comments" />

		<xsl:apply-templates select="Members/*" mode="members" />
	</xsl:template>


	<xsl:template match="*" mode="members" >
		<xsl:text>### </xsl:text><xsl:value-of select="local-name(.)" /><xsl:text> - </xsl:text><xsl:value-of select="@simple" />&cr;
		&cr;

		<xsl:apply-templates select="Comments/*" mode="comments" />
		
		<xsl:apply-templates select="Members/*" mode="members" />
	</xsl:template>

	<xsl:template match="*" mode="comments">
		<xsl:text>*</xsl:text><xsl:value-of select="local-name(.)"/><xsl:text>*</xsl:text>&cr;
		<xsl:value-of select="ex-str:TrimPerLine(text())"/>&cr;&cr;

		<xsl:if test="@*">
			<xsl:text>| Key                  | Value                                                        |</xsl:text>&cr;
			<xsl:text>| :------------------- | :----------------------------------------------------------- |</xsl:text>&cr;
			<xsl:for-each select="@*">
				<xsl:text>| </xsl:text>
				<xsl:value-of select="substring(concat(local-name(.),'                    '),1,20)" />
				<xsl:text> | </xsl:text>
				<xsl:value-of select="substring(concat(.,'                                                            '),1,60)" />
				<xsl:text> | </xsl:text>&cr;
			</xsl:for-each>
			&cr;
		</xsl:if>
	</xsl:template>

</xsl:stylesheet>
