# ExpressionTreeParser

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `ExpressionTreeParser`                    |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator` |
| Coveredlines    | `267`                                     |
| Uncoveredlines  | `78`                                      |
| Coverablelines  | `345`                                     |
| Totallines      | `639`                                     |
| Linecoverage    | `77.3`                                    |
| Coveredbranches | `62`                                      |
| Totalbranches   | `89`                                      |
| Branchcoverage  | `69.6`                                    |
| Coveredmethods  | `30`                                      |
| Totalmethods    | `61`                                      |
| Methodcoverage  | `49.1`                                    |

## Metrics

| Complexity | Lines | Branches | Name                                   |
| :--------- | :---- | :------- | :------------------------------------- |
| 2          | 100   | 100      | `cctor`                                |
| 1          | 0     | 100      | `get_Vocabulary`                       |
| 1          | 0     | 100      | `get_GrammarFileName`                  |
| 1          | 0     | 100      | `get_RuleNames`                        |
| 1          | 0     | 100      | `get_SerializedAtn`                    |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 100   | 100      | `expression`                           |
| 1          | 0     | 100      | `Eof`                                  |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 66.66 | 50.0     | `Accept`                               |
| 1          | 68.75 | 100      | `start`                                |
| 1          | 100   | 100      | `NUMBER`                               |
| 1          | 100   | 100      | `VARIABLE`                             |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 66.66 | 50.0     | `Accept`                               |
| 4          | 66.66 | 75.00    | `value`                                |
| 1          | 0     | 100      | `expression`                           |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 66.66 | 50.0     | `Accept`                               |
| 4          | 54.83 | 50.0     | `innerExpression`                      |
| 1          | 0     | 100      | `SUB`                                  |
| 1          | 100   | 100      | `value`                                |
| 1          | 100   | 100      | `innerExpression`                      |
| 1          | 100   | 100      | `unaryOperatorLeftExpression`          |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 66.66 | 50.0     | `Accept`                               |
| 10         | 96.29 | 100      | `unaryOperatorLeftExpression`          |
| 1          | 100   | 100      | `value`                                |
| 1          | 0     | 100      | `FACTORIAL`                            |
| 1          | 100   | 100      | `innerExpression`                      |
| 1          | 100   | 100      | `unaryOperatorRightExpression`         |
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 66.66 | 50.0     | `Accept`                               |
| 1          | 0     | 100      | `unaryOperatorRightExpression`         |
| 16         | 86.95 | 87.50    | `unaryOperatorRightExpression`         |
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
| 1          | 100   | 100      | `ctor`                                 |
| 1          | 0     | 100      | `get_RuleIndex`                        |
| 2          | 66.66 | 50.0     | `Accept`                               |
| 1          | 0     | 100      | `expression`                           |
| 31         | 96.42 | 80.64    | `expression`                           |
| 4          | 0     | 0        | `Sempred`                              |
| 2          | 0     | 0        | `unaryOperatorRightExpression_sempred` |
| 4          | 0     | 0        | `expression_sempred`                   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/obj/Release/net7.0/ExpressionTreeParser.cs

```CSharp
〰1:   //------------------------------------------------------------------------------
〰2:   // <auto-generated>
〰3:   //     This code was generated by a tool.
〰4:   //     ANTLR Version: 4.12.0
〰5:   //
〰6:   //     Changes to this file may cause incorrect behavior and will be lost if
〰7:   //     the code is regenerated.
〰8:   // </auto-generated>
〰9:   //------------------------------------------------------------------------------
〰10:  
〰11:  // Generated from /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Parser/ExpressionTree.g4 by ANTLR 4.12.0
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
〰33:  [System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
〰34:  [System.CLSCompliant(false)]
〰35:  public partial class ExpressionTreeParser : Parser {
〰36:  	protected static DFA[] decisionToDFA;
✔37:  	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
〰38:  	public const int
〰39:  		T__0=1, T__1=2, T__2=3, T__3=4, POW=5, MUL=6, DIV=7, ADD=8, SUB=9, MOD=10,
〰40:  		FACTORIAL=11, NUMBER=12, VARIABLE=13, WHITESPACE=14;
〰41:  	public const int
〰42:  		RULE_start = 0, RULE_value = 1, RULE_innerExpression = 2, RULE_unaryOperatorLeftExpression = 3,
〰43:  		RULE_unaryOperatorRightExpression = 4, RULE_expression = 5;
✔44:  	public static readonly string[] ruleNames = {
✔45:  		"start", "value", "innerExpression", "unaryOperatorLeftExpression", "unaryOperatorRightExpression",
✔46:  		"expression"
✔47:  	};
〰48:  
✔49:  	private static readonly string[] _LiteralNames = {
✔50:  		null, "'['", "']'", "'('", "')'", "'^'", "'*'", "'/'", "'+'", "'-'", "'%'",
✔51:  		"'!'"
✔52:  	};
✔53:  	private static readonly string[] _SymbolicNames = {
✔54:  		null, null, null, null, null, "POW", "MUL", "DIV", "ADD", "SUB", "MOD",
✔55:  		"FACTORIAL", "NUMBER", "VARIABLE", "WHITESPACE"
✔56:  	};
✔57:  	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);
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
‼72:  	public override int[] SerializedAtn { get { return _serializedATN; } }
〰73:  
〰74:  	static ExpressionTreeParser() {
✔75:  		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
✔76:  		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
✔77:  			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
〰78:  		}
✔79:  	}
〰80:  
✔81:  		public ExpressionTreeParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }
〰82:  
〰83:  		public ExpressionTreeParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
✔84:  		: base(input, output, errorOutput)
〰85:  	{
✔86:  		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
✔87:  	}
〰88:  
〰89:  	public partial class StartContext : ParserRuleContext {
〰90:  		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
✔91:  			return GetRuleContext<ExpressionContext>(0);
〰92:  		}
‼93:  		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(ExpressionTreeParser.Eof, 0); }
〰94:  		public StartContext(ParserRuleContext parent, int invokingState)
✔95:  			: base(parent, invokingState)
〰96:  		{
✔97:  		}
‼98:  		public override int RuleIndex { get { return RULE_start; } }
〰99:  		[System.Diagnostics.DebuggerNonUserCode]
〰100: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
✔101: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
⚠102: 			if (typedVisitor != null) return typedVisitor.VisitStart(this);
‼103: 			else return visitor.VisitChildren(this);
〰104: 		}
〰105: 	}
〰106: 
〰107: 	[RuleVersion(0)]
〰108: 	public StartContext start() {
✔109: 		StartContext _localctx = new StartContext(Context, State);
✔110: 		EnterRule(_localctx, 0, RULE_start);
〰111: 		try {
✔112: 			EnterOuterAlt(_localctx, 1);
〰113: 			{
✔114: 			State = 12;
✔115: 			expression(0);
✔116: 			State = 13;
✔117: 			Match(Eof);
〰118: 			}
✔119: 		}
‼120: 		catch (RecognitionException re) {
‼121: 			_localctx.exception = re;
‼122: 			ErrorHandler.ReportError(this, re);
‼123: 			ErrorHandler.Recover(this, re);
‼124: 		}
〰125: 		finally {
✔126: 			ExitRule();
✔127: 		}
✔128: 		return _localctx;
〰129: 	}
〰130: 
〰131: 	public partial class ValueContext : ParserRuleContext {
✔132: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(ExpressionTreeParser.NUMBER, 0); }
✔133: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode VARIABLE() { return GetToken(ExpressionTreeParser.VARIABLE, 0); }
〰134: 		public ValueContext(ParserRuleContext parent, int invokingState)
✔135: 			: base(parent, invokingState)
〰136: 		{
✔137: 		}
‼138: 		public override int RuleIndex { get { return RULE_value; } }
〰139: 		[System.Diagnostics.DebuggerNonUserCode]
〰140: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
✔141: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
⚠142: 			if (typedVisitor != null) return typedVisitor.VisitValue(this);
‼143: 			else return visitor.VisitChildren(this);
〰144: 		}
〰145: 	}
〰146: 
〰147: 	[RuleVersion(0)]
〰148: 	public ValueContext value() {
✔149: 		ValueContext _localctx = new ValueContext(Context, State);
✔150: 		EnterRule(_localctx, 2, RULE_value);
〰151: 		int _la;
〰152: 		try {
✔153: 			EnterOuterAlt(_localctx, 1);
〰154: 			{
✔155: 			State = 15;
✔156: 			_la = TokenStream.LA(1);
⚠157: 			if ( !(_la==NUMBER || _la==VARIABLE) ) {
‼158: 			ErrorHandler.RecoverInline(this);
〰159: 			}
〰160: 			else {
✔161: 				ErrorHandler.ReportMatch(this);
✔162: 			    Consume();
〰163: 			}
〰164: 			}
✔165: 		}
‼166: 		catch (RecognitionException re) {
‼167: 			_localctx.exception = re;
‼168: 			ErrorHandler.ReportError(this, re);
‼169: 			ErrorHandler.Recover(this, re);
‼170: 		}
〰171: 		finally {
✔172: 			ExitRule();
✔173: 		}
✔174: 		return _localctx;
〰175: 	}
〰176: 
〰177: 	public partial class InnerExpressionContext : ParserRuleContext {
〰178: 		public ExpressionContext inner;
〰179: 		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
‼180: 			return GetRuleContext<ExpressionContext>(0);
〰181: 		}
〰182: 		public InnerExpressionContext(ParserRuleContext parent, int invokingState)
✔183: 			: base(parent, invokingState)
〰184: 		{
✔185: 		}
‼186: 		public override int RuleIndex { get { return RULE_innerExpression; } }
〰187: 		[System.Diagnostics.DebuggerNonUserCode]
〰188: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
✔189: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
⚠190: 			if (typedVisitor != null) return typedVisitor.VisitInnerExpression(this);
‼191: 			else return visitor.VisitChildren(this);
〰192: 		}
〰193: 	}
〰194: 
〰195: 	[RuleVersion(0)]
〰196: 	public InnerExpressionContext innerExpression() {
✔197: 		InnerExpressionContext _localctx = new InnerExpressionContext(Context, State);
✔198: 		EnterRule(_localctx, 4, RULE_innerExpression);
〰199: 		try {
✔200: 			State = 25;
✔201: 			ErrorHandler.Sync(this);
⚠202: 			switch (TokenStream.LA(1)) {
〰203: 			case T__0:
‼204: 				EnterOuterAlt(_localctx, 1);
〰205: 				{
‼206: 				State = 17;
‼207: 				Match(T__0);
‼208: 				State = 18;
‼209: 				_localctx.inner = expression(0);
‼210: 				State = 19;
‼211: 				Match(T__1);
〰212: 				}
‼213: 				break;
〰214: 			case T__2:
✔215: 				EnterOuterAlt(_localctx, 2);
〰216: 				{
✔217: 				State = 21;
✔218: 				Match(T__2);
✔219: 				State = 22;
✔220: 				_localctx.inner = expression(0);
✔221: 				State = 23;
✔222: 				Match(T__3);
〰223: 				}
✔224: 				break;
〰225: 			default:
‼226: 				throw new NoViableAltException(this);
〰227: 			}
✔228: 		}
‼229: 		catch (RecognitionException re) {
‼230: 			_localctx.exception = re;
‼231: 			ErrorHandler.ReportError(this, re);
‼232: 			ErrorHandler.Recover(this, re);
‼233: 		}
〰234: 		finally {
✔235: 			ExitRule();
✔236: 		}
✔237: 		return _localctx;
〰238: 	}
〰239: 
〰240: 	public partial class UnaryOperatorLeftExpressionContext : ParserRuleContext {
〰241: 		public IToken @operator;
‼242: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SUB() { return GetToken(ExpressionTreeParser.SUB, 0); }
〰243: 		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
✔244: 			return GetRuleContext<ValueContext>(0);
〰245: 		}
〰246: 		[System.Diagnostics.DebuggerNonUserCode] public InnerExpressionContext innerExpression() {
✔247: 			return GetRuleContext<InnerExpressionContext>(0);
〰248: 		}
〰249: 		[System.Diagnostics.DebuggerNonUserCode] public UnaryOperatorLeftExpressionContext unaryOperatorLeftExpression() {
✔250: 			return GetRuleContext<UnaryOperatorLeftExpressionContext>(0);
〰251: 		}
〰252: 		public UnaryOperatorLeftExpressionContext(ParserRuleContext parent, int invokingState)
✔253: 			: base(parent, invokingState)
〰254: 		{
✔255: 		}
‼256: 		public override int RuleIndex { get { return RULE_unaryOperatorLeftExpression; } }
〰257: 		[System.Diagnostics.DebuggerNonUserCode]
〰258: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
✔259: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
⚠260: 			if (typedVisitor != null) return typedVisitor.VisitUnaryOperatorLeftExpression(this);
‼261: 			else return visitor.VisitChildren(this);
〰262: 		}
〰263: 	}
〰264: 
〰265: 	[RuleVersion(0)]
〰266: 	public UnaryOperatorLeftExpressionContext unaryOperatorLeftExpression() {
✔267: 		UnaryOperatorLeftExpressionContext _localctx = new UnaryOperatorLeftExpressionContext(Context, State);
✔268: 		EnterRule(_localctx, 6, RULE_unaryOperatorLeftExpression);
〰269: 		try {
✔270: 			EnterOuterAlt(_localctx, 1);
〰271: 			{
✔272: 			State = 27;
✔273: 			_localctx.@operator = Match(SUB);
✔274: 			State = 31;
✔275: 			ErrorHandler.Sync(this);
✔276: 			switch (TokenStream.LA(1)) {
〰277: 			case NUMBER:
〰278: 			case VARIABLE:
〰279: 				{
✔280: 				State = 28;
✔281: 				value();
〰282: 				}
✔283: 				break;
〰284: 			case T__0:
〰285: 			case T__2:
〰286: 				{
✔287: 				State = 29;
✔288: 				innerExpression();
〰289: 				}
✔290: 				break;
〰291: 			case SUB:
〰292: 				{
✔293: 				State = 30;
✔294: 				unaryOperatorLeftExpression();
〰295: 				}
✔296: 				break;
〰297: 			default:
✔298: 				throw new NoViableAltException(this);
〰299: 			}
〰300: 			}
✔301: 		}
✔302: 		catch (RecognitionException re) {
✔303: 			_localctx.exception = re;
✔304: 			ErrorHandler.ReportError(this, re);
✔305: 			ErrorHandler.Recover(this, re);
‼306: 		}
〰307: 		finally {
✔308: 			ExitRule();
✔309: 		}
✔310: 		return _localctx;
〰311: 	}
〰312: 
〰313: 	public partial class UnaryOperatorRightExpressionContext : ParserRuleContext {
〰314: 		public IToken @operator;
〰315: 		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
✔316: 			return GetRuleContext<ValueContext>(0);
〰317: 		}
‼318: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FACTORIAL() { return GetToken(ExpressionTreeParser.FACTORIAL, 0); }
〰319: 		[System.Diagnostics.DebuggerNonUserCode] public InnerExpressionContext innerExpression() {
✔320: 			return GetRuleContext<InnerExpressionContext>(0);
〰321: 		}
〰322: 		[System.Diagnostics.DebuggerNonUserCode] public UnaryOperatorRightExpressionContext unaryOperatorRightExpression() {
✔323: 			return GetRuleContext<UnaryOperatorRightExpressionContext>(0);
〰324: 		}
〰325: 		public UnaryOperatorRightExpressionContext(ParserRuleContext parent, int invokingState)
✔326: 			: base(parent, invokingState)
〰327: 		{
✔328: 		}
‼329: 		public override int RuleIndex { get { return RULE_unaryOperatorRightExpression; } }
〰330: 		[System.Diagnostics.DebuggerNonUserCode]
〰331: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
✔332: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
⚠333: 			if (typedVisitor != null) return typedVisitor.VisitUnaryOperatorRightExpression(this);
‼334: 			else return visitor.VisitChildren(this);
〰335: 		}
〰336: 	}
〰337: 
〰338: 	[RuleVersion(0)]
〰339: 	public UnaryOperatorRightExpressionContext unaryOperatorRightExpression() {
‼340: 		return unaryOperatorRightExpression(0);
〰341: 	}
〰342: 
〰343: 	private UnaryOperatorRightExpressionContext unaryOperatorRightExpression(int _p) {
✔344: 		ParserRuleContext _parentctx = Context;
✔345: 		int _parentState = State;
✔346: 		UnaryOperatorRightExpressionContext _localctx = new UnaryOperatorRightExpressionContext(Context, _parentState);
〰347: 		UnaryOperatorRightExpressionContext _prevctx = _localctx;
✔348: 		int _startState = 8;
✔349: 		EnterRecursionRule(_localctx, 8, RULE_unaryOperatorRightExpression, _p);
〰350: 		try {
〰351: 			int _alt;
✔352: 			EnterOuterAlt(_localctx, 1);
〰353: 			{
✔354: 			State = 40;
✔355: 			ErrorHandler.Sync(this);
⚠356: 			switch (TokenStream.LA(1)) {
〰357: 			case NUMBER:
〰358: 			case VARIABLE:
〰359: 				{
✔360: 				State = 34;
✔361: 				value();
✔362: 				State = 35;
✔363: 				_localctx.@operator = Match(FACTORIAL);
〰364: 				}
✔365: 				break;
〰366: 			case T__0:
〰367: 			case T__2:
〰368: 				{
✔369: 				State = 37;
✔370: 				innerExpression();
✔371: 				State = 38;
✔372: 				_localctx.@operator = Match(FACTORIAL);
〰373: 				}
✔374: 				break;
〰375: 			default:
‼376: 				throw new NoViableAltException(this);
〰377: 			}
✔378: 			Context.Stop = TokenStream.LT(-1);
✔379: 			State = 46;
✔380: 			ErrorHandler.Sync(this);
✔381: 			_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
✔382: 			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
✔383: 				if ( _alt==1 ) {
✔384: 					if ( ParseListeners!=null )
✔385: 						TriggerExitRuleEvent();
〰386: 					_prevctx = _localctx;
〰387: 					{
〰388: 					{
✔389: 					_localctx = new UnaryOperatorRightExpressionContext(_parentctx, _parentState);
✔390: 					PushNewRecursionContext(_localctx, _startState, RULE_unaryOperatorRightExpression);
✔391: 					State = 42;
⚠392: 					if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
✔393: 					State = 43;
✔394: 					_localctx.@operator = Match(FACTORIAL);
〰395: 					}
〰396: 					}
〰397: 				}
✔398: 				State = 48;
✔399: 				ErrorHandler.Sync(this);
✔400: 				_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
〰401: 			}
〰402: 			}
✔403: 		}
‼404: 		catch (RecognitionException re) {
‼405: 			_localctx.exception = re;
‼406: 			ErrorHandler.ReportError(this, re);
‼407: 			ErrorHandler.Recover(this, re);
‼408: 		}
〰409: 		finally {
✔410: 			UnrollRecursionContexts(_parentctx);
✔411: 		}
✔412: 		return _localctx;
〰413: 	}
〰414: 
〰415: 	public partial class ExpressionContext : ParserRuleContext {
〰416: 		public ExpressionContext left;
〰417: 		public IToken @operator;
〰418: 		public ExpressionContext right;
〰419: 		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
‼420: 			return GetRuleContext<ValueContext>(0);
〰421: 		}
〰422: 		[System.Diagnostics.DebuggerNonUserCode] public UnaryOperatorLeftExpressionContext unaryOperatorLeftExpression() {
‼423: 			return GetRuleContext<UnaryOperatorLeftExpressionContext>(0);
〰424: 		}
〰425: 		[System.Diagnostics.DebuggerNonUserCode] public UnaryOperatorRightExpressionContext unaryOperatorRightExpression() {
‼426: 			return GetRuleContext<UnaryOperatorRightExpressionContext>(0);
〰427: 		}
〰428: 		[System.Diagnostics.DebuggerNonUserCode] public InnerExpressionContext innerExpression() {
‼429: 			return GetRuleContext<InnerExpressionContext>(0);
〰430: 		}
〰431: 		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext[] expression() {
‼432: 			return GetRuleContexts<ExpressionContext>();
〰433: 		}
〰434: 		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression(int i) {
‼435: 			return GetRuleContext<ExpressionContext>(i);
〰436: 		}
‼437: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode POW() { return GetToken(ExpressionTreeParser.POW, 0); }
‼438: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MUL() { return GetToken(ExpressionTreeParser.MUL, 0); }
‼439: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIV() { return GetToken(ExpressionTreeParser.DIV, 0); }
‼440: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MOD() { return GetToken(ExpressionTreeParser.MOD, 0); }
‼441: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ADD() { return GetToken(ExpressionTreeParser.ADD, 0); }
‼442: 		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SUB() { return GetToken(ExpressionTreeParser.SUB, 0); }
〰443: 		public ExpressionContext(ParserRuleContext parent, int invokingState)
✔444: 			: base(parent, invokingState)
〰445: 		{
✔446: 		}
‼447: 		public override int RuleIndex { get { return RULE_expression; } }
〰448: 		[System.Diagnostics.DebuggerNonUserCode]
〰449: 		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
✔450: 			IExpressionTreeVisitor<TResult> typedVisitor = visitor as IExpressionTreeVisitor<TResult>;
⚠451: 			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
‼452: 			else return visitor.VisitChildren(this);
〰453: 		}
〰454: 	}
〰455: 
〰456: 	[RuleVersion(0)]
〰457: 	public ExpressionContext expression() {
‼458: 		return expression(0);
〰459: 	}
〰460: 
〰461: 	private ExpressionContext expression(int _p) {
✔462: 		ParserRuleContext _parentctx = Context;
✔463: 		int _parentState = State;
✔464: 		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
✔465: 		ExpressionContext _prevctx = _localctx;
✔466: 		int _startState = 10;
✔467: 		EnterRecursionRule(_localctx, 10, RULE_expression, _p);
〰468: 		int _la;
〰469: 		try {
〰470: 			int _alt;
✔471: 			EnterOuterAlt(_localctx, 1);
〰472: 			{
✔473: 			State = 54;
✔474: 			ErrorHandler.Sync(this);
✔475: 			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
〰476: 			case 1:
〰477: 				{
✔478: 				State = 50;
✔479: 				value();
〰480: 				}
✔481: 				break;
〰482: 			case 2:
〰483: 				{
✔484: 				State = 51;
✔485: 				unaryOperatorLeftExpression();
〰486: 				}
✔487: 				break;
〰488: 			case 3:
〰489: 				{
✔490: 				State = 52;
✔491: 				unaryOperatorRightExpression(0);
〰492: 				}
✔493: 				break;
〰494: 			case 4:
〰495: 				{
✔496: 				State = 53;
✔497: 				innerExpression();
〰498: 				}
〰499: 				break;
〰500: 			}
✔501: 			Context.Stop = TokenStream.LT(-1);
✔502: 			State = 67;
✔503: 			ErrorHandler.Sync(this);
✔504: 			_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
✔505: 			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
✔506: 				if ( _alt==1 ) {
✔507: 					if ( ParseListeners!=null )
✔508: 						TriggerExitRuleEvent();
✔509: 					_prevctx = _localctx;
〰510: 					{
✔511: 					State = 65;
✔512: 					ErrorHandler.Sync(this);
✔513: 					switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
〰514: 					case 1:
〰515: 						{
✔516: 						_localctx = new ExpressionContext(_parentctx, _parentState);
✔517: 						_localctx.left = _prevctx;
✔518: 						PushNewRecursionContext(_localctx, _startState, RULE_expression);
✔519: 						State = 56;
⚠520: 						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
✔521: 						State = 57;
✔522: 						_localctx.@operator = Match(POW);
✔523: 						State = 58;
✔524: 						_localctx.right = expression(4);
〰525: 						}
✔526: 						break;
〰527: 					case 2:
〰528: 						{
✔529: 						_localctx = new ExpressionContext(_parentctx, _parentState);
✔530: 						_localctx.left = _prevctx;
✔531: 						PushNewRecursionContext(_localctx, _startState, RULE_expression);
✔532: 						State = 59;
⚠533: 						if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
✔534: 						State = 60;
✔535: 						_localctx.@operator = TokenStream.LT(1);
✔536: 						_la = TokenStream.LA(1);
⚠537: 						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1216L) != 0)) ) {
‼538: 							_localctx.@operator = ErrorHandler.RecoverInline(this);
〰539: 						}
〰540: 						else {
✔541: 							ErrorHandler.ReportMatch(this);
✔542: 						    Consume();
〰543: 						}
✔544: 						State = 61;
✔545: 						_localctx.right = expression(3);
〰546: 						}
✔547: 						break;
〰548: 					case 3:
〰549: 						{
✔550: 						_localctx = new ExpressionContext(_parentctx, _parentState);
✔551: 						_localctx.left = _prevctx;
✔552: 						PushNewRecursionContext(_localctx, _startState, RULE_expression);
✔553: 						State = 62;
⚠554: 						if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
✔555: 						State = 63;
✔556: 						_localctx.@operator = TokenStream.LT(1);
✔557: 						_la = TokenStream.LA(1);
⚠558: 						if ( !(_la==ADD || _la==SUB) ) {
‼559: 							_localctx.@operator = ErrorHandler.RecoverInline(this);
〰560: 						}
〰561: 						else {
✔562: 							ErrorHandler.ReportMatch(this);
✔563: 						    Consume();
〰564: 						}
✔565: 						State = 64;
✔566: 						_localctx.right = expression(2);
〰567: 						}
〰568: 						break;
〰569: 					}
〰570: 					}
〰571: 				}
✔572: 				State = 69;
✔573: 				ErrorHandler.Sync(this);
✔574: 				_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
〰575: 			}
〰576: 			}
✔577: 		}
✔578: 		catch (RecognitionException re) {
✔579: 			_localctx.exception = re;
✔580: 			ErrorHandler.ReportError(this, re);
✔581: 			ErrorHandler.Recover(this, re);
‼582: 		}
〰583: 		finally {
✔584: 			UnrollRecursionContexts(_parentctx);
✔585: 		}
✔586: 		return _localctx;
〰587: 	}
〰588: 
〰589: 	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
〰590: 		switch (ruleIndex) {
‼591: 		case 4: return unaryOperatorRightExpression_sempred((UnaryOperatorRightExpressionContext)_localctx, predIndex);
‼592: 		case 5: return expression_sempred((ExpressionContext)_localctx, predIndex);
〰593: 		}
‼594: 		return true;
〰595: 	}
〰596: 	private bool unaryOperatorRightExpression_sempred(UnaryOperatorRightExpressionContext _localctx, int predIndex) {
〰597: 		switch (predIndex) {
‼598: 		case 0: return Precpred(Context, 1);
〰599: 		}
‼600: 		return true;
〰601: 	}
〰602: 	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
〰603: 		switch (predIndex) {
‼604: 		case 1: return Precpred(Context, 3);
‼605: 		case 2: return Precpred(Context, 2);
‼606: 		case 3: return Precpred(Context, 1);
〰607: 		}
‼608: 		return true;
〰609: 	}
〰610: 
✔611: 	private static int[] _serializedATN = {
✔612: 		4,1,14,71,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,1,0,1,0,1,0,
✔613: 		1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,3,2,26,8,2,1,3,1,3,1,3,1,3,3,3,
✔614: 		32,8,3,1,4,1,4,1,4,1,4,1,4,1,4,1,4,3,4,41,8,4,1,4,1,4,5,4,45,8,4,10,4,
✔615: 		12,4,48,9,4,1,5,1,5,1,5,1,5,1,5,3,5,55,8,5,1,5,1,5,1,5,1,5,1,5,1,5,1,5,
✔616: 		1,5,1,5,5,5,66,8,5,10,5,12,5,69,9,5,1,5,0,2,8,10,6,0,2,4,6,8,10,0,3,1,
✔617: 		0,12,13,2,0,6,7,10,10,1,0,8,9,75,0,12,1,0,0,0,2,15,1,0,0,0,4,25,1,0,0,
✔618: 		0,6,27,1,0,0,0,8,40,1,0,0,0,10,54,1,0,0,0,12,13,3,10,5,0,13,14,5,0,0,1,
✔619: 		14,1,1,0,0,0,15,16,7,0,0,0,16,3,1,0,0,0,17,18,5,1,0,0,18,19,3,10,5,0,19,
✔620: 		20,5,2,0,0,20,26,1,0,0,0,21,22,5,3,0,0,22,23,3,10,5,0,23,24,5,4,0,0,24,
✔621: 		26,1,0,0,0,25,17,1,0,0,0,25,21,1,0,0,0,26,5,1,0,0,0,27,31,5,9,0,0,28,32,
✔622: 		3,2,1,0,29,32,3,4,2,0,30,32,3,6,3,0,31,28,1,0,0,0,31,29,1,0,0,0,31,30,
✔623: 		1,0,0,0,32,7,1,0,0,0,33,34,6,4,-1,0,34,35,3,2,1,0,35,36,5,11,0,0,36,41,
✔624: 		1,0,0,0,37,38,3,4,2,0,38,39,5,11,0,0,39,41,1,0,0,0,40,33,1,0,0,0,40,37,
✔625: 		1,0,0,0,41,46,1,0,0,0,42,43,10,1,0,0,43,45,5,11,0,0,44,42,1,0,0,0,45,48,
✔626: 		1,0,0,0,46,44,1,0,0,0,46,47,1,0,0,0,47,9,1,0,0,0,48,46,1,0,0,0,49,50,6,
✔627: 		5,-1,0,50,55,3,2,1,0,51,55,3,6,3,0,52,55,3,8,4,0,53,55,3,4,2,0,54,49,1,
✔628: 		0,0,0,54,51,1,0,0,0,54,52,1,0,0,0,54,53,1,0,0,0,55,67,1,0,0,0,56,57,10,
✔629: 		3,0,0,57,58,5,5,0,0,58,66,3,10,5,4,59,60,10,2,0,0,60,61,7,1,0,0,61,66,
✔630: 		3,10,5,3,62,63,10,1,0,0,63,64,7,2,0,0,64,66,3,10,5,2,65,56,1,0,0,0,65,
✔631: 		59,1,0,0,0,65,62,1,0,0,0,66,69,1,0,0,0,67,65,1,0,0,0,67,68,1,0,0,0,68,
✔632: 		11,1,0,0,0,69,67,1,0,0,0,7,25,31,40,46,54,65,67
✔633: 	};
〰634: 
✔635: 	public static readonly ATN _ATN =
✔636: 		new ATNDeserializer().Deserialize(_serializedATN);
〰637: 
〰638: 
〰639: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

