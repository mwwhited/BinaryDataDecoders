<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	
	xmlns:fn="http://www.w3.org/2005/xpath-functions"

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
		<xsl:text># </xsl:text><xsl:value-of select="CoverageReport/@scope" />&cr;
		&cr;

		<xsl:apply-templates select="CoverageReport/Summary" />
		<xsl:apply-templates select="CoverageReport/Metrics" />
		<xsl:apply-templates select="CoverageReport/Files" />
		<xsl:apply-templates select="CoverageReport/Coverage" />

		<xsl:if test="not(CoverageReport[@scope='Summary'])">
			<xsl:text>## Links</xsl:text>&cr;
			&cr;
			<xsl:text>* [Return to Summary](Summary.md)</xsl:text>&cr;
			<xsl:text>* [Table of Contents](../TOC.md)</xsl:text>&cr;
			&cr;
		</xsl:if>
	</xsl:template>

	<xsl:template match="CoverageReport/Summary">
		<xsl:variable name="summaries" select="*[not(self::Files or self::Title)]" />
		<xsl:variable name="max-key-len" select="fn:max(fn:apply('string-length(local-name(.))', $summaries))" />
		<xsl:variable name="max-value-len" select="fn:max(fn:apply('string-length(.)', $summaries/text()))" />

		<xsl:text>## Summary</xsl:text>&cr;
		&cr;

		<xsl:value-of select="concat('| ',ex-str:PadRight('Key',$max-key-len),' | ',ex-str:PadRight('Value',$max-value-len+2),' |')"/>&cr;
		<xsl:value-of select="concat('| :',ex-str:New('-',$max-key-len - 1),' | :',ex-str:New('-',$max-value-len +1),' |')"/>&cr;

		<xsl:for-each select="$summaries">
			<xsl:value-of select="concat('| ',ex-str:PadRight(local-name(.),$max-key-len),' | ',ex-str:PadRight(concat('`',text(),'`'),$max-value-len + 2),' |')"/>&cr;
		</xsl:for-each>
		&cr;
	</xsl:template>
	<xsl:template match="Summary/Files">
		<xsl:text>### Files</xsl:text>&cr;
		&cr;
		<xsl:for-each select="File">
			<xsl:text>* </xsl:text>
			<xsl:value-of select="." />&cr;
		</xsl:for-each>
		&cr;
	</xsl:template>

	<xsl:template match="CoverageReport/Metrics">
		<xsl:variable name="metrics" select="Element" />
		<xsl:variable name="max-name-len">
			<xsl:variable name="temp" select="fn:max(fn:apply('string-length(.)',$metrics/@name))" />
			<xsl:choose>
				<xsl:when test="$temp &lt; 5">
					<xsl:text>5</xsl:text>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$temp"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>

		<xsl:text>## Metrics</xsl:text>&cr;
		&cr;

		<xsl:text>| Complexity | Lines | Branches | </xsl:text>
		<xsl:value-of select="ex-str:PadRight('Name',$max-name-len + 2)"/>
		<xsl:text> |</xsl:text>&cr;

		<xsl:text>| :--------- | :---- | :------- | :</xsl:text>
		<xsl:value-of select="ex-str:New('-',$max-name-len + 1)"/>
		<xsl:text> |</xsl:text>&cr;

		<xsl:for-each select="$metrics">
			<xsl:text>| </xsl:text>
			<xsl:value-of select="ex-str:PadRight(Cyclomaticcomplexity,10)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="ex-str:PadRight(Linecoverage,5)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="ex-str:PadRight(Branchcoverage,8)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="ex-str:PadRight(concat('`',@name,'`'),$max-name-len + 2)" />
			<xsl:text> |</xsl:text>&cr;
		</xsl:for-each>
		&cr;
	</xsl:template>

	<xsl:template match="CoverageReport/Files">
		<xsl:text>## Files</xsl:text>&cr;
		&cr;
		<xsl:apply-templates select="File" />
	</xsl:template>
	<xsl:template match="CoverageReport/Files/File">
		<xsl:text>## File - </xsl:text><xsl:value-of select="@name" />&cr;
		&cr;

		<xsl:variable name="file-ext" select="ex-path:GetExtension(@name)" />
		<xsl:text>```</xsl:text>
		<xsl:choose>
			<xsl:when test="$file-ext='.cs'">
				<xsl:text>CSharp</xsl:text>
			</xsl:when>
			<xsl:when test="$file-ext='.vb'">
				<xsl:text>VisualBasic</xsl:text>
			</xsl:when>
		</xsl:choose>&cr;
		<xsl:for-each select="LineAnalysis">
			<xsl:choose>
				<xsl:when test="@coverage='Covered'">✔</xsl:when>
				<xsl:when test="@coverage='PartiallyCovered'">⚠</xsl:when>
				<xsl:when test="@coverage='NotCoverable'">〰</xsl:when>
				<xsl:when test="@coverage='NotCovered'">‼</xsl:when>
				<xsl:otherwise>❓</xsl:otherwise>
			</xsl:choose>
			<xsl:value-of select="substring(concat(@line,':     '),1,5)" />
			<xsl:value-of select="@content" />
			&cr;
		</xsl:for-each>
		<xsl:text>```</xsl:text>&cr;
		&cr;
	</xsl:template>

	<xsl:template match="CoverageReport/Coverage">
		<xsl:text>## Coverage</xsl:text>&cr;
		&cr;
		<xsl:apply-templates select="./Assembly" />
	</xsl:template>

	<xsl:template match="Coverage/Assembly">

		<xsl:variable name="summaries" select="@*[not(local-name(.)='name') and string-length(.) &gt; 0]" />
		<xsl:variable name="max-key-len">
			<xsl:variable name="temp" select="fn:max(fn:apply('string-length(local-name(.))', $summaries))" />
			<xsl:choose>
				<xsl:when test="$temp &lt; 5">
					<xsl:text>5</xsl:text>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$temp"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>

		<xsl:variable name="max-value-len" select="fn:max(fn:apply('string-length(.)', $summaries))" />

		<xsl:text>### Assembly - </xsl:text><xsl:value-of select="@name" />&cr;
		&cr;

		<xsl:text>## Summary</xsl:text>&cr;
		&cr;

		<xsl:value-of select="concat('| ',ex-str:PadRight('Key',$max-key-len),' | ',ex-str:PadRight('Value',$max-value-len+2),' |')"/>&cr;
		<xsl:value-of select="concat('| :',ex-str:New('-',$max-key-len - 1),' | :',ex-str:New('-',$max-value-len +1),' |')"/>&cr;

		<xsl:for-each select="$summaries">
			<xsl:value-of select="concat('| ',ex-str:PadRight(local-name(.),$max-key-len),' | ',ex-str:PadRight(concat('`',.,'`'),$max-value-len + 2),' |')"/>&cr;
		</xsl:for-each>
		&cr;

		<xsl:text>#### Classes</xsl:text>&cr;
		&cr;
		<xsl:text>| coverage   | name                                                             |</xsl:text>&cr;
		<xsl:text>| :--------- | :--------------------------------------------------------------- |</xsl:text>&cr;
		<xsl:apply-templates select="./Class" />
		&cr;
	</xsl:template>

	<xsl:template match="Coverage/Assembly/Class">
		<xsl:text>| </xsl:text>
		<xsl:value-of select="ex-str:PadRight(@coverage,10)" />
		<xsl:text> | </xsl:text>
		<xsl:call-template name="getClassIfLinked">
			<xsl:with-param name="assembly" select="../@name"/>
			<xsl:with-param name="class" select="@name"/>
		</xsl:call-template>
		<xsl:text> |</xsl:text>&cr;
	</xsl:template>

	<xsl:template name="getClassIfLinked">
		<xsl:param name="assembly"/>
		<xsl:param name="class"/>

		<xsl:variable name="cleaned-class-name">
			<xsl:value-of select="substring($class, string-length($assembly)+2)"/>
		</xsl:variable>

		<!--<xsl:value-of select="ex-str:PadRight(concat('`', translate($cleaned-class-name,'`', '_'), '`'), 64)" />-->

		<xsl:text>[</xsl:text>
		<xsl:value-of select="$cleaned-class-name" />
		<xsl:text>](</xsl:text>
		<xsl:value-of select="$assembly"/>
		<xsl:text>_</xsl:text>
		<xsl:value-of select="translate(substring(ex-path:GetExtension($cleaned-class-name),2), '`','_')" />
		<xsl:text>.md)</xsl:text>
	</xsl:template>

</xsl:stylesheet>
