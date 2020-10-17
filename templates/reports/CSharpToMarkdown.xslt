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
	>
	<xsl:output method="text" indent="no"/>
	<xsl:param name="files" />

	<xsl:template match="/">
		<xsl:apply-templates select="cs-n:CompilationUnit" />
	</xsl:template>

	<xsl:template match="cs-n:CompilationUnit">
		<xsl:variable name="defined-types" select="descendant::*[
			self::cs-n:EnumDeclaration or 
			self::cs-n:InterfaceDeclaration or 
			self::cs-n:ClassDeclaration or 
			self::cs-n:StructDeclaration
		]" />
		<xsl:variable name="attributes" select="cs-n:AttributeList/cs-n:Attribute" />

		<xsl:text># </xsl:text><xsl:value-of select="ex-path:GetFileName($files/@input)" />&cr;&cr;

		<xsl:text>## Summary</xsl:text>&cr;&cr;
		<xsl:text>* Language: </xsl:text><xsl:value-of select="@Language" />&cr;
		<xsl:text>* Path: </xsl:text><xsl:value-of select="substring($files/@input, string-length($files/@sandbox)+2)" />&cr;&cr;

		<xsl:if test="$attributes">
			<xsl:text>### Attributes</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$attributes" mode="attribute" />&cr;
		</xsl:if>

		<xsl:apply-templates select="ex-xml:Fixup($defined-types)" mode="type" />
		<!--
			Note: this is stupid problem... figure out later 
			<xsl:apply-templates select="$defined-types" mode="type" />
		-->
	</xsl:template>

	<xsl:template match="*" mode="type">
		<xsl:variable name="name" select="cs-t:IdentifierToken[1]" />
		<xsl:variable name="comments" select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />
		<xsl:variable name="attributes" select="cs-n:AttributeList/cs-n:Attribute" />
		<xsl:variable name="members" select="descendant::*[
			self::cs-n:ConstructorDeclaration or 
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
		<xsl:variable name="name" >
			<xsl:choose>
				<xsl:when test="self::cs-n:FieldDeclaration">
					<xsl:value-of select="cs-n:VariableDeclaration/descendant::cs-t:IdentifierToken[1]" />
				</xsl:when>
				<xsl:when test="cs-t:IdentifierToken[1]">
					<xsl:value-of select="cs-t:IdentifierToken[1]"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:message terminate="no">
						<xsl:text>!!!UNKNOWN MEMBER NAME!!! </xsl:text>
						<xsl:value-of select="."/>
					</xsl:message>
					<xsl:text>!!!UNKNOWN!!!</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>


		<!--<xsl:when test="*[self::cs-n:GenericName or self::cs-t:IdentifierToken][1]">
					<xsl:value-of select="*[self::cs-n:GenericName or self::cs-t:IdentifierToken][1]"/>
				</xsl:when>-->

		<!--<GenericName RawKind="8618" Type="Node">
							<IdentifierToken xp_0:Kind="SourceFile" xp_0:Start="223" xp_0:End="227" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">Task</IdentifierToken>
							<TypeArgumentList RawKind="8619" Type="Node">
								<LessThanToken xp_0:Kind="SourceFile" xp_0:Start="227" xp_0:End="228" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">&lt;</LessThanToken>
								<IdentifierName RawKind="8616" Type="Node">
									<IdentifierToken xp_0:Kind="SourceFile" xp_0:Start="228" xp_0:End="249" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">PipelineErrorHandling</IdentifierToken>
								</IdentifierName>
								<GreaterThanToken xp_0:Kind="SourceFile" xp_0:Start="249" xp_0:End="250" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">
									&gt;<WhitespaceTrivia Value=" " RawKind="8540" Type="Trivia" xmlns="bdd:CodeAnalysis/Trivia"> </WhitespaceTrivia>
								</GreaterThanToken>
							</TypeArgumentList>
						</GenericName>-->

		<xsl:variable name="comments" select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />
		<xsl:variable name="attributes" select="cs-n:AttributeList/cs-n:Attribute" />

		<xsl:text>#### </xsl:text>
		<xsl:call-template name="simple-name">
			<xsl:with-param name="input" select="." />
		</xsl:call-template>
		<xsl:text> - </xsl:text>
		<xsl:value-of select="$name" />&cr;&cr;

		<xsl:if test="$comments">
			<xsl:text>##### Comments</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$comments" />
		</xsl:if>

		<xsl:if test="$attributes">
			<xsl:text>##### Attributes</xsl:text> <!--- <xsl:value-of select="$name" />-->&cr;&cr;
			<xsl:apply-templates select="$attributes" mode="attribute" />&cr;
		</xsl:if>

		<xsl:choose>
			<xsl:when test="self::cs-n:FieldDeclaration">
				<xsl:text>##### Summary</xsl:text>&cr;&cr;
				<xsl:text> * Type: </xsl:text>
				<xsl:call-template name="type-resolver">
					<xsl:with-param name="input" select="cs-n:VariableDeclaration/*[1]" />
				</xsl:call-template>&cr;
			</xsl:when>
			<xsl:when test="self::cs-n:ConstructorDeclaration or self::cs-n:MethodDeclaration">
				<xsl:if test="cs-n:ParameterList/cs-n:*">
					<xsl:text>#####  Parameters</xsl:text>&cr;&cr;
					<xsl:apply-templates select="cs-n:ParameterList/cs-n:*" mode="parameter" />
				</xsl:if>
				<xsl:if test="*[preceding-sibling::cs-n:IdentifierToken][1]">
					<xsl:text> * Returns: </xsl:text>
					<xsl:call-template name="type-resolver">
						<xsl:with-param name="input" select="*[preceding-sibling::cs-n:IdentifierToken][1]" />
					</xsl:call-template>&cr;
				</xsl:if>
			</xsl:when>

		</xsl:choose>
		&cr;

	</xsl:template>

	<xsl:template match="*" mode="attribute">
		<xsl:text> * </xsl:text>
		<xsl:value-of select="." />
		&cr;
	</xsl:template>

	<xsl:template match="*" mode="parameter">
		<xsl:text> * </xsl:text>
		<xsl:value-of select="." />
		&cr;
	</xsl:template>

	<xsl:template match="cs-n:SingleLineDocumentationCommentTrivia">
		<xsl:value-of select="." />&cr;&cr;
	</xsl:template>

	<xsl:template name="type-resolver">
		<xsl:param name="input" />
		<xsl:value-of select="$input" />
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
				<xsl:when test="self::cs-n:FieldDeclaration">
					<xsl:text>Field</xsl:text>
				</xsl:when>
				<xsl:when test="self::cs-n:ConstructorDeclaration">
					<xsl:text>Constructor</xsl:text>
				</xsl:when>

				<xsl:otherwise>
					<xsl:value-of select="local-name($input)"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:variable name="access" >
			<xsl:for-each select="$input/cs-t:*[not(self::cs-t:SemicolonToken)]">
				<xsl:variable name="temp">
					<xsl:choose>
						<xsl:when test="self::cs-t:StaticKeyword">
							<xsl:text>Static</xsl:text>
						</xsl:when>
						<xsl:when test="self::cs-t:ReadOnlyKeyword">
							<xsl:text>ReadOnly</xsl:text>
						</xsl:when>
						<xsl:when test="self::cs-t:AsyncKeyword">
							<xsl:text>Async</xsl:text>
						</xsl:when>

						<xsl:when test="self::cs-t:PublicKeyword">
							<xsl:text>Public</xsl:text>
						</xsl:when>
						<xsl:when test="self::cs-t:PrivateKeyword">
							<xsl:text>Private</xsl:text>
						</xsl:when>
						<xsl:when test="self::cs-t:InternalKeyword">
							<xsl:text>Internal</xsl:text>
						</xsl:when>
					</xsl:choose>
				</xsl:variable>
				<xsl:if test="$temp!=''">
					<xsl:value-of select="$temp" />
					&sp;
				</xsl:if>
			</xsl:for-each>
		</xsl:variable>
		<xsl:if test="$access!=''">
			<xsl:value-of select="$access" />
		</xsl:if>
		<xsl:value-of select="$type"  />
	</xsl:template>

	<xsl:template match="@* | node()" mode="copy">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="copy"/>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>
