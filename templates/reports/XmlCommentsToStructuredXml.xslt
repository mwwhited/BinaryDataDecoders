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
	<xsl:output method="xml" indent="yes"/>
	<xsl:param name="files" />

	<xsl:template match="/">
		<Assembly>
			<xsl:attribute name="name">
				<xsl:value-of select="doc/assembly/name" />
			</xsl:attribute>
			<xsl:apply-templates mode="members" select="doc/members/member[substring(@name,1,2)='T:']" />
		</Assembly>
	</xsl:template>

	<xsl:template mode="members" match="member">
		<xsl:param name="parent" />
		<xsl:variable name="type-prefix" select="substring(@name,1,2)" />
		<xsl:variable name="name" select="substring(@name,3,string-length(@name)-2)" />
		<xsl:variable name="simple-name">
			<xsl:choose>
				<xsl:when test="$parent=''">
					<xsl:value-of select="$name"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="substring(@name,string-length($parent)+2)"/>
				</xsl:otherwise>
			</xsl:choose>

		</xsl:variable>
		<xsl:variable name="member-type">
			<xsl:choose>
				<xsl:when test="$type-prefix='T:'">Type</xsl:when>
				<xsl:when test="$type-prefix='F:'">Field</xsl:when>
				<xsl:when test="$type-prefix='M:'">Method</xsl:when>
				<xsl:when test="$type-prefix='P:'">Property</xsl:when>
				<xsl:otherwise>Unknown</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>

		<xsl:variable name="members" select="/doc/members/member[
			starts-with(
				substring(@name,3,
					string-length(@name)-2
					),
				concat($name,'.')
			)]" />

		<xsl:element name="{$member-type}">
			<xsl:attribute name="simple">
				<xsl:value-of select="$simple-name"/>
			</xsl:attribute>
			<xsl:attribute name="parent">
				<xsl:value-of select="$parent"/>
			</xsl:attribute>
			<xsl:attribute name="name">
				<xsl:value-of select="$name"/>
			</xsl:attribute>
			<xsl:attribute name="ref">
				<xsl:value-of select="@name"/>
			</xsl:attribute>
			<Comments>
				<xsl:apply-templates mode="copy" select="*" />
			</Comments>
			<xsl:if test="$members">
				<Members>
					<xsl:apply-templates mode="members" select="$members">
						<xsl:sort select="@name" />
						<xsl:with-param name="parent" select="./@name"/>
					</xsl:apply-templates>
				</Members>
			</xsl:if>
		</xsl:element>
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
