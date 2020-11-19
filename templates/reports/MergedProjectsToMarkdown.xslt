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
	xmlns:msb="http://schemas.microsoft.com/developer/msbuild/2003"
	>
	<xsl:output method="text" indent="no"/>
	<xsl:param name="files" />
	<xsl:variable name="basePath" select="$files/@sandbox" />

	<xsl:template match="/">
		<xsl:text># Solution Summary</xsl:text>&cr;&cr;

		<xsl:text>## Component Diagram</xsl:text>&cr;&cr;
		<xsl:apply-templates select="/Top/Node" mode="component-diagram" />

		<xsl:text>## Projects</xsl:text>&cr;&cr;
		<xsl:apply-templates select="/Top/Node" mode="detailed" />
		&cr;

		<xsl:text>## Links</xsl:text>&cr;&cr;
		<xsl:text>* [Table of Contents](./TOC.md)</xsl:text>&cr;
	</xsl:template>

	<xsl:template match="Node" mode="component-diagram">

		<xsl:text>```plantuml</xsl:text>&cr;
		<!--<xsl:text>@startuml</xsl:text>&cr;-->

		<!--<xsl:for-each select="Node">-->
		<xsl:variable name="assembly-name" select="ex-path:GetFileNameWithoutExtension(@Source)" />

		<xsl:value-of select="concat('[', $assembly-name, ']')"/>&cr;

		<xsl:variable name="project-references" select="./Project/ItemGroup/ProjectReference/@Include | ./msb:Project/msb:ItemGroup/msb:ProjectReference/@Include" />
		<xsl:variable name="package-references" select="./Project/ItemGroup/PackageReference/@Include" />

		<xsl:for-each select="$project-references">
			<xsl:value-of select="concat('[', $assembly-name, ']')"/> <xsl:text> --> </xsl:text><xsl:value-of select="concat('[', ex-path:GetFileNameWithoutExtension(.), ']')"/>&cr;
		</xsl:for-each>
		<xsl:for-each select="$package-references">
			<xsl:value-of select="concat('[', $assembly-name, ']')"/> <xsl:text> --> </xsl:text><xsl:value-of select="concat('(', ., ')')"/>&cr;
		</xsl:for-each>

		<!--</xsl:for-each>-->

		<!--<xsl:text>@enduml</xsl:text>&cr;-->
		<xsl:text>```</xsl:text>&cr;
		&cr;
	</xsl:template>

	<xsl:template match="Node" mode="detailed">
		<xsl:variable name="assembly-name" select="ex-path:GetFileNameWithoutExtension(@Source)" />
		<xsl:variable name="project-references" select="./Project/ItemGroup/ProjectReference/@Include | ./msb:Project/msb:ItemGroup/msb:ProjectReference/@Include" />
		<xsl:variable name="package-references" select="./Project/ItemGroup/PackageReference/@Include" />
		<!--        
		<ItemGroup xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
            <ArtifactReference Include="$(DacPacRootPath)\Extensions\Microsoft\SQLDB\Extensions\SqlServer\AzureV12\SqlSchemas\master.dacpac">
              <HintPath>$(DacPacRootPath)\Extensions\Microsoft\SQLDB\Extensions\SqlServer\AzureV12\SqlSchemas\master.dacpac</HintPath>
              <SuppressMissingDependenciesErrors>False</SuppressMissingDependenciesErrors>
              <DatabaseVariableLiteralValue>master</DatabaseVariableLiteralValue>
            </ArtifactReference>
          </ItemGroup>
		-->

		<xsl:text>### </xsl:text><xsl:value-of select="$assembly-name"/>&cr;&cr;

		<xsl:text>* Source: </xsl:text><xsl:value-of select="@Source"/>&cr;
		<xsl:for-each select="$project-references">
			<xsl:text>* Project Reference: </xsl:text><xsl:value-of select="."/>&cr;
		</xsl:for-each>
		<xsl:for-each select="$package-references">
			<xsl:text>* Package Reference: </xsl:text><xsl:value-of select="."/>
			<xsl:text> (</xsl:text><xsl:value-of select="../@Version"/><xsl:text>)</xsl:text>&cr;
		</xsl:for-each>
		&cr;
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
