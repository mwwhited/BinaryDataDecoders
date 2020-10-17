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
	
	xmlns:cs-n="bdd:CodeAnalysis/Node"
	xmlns:cs-t="bdd:CodeAnalysis/Token"
	xmlns:cs-r="bdd:CodeAnalysis/Trivia"
	>
	<xsl:output method="text" indent="no"/>
	<xsl:param name="files" />

	<xsl:template match="/">
		<xsl:text># </xsl:text>		<xsl:value-of select="ex-path:GetFileName($files/@input)" />&cr;
		&cr;
		<xsl:text>## Summary</xsl:text>&cr;&cr;
		<xsl:text>Language: </xsl:text><xsl:value-of select="cs-n:CompilationUnit/@Language" />&cr;
		<xsl:text>Path: </xsl:text><xsl:value-of select="$files/@input" />&cr;
		&cr;

		<xsl:apply-templates select="cs-n:CompilationUnit[@Language='C#']/descendant::cs-n:EnumDeclaration" />
		<xsl:apply-templates select="cs-n:CompilationUnit[@Language='C#']/descendant::cs-n:InterfaceDeclaration" />
		<xsl:apply-templates select="cs-n:CompilationUnit[@Language='C#']/descendant::cs-n:ClassDeclaration" />
		<xsl:apply-templates select="cs-n:CompilationUnit[@Language='C#']/descendant::cs-n:StructDeclaration" />

		<!--<root>
			<files>
				<xsl:apply-templates select="$files" mode="copy" />
			</files>
			<code>
				<xsl:apply-templates select="node()" mode="copy" />
			</code>
		</root>-->
	</xsl:template>

	<xsl:template match="cs-n:ClassDeclaration">
		<xsl:call-template name="object-doc">
			<xsl:with-param name="type" select="'Class'" />
			<xsl:with-param name="model" select="." />
		</xsl:call-template>
	</xsl:template>
	<xsl:template match="cs-n:StructDeclaration">
		<xsl:call-template name="object-doc">
			<xsl:with-param name="type" select="'Structure'" />
			<xsl:with-param name="model" select="." />
		</xsl:call-template>
	</xsl:template>
	<xsl:template match="cs-n:InterfaceDeclaration">
		<xsl:call-template name="object-doc">
			<xsl:with-param name="type" select="'Interface'" />
			<xsl:with-param name="model" select="." />
		</xsl:call-template>
	</xsl:template>
	<xsl:template match="cs-n:EnumDeclaration">
		<xsl:call-template name="object-doc">
			<xsl:with-param name="type" select="'Enumeration'" />
			<xsl:with-param name="model" select="." />
		</xsl:call-template>
	</xsl:template>

	<xsl:template name="object-doc">
		<xsl:param name="type"/>
		<xsl:param name="model"/>

		<xsl:text>## </xsl:text><xsl:value-of select="$type" /><xsl:text>: </xsl:text><xsl:value-of select="cs-t:IdentifierToken[1]" />&cr;&cr;
		<!--<xsl:text>Namespace: </xsl:text><xsl:value-of select="../cs-n:QualifiedName/descendant::text()" />&cr;-->

		<xsl:apply-templates select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />

		<xsl:apply-templates select="cs-n:MethodDeclaration" /><!--[cs-t:PublicKeyword or ../cs-n:InterfaceDeclaration]-->

		<!--cs-r:SingleLineDocumentationCommentTrivia-->
		<!--<xsl:apply-templates select="node()" mode="copy" />-->

	</xsl:template>

	<xsl:template match="cs-n:MethodDeclaration">
		<xsl:text>### Method: </xsl:text><xsl:value-of select="cs-t:IdentifierToken[1]" />&cr;&cr;

		<xsl:apply-templates select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />

		<!--<xsl:apply-templates select="node()" mode="copy" />-->
	</xsl:template>

	<xsl:template match="cs-n:SingleLineDocumentationCommentTrivia">
		<xsl:value-of select="." />&cr;&cr;

		<!--<xsl:apply-templates select="node()" mode="copy" />-->
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>
