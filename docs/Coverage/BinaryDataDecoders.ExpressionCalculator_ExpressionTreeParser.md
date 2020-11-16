# ExpressionTreeParser

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `ExpressionTreeParser`                    |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator` |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `360`                                     |
| Coverablelines  | `360`                                     |
| Totallines      | `648`                                     |
| Linecoverage    | `0`                                       |
| Coveredbranches | `0`                                       |
| Totalbranches   | `89`                                      |
| Branchcoverage  | `0`                                       |

## Metrics

| Complexity | Lines | Branches | Name                                   |
| :--------- | :---- | :------- | :------------------------------------- |
| 2          | 0     | 0        | `cctor`                                |
| 1          | 0     | 100      | `get_Vocabulary`                       |
| 1          | 0     | 100      | `get_GrammarFileName`                  |
| 1          | 0     | 100      | `get_RuleNames`                        |
| 1          | 0     | 100      | `get_SerializedAtn`                    |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `expression`                           |
| 1          | 0     | 100      | `Eof`                                  |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 0     | 0        | `Accept`                               |
| 1          | 0     | 100      | `start`                                |
| 1          | 0     | 100      | `NUMBER`                               |
| 1          | 0     | 100      | `VARIABLE`                             |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 0     | 0        | `Accept`                               |
| 4          | 0     | 0        | `value`                                |
| 1          | 0     | 100      | `expression`                           |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 0     | 0        | `Accept`                               |
| 4          | 0     | 0        | `innerExpression`                      |
| 1          | 0     | 100      | `SUB`                                  |
| 1          | 0     | 100      | `value`                                |
| 1          | 0     | 100      | `innerExpression`                      |
| 1          | 0     | 100      | `unaryOperatorLeftExpression`          |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 0     | 0        | `Accept`                               |
| 10         | 0     | 0        | `unaryOperatorLeftExpression`          |
| 1          | 0     | 100      | `value`                                |
| 1          | 0     | 100      | `FACTORIAL`                            |
| 1          | 0     | 100      | `innerExpression`                      |
| 1          | 0     | 100      | `unaryOperatorRightExpression`         |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 0     | 0        | `Accept`                               |
| 1          | 0     | 100      | `unaryOperatorRightExpression`         |
| 16         | 0     | 0        | `unaryOperatorRightExpression`         |
| 1          | 0     | 100      | `value`                                |
| 1          | 0     | 100      | `unaryOperatorLeftExpression`          |
| 1          | 0     | 100      | `unaryOperatorRightExpression`         |
| 1          | 0     | 100      | `innerExpression`                      |
| 1          | 0     | 100      | `expression`                           |
| 1          | 0     | 100      | `expression`                           |
| 1          | 0     | 100      | `POW`                                  |
| 1          | 0     | 100      | `MUL`                                  |
| 1          | 0     | 100      | `DIV`                                  |
| 1          | 0     | 100      | `MOD`                                  |
| 1          | 0     | 100      | `ADD`                                  |
| 1          | 0     | 100      | `SUB`                                  |
| 1          | 0     | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 0     | 0        | `Accept`                               |
| 1          | 0     | 100      | `expression`                           |
| 31         | 0     | 0        | `expression`                           |
| 4          | 0     | 0        | `Sempred`                              |
| 2          | 0     | 0        | `unaryOperatorRightExpression_sempred` |
| 4          | 0     | 0        | `expression_sempred`                   |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\obj\Release\netstandard2.1\ExpressionTreeParser.cs

```CSharp
〰1:   //------------------------------------------------------------------------------
〰2:   // <auto-generated>
〰3:   //     This code was generated by a tool.
〰4:   //     ANTLR Version: 4.8
〰5:   //
〰6:   //     Changes to this file may cause incorrect behavior and will be lost if
〰7:   //     the code is regenerated.
〰8:   // </auto-generated>
〰9:   //------------------------------------------------------------------------------
〰10:  
〰11:  // Generated from C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Parser\ExpressionTree.g4 by ANTLR 4.8
〰12:  
〰13:  // Unreachable code detected
〰14:  #pragma warning disable 0162
〰15:  // The variable '...' is assigned but its value is never used
〰16:  #pragma warning disable 0219
〰17:  // Missing XML comment for publicly visible type or member '...'
〰18:  #pragma warning disable 1591
〰19:  // Ambiguous reference in cref attribute
〰20:  #pragma warning disable 419
〰21:  
〰22:  using System;
〰23:  using System.IO;
〰24:  using System.Text;
〰25:  using System.Diagnostics;
〰26:  using System.Collections.Generic;
〰27:  using Antlr4.Runtime;
〰28:  using Antlr4.Runtime.Atn;
〰29:  using Antlr4.Runtime.Misc;
〰30:  using Antlr4.Runtime.Tree;
〰31:  using DFA = Antlr4.Runtime.Dfa.DFA;
〰32:  
〰33:  [System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
〰34:  [System.CLSCompliant(false)]
〰35:  public partial class ExpressionTreeParser : Parser {
〰36:  	protected static DFA[] decisionToDFA;
‼37:  	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
〰38:  	public const int
〰39:  		T__0=1, T__1=2, T__2=3, T__3=4, POW=5, MUL=6, DIV=7, ADD=8, SUB=9, MOD=10,
〰40:  		FACTORIAL=11, NUMBER=12, VARIABLE=13, WHITESPACE=14;
〰41:  	public const int
〰42:  		RULE_start = 0, RULE_value = 1, RULE_innerExpression = 2, RULE_unaryOperatorLeftExpression = 3,
〰43:  		RULE_unaryOperatorRightExpression = 4, RULE_expression = 5;
‼44:  	public static readonly string[] ruleNames = {
‼45:  		"start", "value", "innerExpression", "unaryOperatorLeftExpression", "unaryOperatorRightExpression",
‼46:  		"expression"
‼47:  	};
〰48:  
‼49:  	private static readonly string[] _LiteralNames = {
‼50:  		null, "'['", "']'", "'('", "')'", "'^'", "'*'", "'/'", "'+'", "'-'", "'%'",
‼51:  		"'!'"
‼52:  	};
‼53:  	private static readonly string[] _SymbolicNames = {
‼54:  		null, null, null, null, null, "POW", "MUL", "DIV", "ADD", "SUB", "MOD",
‼55:  		"FACTORIAL", "NUMBER", "VARIABLE", "WHITESPACE"
‼56:  	};
‼57:  	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);
〰58:  
〰59:  	[NotNull]
〰60:  	public override IVocabulary Vocabulary
〰61:  	{
〰62:  		get
〰63:  		{
‼64:  			return DefaultVocabulary;
〰65:  		}
〰66:  	}
〰67:  
‼68:  	public override string GrammarFileName { get { return "ExpressionTree.g4"; } }
〰69:  
‼70:  	public override string[] RuleNames { get { return ruleNames; } }
〰71:  
‼72:  	public override string SerializedAtn { get { return new string(_serializedATN); } }
〰73:  
〰74:  	static ExpressionTreeParser() {
‼75:  		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
‼76:  		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
‼77:  			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
〰78:  		}
‼79:  	}
〰80:  
‼81:  		public ExpressionTreeParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }
〰82:  
〰83:  		public ExpressionTreeParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
‼84:  		: base(input, output, errorOutput)
〰85:  	{
‼86:  		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
‼87:  	}
〰88:  
〰89:  	public partial class StartContext : ParserRuleContext {
〰90:  		public ExpressionContext expression() {
‼91:  			return GetRuleContext<ExpressionContext>(0);
〰92:  		}
‼93:  		public ITerminalNode Eof() { return GetToken(ExpressionTreeParser.Eof, 0); }
〰94:  		public StartContext(ParserRuleContext parent, int invokingState)
‼95:  			: base(parent, invokingState)
〰96:  		{
‼97:  		}
‼98:  		public override int RuleIndex { get { return RULE_start; } }
〰99:  		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
‼100: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
‼101: 			if (typedVisitor != null) return typedVisitor.VisitStart(this);
‼102: 			else return visitor.VisitChildren(this);
〰103: 		}
〰104: 	}
〰105: 
〰106: 	[RuleVersion(0)]
〰107: 	public StartContext start() {
‼108: 		StartContext _localctx = new StartContext(Context, State);
‼109: 		EnterRule(_localctx, 0, RULE_start);
〰110: 		try {
‼111: 			EnterOuterAlt(_localctx, 1);
〰112: 			{
‼113: 			State = 12; expression(0);
‼114: 			State = 13; Match(Eof);
〰115: 			}
‼116: 		}
‼117: 		catch (RecognitionException re) {
‼118: 			_localctx.exception = re;
‼119: 			ErrorHandler.ReportError(this, re);
‼120: 			ErrorHandler.Recover(this, re);
‼121: 		}
〰122: 		finally {
‼123: 			ExitRule();
‼124: 		}
‼125: 		return _localctx;
〰126: 	}
〰127: 
〰128: 	public partial class ValueContext : ParserRuleContext {
‼129: 		public ITerminalNode NUMBER() { return GetToken(ExpressionTreeParser.NUMBER, 0); }
‼130: 		public ITerminalNode VARIABLE() { return GetToken(ExpressionTreeParser.VARIABLE, 0); }
〰131: 		public ValueContext(ParserRuleContext parent, int invokingState)
‼132: 			: base(parent, invokingState)
〰133: 		{
‼134: 		}
‼135: 		public override int RuleIndex { get { return RULE_value; } }
〰136: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
‼137: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
‼138: 			if (typedVisitor != null) return typedVisitor.VisitValue(this);
‼139: 			else return visitor.VisitChildren(this);
〰140: 		}
〰141: 	}
〰142: 
〰143: 	[RuleVersion(0)]
〰144: 	public ValueContext value() {
‼145: 		ValueContext _localctx = new ValueContext(Context, State);
‼146: 		EnterRule(_localctx, 2, RULE_value);
〰147: 		int _la;
〰148: 		try {
‼149: 			EnterOuterAlt(_localctx, 1);
〰150: 			{
‼151: 			State = 15;
‼152: 			_la = TokenStream.LA(1);
‼153: 			if ( !(_la==NUMBER || _la==VARIABLE) ) {
‼154: 			ErrorHandler.RecoverInline(this);
〰155: 			}
〰156: 			else {
‼157: 				ErrorHandler.ReportMatch(this);
‼158: 			    Consume();
〰159: 			}
〰160: 			}
‼161: 		}
‼162: 		catch (RecognitionException re) {
‼163: 			_localctx.exception = re;
‼164: 			ErrorHandler.ReportError(this, re);
‼165: 			ErrorHandler.Recover(this, re);
‼166: 		}
〰167: 		finally {
‼168: 			ExitRule();
‼169: 		}
‼170: 		return _localctx;
〰171: 	}
〰172: 
〰173: 	public partial class InnerExpressionContext : ParserRuleContext {
〰174: 		public ExpressionContext inner;
〰175: 		public ExpressionContext expression() {
‼176: 			return GetRuleContext<ExpressionContext>(0);
〰177: 		}
〰178: 		public InnerExpressionContext(ParserRuleContext parent, int invokingState)
‼179: 			: base(parent, invokingState)
〰180: 		{
‼181: 		}
‼182: 		public override int RuleIndex { get { return RULE_innerExpression; } }
〰183: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
‼184: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
‼185: 			if (typedVisitor != null) return typedVisitor.VisitInnerExpression(this);
‼186: 			else return visitor.VisitChildren(this);
〰187: 		}
〰188: 	}
〰189: 
〰190: 	[RuleVersion(0)]
〰191: 	public InnerExpressionContext innerExpression() {
‼192: 		InnerExpressionContext _localctx = new InnerExpressionContext(Context, State);
‼193: 		EnterRule(_localctx, 4, RULE_innerExpression);
〰194: 		try {
‼195: 			State = 25;
‼196: 			ErrorHandler.Sync(this);
‼197: 			switch (TokenStream.LA(1)) {
〰198: 			case T__0:
‼199: 				EnterOuterAlt(_localctx, 1);
〰200: 				{
‼201: 				State = 17; Match(T__0);
‼202: 				State = 18; _localctx.inner = expression(0);
‼203: 				State = 19; Match(T__1);
〰204: 				}
‼205: 				break;
〰206: 			case T__2:
‼207: 				EnterOuterAlt(_localctx, 2);
〰208: 				{
‼209: 				State = 21; Match(T__2);
‼210: 				State = 22; _localctx.inner = expression(0);
‼211: 				State = 23; Match(T__3);
〰212: 				}
‼213: 				break;
〰214: 			default:
‼215: 				throw new NoViableAltException(this);
〰216: 			}
‼217: 		}
‼218: 		catch (RecognitionException re) {
‼219: 			_localctx.exception = re;
‼220: 			ErrorHandler.ReportError(this, re);
‼221: 			ErrorHandler.Recover(this, re);
‼222: 		}
〰223: 		finally {
‼224: 			ExitRule();
‼225: 		}
‼226: 		return _localctx;
〰227: 	}
〰228: 
〰229: 	public partial class UnaryOperatorLeftExpressionContext : ParserRuleContext {
〰230: 		public IToken @operator;
‼231: 		public ITerminalNode SUB() { return GetToken(ExpressionTreeParser.SUB, 0); }
〰232: 		public ValueContext value() {
‼233: 			return GetRuleContext<ValueContext>(0);
〰234: 		}
〰235: 		public InnerExpressionContext innerExpression() {
‼236: 			return GetRuleContext<InnerExpressionContext>(0);
〰237: 		}
〰238: 		public UnaryOperatorLeftExpressionContext unaryOperatorLeftExpression() {
‼239: 			return GetRuleContext<UnaryOperatorLeftExpressionContext>(0);
〰240: 		}
〰241: 		public UnaryOperatorLeftExpressionContext(ParserRuleContext parent, int invokingState)
‼242: 			: base(parent, invokingState)
〰243: 		{
‼244: 		}
‼245: 		public override int RuleIndex { get { return RULE_unaryOperatorLeftExpression; } }
〰246: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
‼247: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
‼248: 			if (typedVisitor != null) return typedVisitor.VisitUnaryOperatorLeftExpression(this);
‼249: 			else return visitor.VisitChildren(this);
〰250: 		}
〰251: 	}
〰252: 
〰253: 	[RuleVersion(0)]
〰254: 	public UnaryOperatorLeftExpressionContext unaryOperatorLeftExpression() {
‼255: 		UnaryOperatorLeftExpressionContext _localctx = new UnaryOperatorLeftExpressionContext(Context, State);
‼256: 		EnterRule(_localctx, 6, RULE_unaryOperatorLeftExpression);
〰257: 		try {
‼258: 			EnterOuterAlt(_localctx, 1);
〰259: 			{
‼260: 			State = 27; _localctx.@operator = Match(SUB);
‼261: 			State = 31;
‼262: 			ErrorHandler.Sync(this);
‼263: 			switch (TokenStream.LA(1)) {
〰264: 			case NUMBER:
〰265: 			case VARIABLE:
〰266: 				{
‼267: 				State = 28; value();
〰268: 				}
‼269: 				break;
〰270: 			case T__0:
〰271: 			case T__2:
〰272: 				{
‼273: 				State = 29; innerExpression();
〰274: 				}
‼275: 				break;
〰276: 			case SUB:
〰277: 				{
‼278: 				State = 30; unaryOperatorLeftExpression();
〰279: 				}
‼280: 				break;
〰281: 			default:
‼282: 				throw new NoViableAltException(this);
〰283: 			}
〰284: 			}
‼285: 		}
‼286: 		catch (RecognitionException re) {
‼287: 			_localctx.exception = re;
‼288: 			ErrorHandler.ReportError(this, re);
‼289: 			ErrorHandler.Recover(this, re);
‼290: 		}
〰291: 		finally {
‼292: 			ExitRule();
‼293: 		}
‼294: 		return _localctx;
〰295: 	}
〰296: 
〰297: 	public partial class UnaryOperatorRightExpressionContext : ParserRuleContext {
〰298: 		public IToken @operator;
〰299: 		public ValueContext value() {
‼300: 			return GetRuleContext<ValueContext>(0);
〰301: 		}
‼302: 		public ITerminalNode FACTORIAL() { return GetToken(ExpressionTreeParser.FACTORIAL, 0); }
〰303: 		public InnerExpressionContext innerExpression() {
‼304: 			return GetRuleContext<InnerExpressionContext>(0);
〰305: 		}
〰306: 		public UnaryOperatorRightExpressionContext unaryOperatorRightExpression() {
‼307: 			return GetRuleContext<UnaryOperatorRightExpressionContext>(0);
〰308: 		}
〰309: 		public UnaryOperatorRightExpressionContext(ParserRuleContext parent, int invokingState)
‼310: 			: base(parent, invokingState)
〰311: 		{
‼312: 		}
‼313: 		public override int RuleIndex { get { return RULE_unaryOperatorRightExpression; } }
〰314: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
‼315: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
‼316: 			if (typedVisitor != null) return typedVisitor.VisitUnaryOperatorRightExpression(this);
‼317: 			else return visitor.VisitChildren(this);
〰318: 		}
〰319: 	}
〰320: 
〰321: 	[RuleVersion(0)]
〰322: 	public UnaryOperatorRightExpressionContext unaryOperatorRightExpression() {
‼323: 		return unaryOperatorRightExpression(0);
〰324: 	}
〰325: 
〰326: 	private UnaryOperatorRightExpressionContext unaryOperatorRightExpression(int _p) {
‼327: 		ParserRuleContext _parentctx = Context;
‼328: 		int _parentState = State;
‼329: 		UnaryOperatorRightExpressionContext _localctx = new UnaryOperatorRightExpressionContext(Context, _parentState);
〰330: 		UnaryOperatorRightExpressionContext _prevctx = _localctx;
‼331: 		int _startState = 8;
‼332: 		EnterRecursionRule(_localctx, 8, RULE_unaryOperatorRightExpression, _p);
〰333: 		try {
〰334: 			int _alt;
‼335: 			EnterOuterAlt(_localctx, 1);
〰336: 			{
‼337: 			State = 40;
‼338: 			ErrorHandler.Sync(this);
‼339: 			switch (TokenStream.LA(1)) {
〰340: 			case NUMBER:
〰341: 			case VARIABLE:
〰342: 				{
‼343: 				State = 34; value();
‼344: 				State = 35; _localctx.@operator = Match(FACTORIAL);
〰345: 				}
‼346: 				break;
〰347: 			case T__0:
〰348: 			case T__2:
〰349: 				{
‼350: 				State = 37; innerExpression();
‼351: 				State = 38; _localctx.@operator = Match(FACTORIAL);
〰352: 				}
‼353: 				break;
〰354: 			default:
‼355: 				throw new NoViableAltException(this);
〰356: 			}
‼357: 			Context.Stop = TokenStream.LT(-1);
‼358: 			State = 46;
‼359: 			ErrorHandler.Sync(this);
‼360: 			_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
‼361: 			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
‼362: 				if ( _alt==1 ) {
‼363: 					if ( ParseListeners!=null )
‼364: 						TriggerExitRuleEvent();
〰365: 					_prevctx = _localctx;
〰366: 					{
〰367: 					{
‼368: 					_localctx = new UnaryOperatorRightExpressionContext(_parentctx, _parentState);
‼369: 					PushNewRecursionContext(_localctx, _startState, RULE_unaryOperatorRightExpression);
‼370: 					State = 42;
‼371: 					if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
‼372: 					State = 43; _localctx.@operator = Match(FACTORIAL);
〰373: 					}
〰374: 					}
〰375: 				}
‼376: 				State = 48;
‼377: 				ErrorHandler.Sync(this);
‼378: 				_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
〰379: 			}
〰380: 			}
‼381: 		}
‼382: 		catch (RecognitionException re) {
‼383: 			_localctx.exception = re;
‼384: 			ErrorHandler.ReportError(this, re);
‼385: 			ErrorHandler.Recover(this, re);
‼386: 		}
〰387: 		finally {
‼388: 			UnrollRecursionContexts(_parentctx);
‼389: 		}
‼390: 		return _localctx;
〰391: 	}
〰392: 
〰393: 	public partial class ExpressionContext : ParserRuleContext {
〰394: 		public ExpressionContext left;
〰395: 		public IToken @operator;
〰396: 		public ExpressionContext right;
〰397: 		public ValueContext value() {
‼398: 			return GetRuleContext<ValueContext>(0);
〰399: 		}
〰400: 		public UnaryOperatorLeftExpressionContext unaryOperatorLeftExpression() {
‼401: 			return GetRuleContext<UnaryOperatorLeftExpressionContext>(0);
〰402: 		}
〰403: 		public UnaryOperatorRightExpressionContext unaryOperatorRightExpression() {
‼404: 			return GetRuleContext<UnaryOperatorRightExpressionContext>(0);
〰405: 		}
〰406: 		public InnerExpressionContext innerExpression() {
‼407: 			return GetRuleContext<InnerExpressionContext>(0);
〰408: 		}
〰409: 		public ExpressionContext[] expression() {
‼410: 			return GetRuleContexts<ExpressionContext>();
〰411: 		}
〰412: 		public ExpressionContext expression(int i) {
‼413: 			return GetRuleContext<ExpressionContext>(i);
〰414: 		}
‼415: 		public ITerminalNode POW() { return GetToken(ExpressionTreeParser.POW, 0); }
‼416: 		public ITerminalNode MUL() { return GetToken(ExpressionTreeParser.MUL, 0); }
‼417: 		public ITerminalNode DIV() { return GetToken(ExpressionTreeParser.DIV, 0); }
‼418: 		public ITerminalNode MOD() { return GetToken(ExpressionTreeParser.MOD, 0); }
‼419: 		public ITerminalNode ADD() { return GetToken(ExpressionTreeParser.ADD, 0); }
‼420: 		public ITerminalNode SUB() { return GetToken(ExpressionTreeParser.SUB, 0); }
〰421: 		public ExpressionContext(ParserRuleContext parent, int invokingState)
‼422: 			: base(parent, invokingState)
〰423: 		{
‼424: 		}
‼425: 		public override int RuleIndex { get { return RULE_expression; } }
〰426: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
‼427: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
‼428: 			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
‼429: 			else return visitor.VisitChildren(this);
〰430: 		}
〰431: 	}
〰432: 
〰433: 	[RuleVersion(0)]
〰434: 	public ExpressionContext expression() {
‼435: 		return expression(0);
〰436: 	}
〰437: 
〰438: 	private ExpressionContext expression(int _p) {
‼439: 		ParserRuleContext _parentctx = Context;
‼440: 		int _parentState = State;
‼441: 		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
‼442: 		ExpressionContext _prevctx = _localctx;
‼443: 		int _startState = 10;
‼444: 		EnterRecursionRule(_localctx, 10, RULE_expression, _p);
〰445: 		int _la;
〰446: 		try {
〰447: 			int _alt;
‼448: 			EnterOuterAlt(_localctx, 1);
〰449: 			{
‼450: 			State = 54;
‼451: 			ErrorHandler.Sync(this);
‼452: 			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
〰453: 			case 1:
〰454: 				{
‼455: 				State = 50; value();
〰456: 				}
‼457: 				break;
〰458: 			case 2:
〰459: 				{
‼460: 				State = 51; unaryOperatorLeftExpression();
〰461: 				}
‼462: 				break;
〰463: 			case 3:
〰464: 				{
‼465: 				State = 52; unaryOperatorRightExpression(0);
〰466: 				}
‼467: 				break;
〰468: 			case 4:
〰469: 				{
‼470: 				State = 53; innerExpression();
〰471: 				}
〰472: 				break;
〰473: 			}
‼474: 			Context.Stop = TokenStream.LT(-1);
‼475: 			State = 67;
‼476: 			ErrorHandler.Sync(this);
‼477: 			_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
‼478: 			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
‼479: 				if ( _alt==1 ) {
‼480: 					if ( ParseListeners!=null )
‼481: 						TriggerExitRuleEvent();
‼482: 					_prevctx = _localctx;
〰483: 					{
‼484: 					State = 65;
‼485: 					ErrorHandler.Sync(this);
‼486: 					switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
〰487: 					case 1:
〰488: 						{
‼489: 						_localctx = new ExpressionContext(_parentctx, _parentState);
‼490: 						_localctx.left = _prevctx;
‼491: 						PushNewRecursionContext(_localctx, _startState, RULE_expression);
‼492: 						State = 56;
‼493: 						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
‼494: 						State = 57; _localctx.@operator = Match(POW);
‼495: 						State = 58; _localctx.right = expression(4);
〰496: 						}
‼497: 						break;
〰498: 					case 2:
〰499: 						{
‼500: 						_localctx = new ExpressionContext(_parentctx, _parentState);
‼501: 						_localctx.left = _prevctx;
‼502: 						PushNewRecursionContext(_localctx, _startState, RULE_expression);
‼503: 						State = 59;
‼504: 						if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
‼505: 						State = 60;
‼506: 						_localctx.@operator = TokenStream.LT(1);
‼507: 						_la = TokenStream.LA(1);
‼508: 						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << MUL) | (1L << DIV) | (1L << MOD))) != 0)) ) {
‼509: 							_localctx.@operator = ErrorHandler.RecoverInline(this);
〰510: 						}
〰511: 						else {
‼512: 							ErrorHandler.ReportMatch(this);
‼513: 						    Consume();
〰514: 						}
‼515: 						State = 61; _localctx.right = expression(3);
〰516: 						}
‼517: 						break;
〰518: 					case 3:
〰519: 						{
‼520: 						_localctx = new ExpressionContext(_parentctx, _parentState);
‼521: 						_localctx.left = _prevctx;
‼522: 						PushNewRecursionContext(_localctx, _startState, RULE_expression);
‼523: 						State = 62;
‼524: 						if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
‼525: 						State = 63;
‼526: 						_localctx.@operator = TokenStream.LT(1);
‼527: 						_la = TokenStream.LA(1);
‼528: 						if ( !(_la==ADD || _la==SUB) ) {
‼529: 							_localctx.@operator = ErrorHandler.RecoverInline(this);
〰530: 						}
〰531: 						else {
‼532: 							ErrorHandler.ReportMatch(this);
‼533: 						    Consume();
〰534: 						}
‼535: 						State = 64; _localctx.right = expression(2);
〰536: 						}
〰537: 						break;
〰538: 					}
〰539: 					}
〰540: 				}
‼541: 				State = 69;
‼542: 				ErrorHandler.Sync(this);
‼543: 				_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
〰544: 			}
〰545: 			}
‼546: 		}
‼547: 		catch (RecognitionException re) {
‼548: 			_localctx.exception = re;
‼549: 			ErrorHandler.ReportError(this, re);
‼550: 			ErrorHandler.Recover(this, re);
‼551: 		}
〰552: 		finally {
‼553: 			UnrollRecursionContexts(_parentctx);
‼554: 		}
‼555: 		return _localctx;
〰556: 	}
〰557: 
〰558: 	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
〰559: 		switch (ruleIndex) {
‼560: 		case 4: return unaryOperatorRightExpression_sempred((UnaryOperatorRightExpressionContext)_localctx, predIndex);
‼561: 		case 5: return expression_sempred((ExpressionContext)_localctx, predIndex);
〰562: 		}
‼563: 		return true;
〰564: 	}
〰565: 	private bool unaryOperatorRightExpression_sempred(UnaryOperatorRightExpressionContext _localctx, int predIndex) {
〰566: 		switch (predIndex) {
‼567: 		case 0: return Precpred(Context, 1);
〰568: 		}
‼569: 		return true;
〰570: 	}
〰571: 	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
〰572: 		switch (predIndex) {
‼573: 		case 1: return Precpred(Context, 3);
‼574: 		case 2: return Precpred(Context, 2);
‼575: 		case 3: return Precpred(Context, 1);
〰576: 		}
‼577: 		return true;
〰578: 	}
〰579: 
‼580: 	private static char[] _serializedATN = {
‼581: 		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786',
‼582: 		'\x5964', '\x3', '\x10', 'I', '\x4', '\x2', '\t', '\x2', '\x4', '\x3',
‼583: 		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4',
‼584: 		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', '\x2',
‼585: 		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4',
‼586: 		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4',
‼587: 		'\x3', '\x4', '\x5', '\x4', '\x1C', '\n', '\x4', '\x3', '\x5', '\x3',
‼588: 		'\x5', '\x3', '\x5', '\x3', '\x5', '\x5', '\x5', '\"', '\n', '\x5', '\x3',
‼589: 		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3',
‼590: 		'\x6', '\x3', '\x6', '\x5', '\x6', '+', '\n', '\x6', '\x3', '\x6', '\x3',
‼591: 		'\x6', '\a', '\x6', '/', '\n', '\x6', '\f', '\x6', '\xE', '\x6', '\x32',
‼592: 		'\v', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3',
‼593: 		'\a', '\x5', '\a', '\x39', '\n', '\a', '\x3', '\a', '\x3', '\a', '\x3',
‼594: 		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a',
‼595: 		'\x3', '\a', '\a', '\a', '\x44', '\n', '\a', '\f', '\a', '\xE', '\a',
‼596: 		'G', '\v', '\a', '\x3', '\a', '\x2', '\x4', '\n', '\f', '\b', '\x2', '\x4',
‼597: 		'\x6', '\b', '\n', '\f', '\x2', '\x5', '\x3', '\x2', '\xE', '\xF', '\x4',
‼598: 		'\x2', '\b', '\t', '\f', '\f', '\x3', '\x2', '\n', '\v', '\x2', 'M', '\x2',
‼599: 		'\xE', '\x3', '\x2', '\x2', '\x2', '\x4', '\x11', '\x3', '\x2', '\x2',
‼600: 		'\x2', '\x6', '\x1B', '\x3', '\x2', '\x2', '\x2', '\b', '\x1D', '\x3',
‼601: 		'\x2', '\x2', '\x2', '\n', '*', '\x3', '\x2', '\x2', '\x2', '\f', '\x38',
‼602: 		'\x3', '\x2', '\x2', '\x2', '\xE', '\xF', '\x5', '\f', '\a', '\x2', '\xF',
‼603: 		'\x10', '\a', '\x2', '\x2', '\x3', '\x10', '\x3', '\x3', '\x2', '\x2',
‼604: 		'\x2', '\x11', '\x12', '\t', '\x2', '\x2', '\x2', '\x12', '\x5', '\x3',
‼605: 		'\x2', '\x2', '\x2', '\x13', '\x14', '\a', '\x3', '\x2', '\x2', '\x14',
‼606: 		'\x15', '\x5', '\f', '\a', '\x2', '\x15', '\x16', '\a', '\x4', '\x2',
‼607: 		'\x2', '\x16', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', '\a',
‼608: 		'\x5', '\x2', '\x2', '\x18', '\x19', '\x5', '\f', '\a', '\x2', '\x19',
‼609: 		'\x1A', '\a', '\x6', '\x2', '\x2', '\x1A', '\x1C', '\x3', '\x2', '\x2',
‼610: 		'\x2', '\x1B', '\x13', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x17', '\x3',
‼611: 		'\x2', '\x2', '\x2', '\x1C', '\a', '\x3', '\x2', '\x2', '\x2', '\x1D',
‼612: 		'!', '\a', '\v', '\x2', '\x2', '\x1E', '\"', '\x5', '\x4', '\x3', '\x2',
‼613: 		'\x1F', '\"', '\x5', '\x6', '\x4', '\x2', ' ', '\"', '\x5', '\b', '\x5',
‼614: 		'\x2', '!', '\x1E', '\x3', '\x2', '\x2', '\x2', '!', '\x1F', '\x3', '\x2',
‼615: 		'\x2', '\x2', '!', ' ', '\x3', '\x2', '\x2', '\x2', '\"', '\t', '\x3',
‼616: 		'\x2', '\x2', '\x2', '#', '$', '\b', '\x6', '\x1', '\x2', '$', '%', '\x5',
‼617: 		'\x4', '\x3', '\x2', '%', '&', '\a', '\r', '\x2', '\x2', '&', '+', '\x3',
‼618: 		'\x2', '\x2', '\x2', '\'', '(', '\x5', '\x6', '\x4', '\x2', '(', ')',
‼619: 		'\a', '\r', '\x2', '\x2', ')', '+', '\x3', '\x2', '\x2', '\x2', '*', '#',
‼620: 		'\x3', '\x2', '\x2', '\x2', '*', '\'', '\x3', '\x2', '\x2', '\x2', '+',
‼621: 		'\x30', '\x3', '\x2', '\x2', '\x2', ',', '-', '\f', '\x3', '\x2', '\x2',
‼622: 		'-', '/', '\a', '\r', '\x2', '\x2', '.', ',', '\x3', '\x2', '\x2', '\x2',
‼623: 		'/', '\x32', '\x3', '\x2', '\x2', '\x2', '\x30', '.', '\x3', '\x2', '\x2',
‼624: 		'\x2', '\x30', '\x31', '\x3', '\x2', '\x2', '\x2', '\x31', '\v', '\x3',
‼625: 		'\x2', '\x2', '\x2', '\x32', '\x30', '\x3', '\x2', '\x2', '\x2', '\x33',
‼626: 		'\x34', '\b', '\a', '\x1', '\x2', '\x34', '\x39', '\x5', '\x4', '\x3',
‼627: 		'\x2', '\x35', '\x39', '\x5', '\b', '\x5', '\x2', '\x36', '\x39', '\x5',
‼628: 		'\n', '\x6', '\x2', '\x37', '\x39', '\x5', '\x6', '\x4', '\x2', '\x38',
‼629: 		'\x33', '\x3', '\x2', '\x2', '\x2', '\x38', '\x35', '\x3', '\x2', '\x2',
‼630: 		'\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', '\x37', '\x3',
‼631: 		'\x2', '\x2', '\x2', '\x39', '\x45', '\x3', '\x2', '\x2', '\x2', ':',
‼632: 		';', '\f', '\x5', '\x2', '\x2', ';', '<', '\a', '\a', '\x2', '\x2', '<',
‼633: 		'\x44', '\x5', '\f', '\a', '\x6', '=', '>', '\f', '\x4', '\x2', '\x2',
‼634: 		'>', '?', '\t', '\x3', '\x2', '\x2', '?', '\x44', '\x5', '\f', '\a', '\x5',
‼635: 		'@', '\x41', '\f', '\x3', '\x2', '\x2', '\x41', '\x42', '\t', '\x4', '\x2',
‼636: 		'\x2', '\x42', '\x44', '\x5', '\f', '\a', '\x4', '\x43', ':', '\x3', '\x2',
‼637: 		'\x2', '\x2', '\x43', '=', '\x3', '\x2', '\x2', '\x2', '\x43', '@', '\x3',
‼638: 		'\x2', '\x2', '\x2', '\x44', 'G', '\x3', '\x2', '\x2', '\x2', '\x45',
‼639: 		'\x43', '\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\x3', '\x2', '\x2',
‼640: 		'\x2', '\x46', '\r', '\x3', '\x2', '\x2', '\x2', 'G', '\x45', '\x3', '\x2',
‼641: 		'\x2', '\x2', '\t', '\x1B', '!', '*', '\x30', '\x38', '\x43', '\x45',
‼642: 	};
〰643: 
‼644: 	public static readonly ATN _ATN =
‼645: 		new ATNDeserializer().Deserialize(_serializedATN);
〰646: 
〰647: 
〰648: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

