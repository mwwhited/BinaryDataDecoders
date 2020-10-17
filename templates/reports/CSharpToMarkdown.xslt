<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
	<!ENTITY tab "<xsl:text>    </xsl:text>">
	<!ENTITY sp "<xsl:text> </xsl:text>">
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
	
	xmlns:cs-n="bdd:CodeAnalysis/Node"
	xmlns:cs-t="bdd:CodeAnalysis/Token"
	xmlns:cs-r="bdd:CodeAnalysis/Trivia"
	>
	<xsl:output method="text" indent="no"/>
	<xsl:param name="files" />

	<xsl:template match="/">
		<xsl:apply-templates select="cs-n:CompilationUnit" />
	</xsl:template>

	<xsl:template match="cs-n:CompilationUnit">
		<xsl:text># </xsl:text><xsl:value-of select="ex-path:GetFileName($files/@input)" />&cr;&cr;

		<xsl:text>## Summary</xsl:text>&cr;&cr;
		<xsl:text>* Language: </xsl:text><xsl:value-of select="@Language" />&cr;
		<xsl:text>* Path: </xsl:text><xsl:value-of select="$files/@input" />&cr;&cr;

		<xsl:variable name="defined-types" select="descendant::*[
			self::cs-n:EnumDeclaration or 
			self::cs-n:InterfaceDeclaration or 
			self::cs-n:ClassDeclaration or 
			self::cs-n:StructDeclaration
		]" />

		<xsl:apply-templates select="$defined-types" mode="type" />
	</xsl:template>

	<xsl:template match="*" mode="type">
		<xsl:variable name="name" select="cs-t:IdentifierToken[1]" />
		<xsl:variable name="comments" select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />
		<xsl:variable name="attributes" select="cs-n:AttributeList/cs-n:Attribute" />
		<xsl:variable name="members" select="descendant::*[
			self::cs-n:MethodDeclaration or 
			self::cs-n:PropertyDeclaration or 
			self::cs-n:FieldDeclaration
		]" />
		
		<xsl:text>## </xsl:text>
		<xsl:call-template name="simple-name">
			<xsl:with-param name="input" select="." />
		</xsl:call-template>
		<xsl:text> - </xsl:text>		
		<xsl:value-of select="$name" />&cr;&cr;

		<xsl:if test="$comments">
			<xsl:text>### Comments</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$comments" />
		</xsl:if>
		
		<xsl:if test="$attributes">
			<xsl:text>### Attributes</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$attributes" mode="attribute" />&cr;
		</xsl:if>

		<xsl:if test="$members">
			<xsl:text>### Members</xsl:text>&cr;&cr;
			<xsl:apply-templates select="$members" mode="member" />
		</xsl:if>

	</xsl:template>
	<xsl:template match="*" mode="member">
		<xsl:variable name="name" select="cs-t:IdentifierToken[1]" />
		<xsl:variable name="comments" select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />
		<xsl:variable name="attributes" select="cs-n:AttributeList/cs-n:Attribute" />
		
		<xsl:text>#### </xsl:text>
		<xsl:call-template name="simple-name">
			<xsl:with-param name="input" select="." />
		</xsl:call-template>
		<xsl:text> - </xsl:text>
		<xsl:value-of select="cs-t:IdentifierToken[1]" />&cr;&cr;

		<xsl:if test="$comments">
			<xsl:text>##### Comments</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$comments" />
		</xsl:if>
		
		<xsl:if test="$attributes">
			<xsl:text>##### Attributes</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$attributes" mode="attribute" />&cr;
		</xsl:if>

	</xsl:template>

	<xsl:template match="*" mode="attribute">
		<xsl:text> * </xsl:text>
		<xsl:value-of select="." />
		&cr;
	</xsl:template>

	<xsl:template match="cs-n:SingleLineDocumentationCommentTrivia">
		<xsl:value-of select="." />&cr;&cr;
	</xsl:template>

	<xsl:template name="simple-name">
		<xsl:param name="input" />
		<xsl:variable name="type" >
			<xsl:choose>
				<xsl:when test="self::cs-n:ClassDeclaration">
					<xsl:text>Class</xsl:text>
				</xsl:when>
				<xsl:when test="self::cs-n:StructDeclaration">
					<xsl:text>Structure</xsl:text>
				</xsl:when>
				<xsl:when test="self::cs-n:InterfaceDeclaration">
					<xsl:text>Interface</xsl:text>
				</xsl:when>
				<xsl:when test="self::cs-n:EnumDeclaration">
					<xsl:text>Enumeration</xsl:text>
				</xsl:when>

				<xsl:when test="self::cs-n:MethodDeclaration">
					<xsl:text>Method</xsl:text>
				</xsl:when>
				<xsl:when test="self::cs-n:PropertyDeclaration">
					<xsl:text>Property</xsl:text>
				</xsl:when>

				<xsl:otherwise>
					<xsl:value-of select="local-name($input)"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:variable name="visibility" >
			<xsl:choose>
				<xsl:when test="$input[cs-t:PublicKeyword]">
					<xsl:text>Public</xsl:text>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="local-name($input/*[1])"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:variable name="access" >
			<xsl:choose>
				<xsl:when test="$input[cs-t:StaticKeyword]">
					<xsl:text>Static</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:variable>
		<xsl:if test="$visibility!=''">
			<xsl:value-of select="$visibility"  />&sp;
		</xsl:if>
		<xsl:if test="$access!=''">
			<xsl:value-of select="$access" />&sp;
		</xsl:if>
		<xsl:value-of select="$type"  />
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>
