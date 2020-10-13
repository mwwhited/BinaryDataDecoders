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

	<xsl:template match="cs-n:ClassDeclaration|cs-n:StructDeclaration|cs-n:InterfaceDeclaration|cs-n:EnumDeclaration">
		<xsl:variable name="type">
			<xsl:choose>
				<xsl:when test="local-name(.)='ClassDeclaration'"><xsl:text>Class</xsl:text></xsl:when>
				<xsl:when test="local-name(.)='StructDeclaration'"><xsl:text>Structure</xsl:text></xsl:when>
				<xsl:when test="local-name(.)='InterfaceDeclaration'"><xsl:text>Interface</xsl:text></xsl:when>
				<xsl:when test="local-name(.)='EnumDeclaration'"><xsl:text>Enumeration</xsl:text></xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="local-name(.)"/>
				</xsl:otherwise>
			</xsl:choose>		
		</xsl:variable>

		<xsl:text>## </xsl:text><xsl:value-of select="$type" /><xsl:text>: </xsl:text><xsl:value-of select="cs-t:IdentifierToken[1]" />&cr;&cr;
		<!--<xsl:text>Namespace: </xsl:text><xsl:value-of select="../cs-n:QualifiedName/descendant::text()" />&cr;-->

		<xsl:apply-templates select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />

		<xsl:apply-templates select="cs-n:MethodDeclaration[cs-t:PublicKeyword or local-name(..)='InterfaceDeclaration']" />
		<xsl:apply-templates select="cs-n:FieldDeclaration[cs-t:PublicKeyword or local-name(..)='InterfaceDeclaration']" />			
		<xsl:apply-templates select="cs-n:PropertyDeclaration[cs-t:PublicKeyword or local-name(..)='InterfaceDeclaration']" />
		<xsl:apply-templates select="cs-n:EnumMemberDeclaration" />	
		
		<!--[cs-t:PublicKeyword or ../cs-n:InterfaceDeclaration]-->

		<!--cs-r:SingleLineDocumentationCommentTrivia-->
		<!--<xsl:apply-templates select="node()" mode="copy" />-->

	</xsl:template>

	<xsl:template match="cs-n:MethodDeclaration|cs-n:FieldDeclaration|cs-n:PropertyDeclaration|cs-n:EnumMemberDeclaration">
		<xsl:variable name="type">
			<xsl:choose>
				<xsl:when test="local-name(.)='MethodDeclaration'"><xsl:text>Method</xsl:text></xsl:when>
				<xsl:when test="local-name(.)='FieldDeclaration'"><xsl:text>Field</xsl:text></xsl:when>
				<xsl:when test="local-name(.)='PropertyDeclaration'"><xsl:text>Property</xsl:text></xsl:when>
				<xsl:when test="local-name(.)='EnumMemberDeclaration'"><xsl:text>Enumeration Member</xsl:text></xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="local-name(.)"/>
				</xsl:otherwise>
			</xsl:choose>		
		</xsl:variable>
		<xsl:text>### </xsl:text><xsl:value-of select="$type" /><xsl:text>: </xsl:text><xsl:value-of select="cs-t:IdentifierToken[1]" />&cr;&cr;

		<xsl:apply-templates select="descendant::cs-n:SingleLineDocumentationCommentTrivia[1]" />
	</xsl:template>
	
<!-- Field
	<VariableDeclaration RawKind="8794" Type="Node">
							<PredefinedType RawKind="8621" Type="Node">
								<ByteKeyword xp_0:Kind="SourceFile" xp_0:Start="1227" xp_0:End="1231" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">
									byte<WhitespaceTrivia Value=" " RawKind="8540" Type="Trivia" xmlns="bdd:CodeAnalysis/Trivia"> </WhitespaceTrivia>
								</ByteKeyword>
							</PredefinedType>
							<VariableDeclarator RawKind="8795" Type="Node">
								<IdentifierToken xp_0:Kind="SourceFile" xp_0:Start="1232" xp_0:End="1235" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">
									Dc3<WhitespaceTrivia Value=" " RawKind="8540" Type="Trivia" xmlns="bdd:CodeAnalysis/Trivia"> </WhitespaceTrivia>
								</IdentifierToken>
								<EqualsValueClause RawKind="8796" Type="Node">
									<EqualsToken xp_0:Kind="SourceFile" xp_0:Start="1236" xp_0:End="1237" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">
										=<WhitespaceTrivia Value=" " RawKind="8540" Type="Trivia" xmlns="bdd:CodeAnalysis/Trivia"> </WhitespaceTrivia>
									</EqualsToken>
									<CastExpression RawKind="8640" Type="Node">
										<OpenParenToken xp_0:Kind="SourceFile" xp_0:Start="1238" xp_0:End="1239" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">(</OpenParenToken>
										<PredefinedType RawKind="8621" Type="Node">
											<ByteKeyword xp_0:Kind="SourceFile" xp_0:Start="1239" xp_0:End="1243" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">byte</ByteKeyword>
										</PredefinedType>
										<CloseParenToken xp_0:Kind="SourceFile" xp_0:Start="1243" xp_0:End="1244" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">)</CloseParenToken>
										<SimpleMemberAccessExpression RawKind="8689" Type="Node">
											<IdentifierName RawKind="8616" Type="Node">
												<IdentifierToken xp_0:Kind="SourceFile" xp_0:Start="1244" xp_0:End="1261" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">ControlCharacters</IdentifierToken>
											</IdentifierName>
											<DotToken xp_0:Kind="SourceFile" xp_0:Start="1261" xp_0:End="1262" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">.</DotToken>
											<IdentifierName RawKind="8616" Type="Node">
												<IdentifierToken xp_0:Kind="SourceFile" xp_0:Start="1262" xp_0:End="1276" xmlns="bdd:CodeAnalysis/Token" xmlns:xp_0="bdd:CodeAnalysis/Token?Location">DeviceControl3</IdentifierToken>
											</IdentifierName>
										</SimpleMemberAccessExpression>
									</CastExpression>
								</EqualsValueClause>
							</VariableDeclarator>
						</VariableDeclaration>

		-->
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
