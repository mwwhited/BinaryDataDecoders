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

	<xsl:template match="/">

		<xsl:text># </xsl:text><xsl:value-of select="CoverageReport/Summary/Title" />&cr;
		&cr;
		<xsl:text>Scope: </xsl:text><xsl:value-of select="CoverageReport/@scope" />&cr;
		<xsl:text>Build: </xsl:text><xsl:value-of select="ex-env:GetValue('BUILD_VERSION')" />&cr;
		<xsl:text>Source: </xsl:text><xsl:value-of select="$files/@input" />&cr;
		&cr;

		<xsl:apply-templates select="CoverageReport/Summary" />
		<xsl:apply-templates select="CoverageReport/Metrics" />
		<xsl:apply-templates select="CoverageReport/Files" />
		<xsl:apply-templates select="CoverageReport/Coverage" />

		<xsl:if test="not(CoverageReport[@scope='Summary'])">
		<xsl:text>## Footer </xsl:text>&cr;
		<xsl:text>[Return to Summary](Summary.md)</xsl:text>&cr;
		&cr;
		</xsl:if>
	</xsl:template>

	<xsl:template match="CoverageReport/Summary">
		<xsl:text>## Summary</xsl:text>&cr;
		&cr;
		<xsl:text>| Key                  | Value                                                            |</xsl:text>&cr;
		<xsl:text>| :------------------- | :--------------------------------------------------------------- |</xsl:text>&cr;
		<xsl:for-each select="*[not(local-name(.)='Files')]">
			<xsl:text>| </xsl:text>
			<xsl:value-of select="substring(concat(local-name(.),'                    '),1,20)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="substring(concat(text(),'                                                            '),1,60)" />
			<xsl:text> | </xsl:text>&cr;
		</xsl:for-each>
		&cr;
		<xsl:apply-templates select="Files" />
	</xsl:template>
	<xsl:template match="Summary/Files">
		<xsl:text>### Files</xsl:text>&cr;
		<xsl:for-each select="File">
			<xsl:text> * </xsl:text>
			<xsl:value-of select="." />&cr;
		</xsl:for-each>
		&cr;
	</xsl:template>

	<xsl:template match="CoverageReport/Metrics">
		<xsl:text>## Metrics</xsl:text>&cr;
		&cr;
		<xsl:text>| Complexity | Lines | Branches | Name                                          |</xsl:text>&cr;
		<xsl:text>| :--------- | :---- | :------- | :-------------------------------------------- |</xsl:text>&cr;
		<xsl:for-each select="Element">
			<xsl:text>| </xsl:text>
			<xsl:value-of select="substring(concat(Cyclomaticcomplexity,'          '),1,10)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="substring(concat(Linecoverage,'        '),1,5)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="substring(concat(Branchcoverage,'        '),1,8)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="@name" />
			<xsl:text> | </xsl:text>&cr;
		</xsl:for-each>
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
		&cr;
		<xsl:text>```</xsl:text>&cr;

	</xsl:template>

	<xsl:template match="CoverageReport/Coverage">
		<xsl:text>## Coverage</xsl:text>&cr;
		&cr;
		<xsl:apply-templates select="./Assembly" />
	</xsl:template>

	<xsl:template match="Coverage/Assembly">
		<xsl:text>### Assembly - </xsl:text><xsl:value-of select="@name" />&cr;
		&cr;
		<xsl:text>#### Summary</xsl:text>&cr;
		<xsl:text>| Key                  | Value                                                            |</xsl:text>&cr;
		<xsl:text>| :------------------- | :--------------------------------------------------------------- |</xsl:text>&cr;
		<xsl:for-each select="@*[not(local-name(.)='name')]">
			<xsl:text>| </xsl:text>
			<xsl:value-of select="substring(concat(local-name(.),'                    '),1,20)" />
			<xsl:text> | </xsl:text>
			<xsl:value-of select="substring(concat(.,'          '),1,10)" />
			<xsl:text> | </xsl:text>&cr;
		</xsl:for-each>
		&cr;
		<xsl:text>#### Classes</xsl:text>&cr;
		<xsl:text>| coverage   | name                                                             | </xsl:text>&cr;
		<xsl:text>| :--------- | :--------------------------------------------------------------- | </xsl:text>&cr;
		<xsl:apply-templates select="./Class" />
		&cr;
	</xsl:template>

	<xsl:template match="Coverage/Assembly/Class">
		<xsl:text>| </xsl:text>
		<xsl:value-of select="substring(concat(@coverage,'          '),1,10)" />
		<xsl:text> | </xsl:text>
		<xsl:call-template name="getClassIfLinked">
			<xsl:with-param name="assembly" select="../@name"/>
			<xsl:with-param name="class" select="@name"/>
		</xsl:call-template>
		<xsl:text> | </xsl:text>&cr;
	</xsl:template>

	<xsl:template name="getClassIfLinked">
		<xsl:param name="assembly"/>
		<xsl:param name="class"/>

		<xsl:variable name="linkedFile">
			<links>
				<xsl:for-each select="ex-path:ListFilesFiltered('Publish\Results\Coverage', concat($assembly,'_*.xml'))/o-path:file">
					<link>
						<xsl:attribute name="file">
							<xsl:value-of select="concat(ex-path:GetFileNameWithoutExtension(.), '.md')" />
						</xsl:attribute>
						<xsl:attribute name="full">
							<xsl:value-of select="." />
						</xsl:attribute>
						<xsl:attribute name="scope">
							<xsl:value-of select="ex-file:ReadXml(.)/CoverageReport/Summary[Class=$class][Assembly=$assembly]/../../@scope" />
						</xsl:attribute>
					</link>
				</xsl:for-each>
			</links>
		</xsl:variable>

		<xsl:text>[</xsl:text>
		<xsl:value-of select="$class" />
		<xsl:text>](</xsl:text>
		<xsl:value-of select="msxsl:node-set($linkedFile)/links/link/@file" />
		<xsl:text>)</xsl:text>
	</xsl:template>

</xsl:stylesheet>
