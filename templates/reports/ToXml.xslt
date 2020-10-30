<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="xml" indent="yes"/>
	<xsl:param name="files" />

	<xsl:template match="/">
		<root>
			<files>
				<xsl:apply-templates select="$files"  mode="copy"/>
			</files>
			<code>
				<xsl:apply-templates select="." mode="copy"/>
			</code>
		</root>
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
