// Generated from c:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonPath\Parser\JsonPath.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JsonPathParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, QUOTED_STRING=8, 
		LOGICAL=9, RELATIONAL=10, WILDCARD=11, DECENDANTS=12, RELATIVE=13, ROOT=14, 
		IDENTITY=15, NUMBER=16, WS=17;
	public static final int
		RULE_start = 0, RULE_dotSequence = 1, RULE_dotElement = 2, RULE_bracketSequence = 3, 
		RULE_bracket = 4, RULE_range = 5, RULE_operand = 6, RULE_query = 7;
	private static String[] makeRuleNames() {
		return new String[] {
			"start", "dotSequence", "dotElement", "bracketSequence", "bracket", "range", 
			"operand", "query"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "'['", "']'", "','", "'?('", "')'", "':'", null, null, null, 
			"'*'", "'..'", "'@'", "'$'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, "QUOTED_STRING", "LOGICAL", 
			"RELATIONAL", "WILDCARD", "DECENDANTS", "RELATIVE", "ROOT", "IDENTITY", 
			"NUMBER", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "JsonPath.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JsonPathParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class StartContext extends ParserRuleContext {
		public TerminalNode ROOT() { return getToken(JsonPathParser.ROOT, 0); }
		public BracketSequenceContext bracketSequence() {
			return getRuleContext(BracketSequenceContext.class,0);
		}
		public DotSequenceContext dotSequence() {
			return getRuleContext(DotSequenceContext.class,0);
		}
		public StartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_start; }
	}

	public final StartContext start() throws RecognitionException {
		StartContext _localctx = new StartContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_start);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(16);
			match(ROOT);
			setState(19);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
				{
				setState(17);
				bracketSequence();
				}
				break;
			case IDENTITY:
				{
				setState(18);
				dotSequence();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DotSequenceContext extends ParserRuleContext {
		public List<DotElementContext> dotElement() {
			return getRuleContexts(DotElementContext.class);
		}
		public DotElementContext dotElement(int i) {
			return getRuleContext(DotElementContext.class,i);
		}
		public List<TerminalNode> DECENDANTS() { return getTokens(JsonPathParser.DECENDANTS); }
		public TerminalNode DECENDANTS(int i) {
			return getToken(JsonPathParser.DECENDANTS, i);
		}
		public DotSequenceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_dotSequence; }
	}

	public final DotSequenceContext dotSequence() throws RecognitionException {
		DotSequenceContext _localctx = new DotSequenceContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_dotSequence);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(21);
			dotElement();
			setState(27);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					setState(25);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__0:
						{
						setState(22);
						match(T__0);
						setState(23);
						dotElement();
						}
						break;
					case DECENDANTS:
						{
						setState(24);
						match(DECENDANTS);
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					} 
				}
				setState(29);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DotElementContext extends ParserRuleContext {
		public TerminalNode IDENTITY() { return getToken(JsonPathParser.IDENTITY, 0); }
		public BracketSequenceContext bracketSequence() {
			return getRuleContext(BracketSequenceContext.class,0);
		}
		public DotElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_dotElement; }
	}

	public final DotElementContext dotElement() throws RecognitionException {
		DotElementContext _localctx = new DotElementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_dotElement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(30);
			match(IDENTITY);
			setState(32);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(31);
				bracketSequence();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BracketSequenceContext extends ParserRuleContext {
		public List<BracketContext> bracket() {
			return getRuleContexts(BracketContext.class);
		}
		public BracketContext bracket(int i) {
			return getRuleContext(BracketContext.class,i);
		}
		public BracketSequenceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_bracketSequence; }
	}

	public final BracketSequenceContext bracketSequence() throws RecognitionException {
		BracketSequenceContext _localctx = new BracketSequenceContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_bracketSequence);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(35); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(34);
					bracket();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(37); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BracketContext extends ParserRuleContext {
		public BracketContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_bracket; }
	 
		public BracketContext() { }
		public void copyFrom(BracketContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class UnionStringContext extends BracketContext {
		public List<TerminalNode> QUOTED_STRING() { return getTokens(JsonPathParser.QUOTED_STRING); }
		public TerminalNode QUOTED_STRING(int i) {
			return getToken(JsonPathParser.QUOTED_STRING, i);
		}
		public UnionStringContext(BracketContext ctx) { copyFrom(ctx); }
	}
	public static class SlicerContext extends BracketContext {
		public RangeContext range() {
			return getRuleContext(RangeContext.class,0);
		}
		public SlicerContext(BracketContext ctx) { copyFrom(ctx); }
	}
	public static class FilterContext extends BracketContext {
		public QueryContext query() {
			return getRuleContext(QueryContext.class,0);
		}
		public FilterContext(BracketContext ctx) { copyFrom(ctx); }
	}
	public static class UnionNumberContext extends BracketContext {
		public List<TerminalNode> NUMBER() { return getTokens(JsonPathParser.NUMBER); }
		public TerminalNode NUMBER(int i) {
			return getToken(JsonPathParser.NUMBER, i);
		}
		public UnionNumberContext(BracketContext ctx) { copyFrom(ctx); }
	}
	public static class WildcardContext extends BracketContext {
		public TerminalNode WILDCARD() { return getToken(JsonPathParser.WILDCARD, 0); }
		public WildcardContext(BracketContext ctx) { copyFrom(ctx); }
	}

	public final BracketContext bracket() throws RecognitionException {
		BracketContext _localctx = new BracketContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_bracket);
		int _la;
		try {
			setState(72);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				_localctx = new WildcardContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(39);
				match(T__1);
				setState(40);
				match(WILDCARD);
				setState(41);
				match(T__2);
				}
				break;
			case 2:
				_localctx = new UnionNumberContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(42);
				match(T__1);
				setState(43);
				match(NUMBER);
				setState(48);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__3) {
					{
					{
					setState(44);
					match(T__3);
					setState(45);
					match(NUMBER);
					}
					}
					setState(50);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(51);
				match(T__2);
				}
				break;
			case 3:
				_localctx = new UnionStringContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(52);
				match(T__1);
				setState(53);
				match(QUOTED_STRING);
				setState(58);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__3) {
					{
					{
					setState(54);
					match(T__3);
					setState(55);
					match(QUOTED_STRING);
					}
					}
					setState(60);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(61);
				match(T__2);
				}
				break;
			case 4:
				_localctx = new SlicerContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(62);
				match(T__1);
				setState(63);
				range();
				setState(64);
				match(T__2);
				}
				break;
			case 5:
				_localctx = new FilterContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(66);
				match(T__1);
				setState(67);
				match(T__4);
				setState(68);
				query(0);
				setState(69);
				match(T__5);
				setState(70);
				match(T__2);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RangeContext extends ParserRuleContext {
		public Token rangeStart;
		public Token rangeEnd;
		public Token rangeStep;
		public List<TerminalNode> NUMBER() { return getTokens(JsonPathParser.NUMBER); }
		public TerminalNode NUMBER(int i) {
			return getToken(JsonPathParser.NUMBER, i);
		}
		public RangeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_range; }
	}

	public final RangeContext range() throws RecognitionException {
		RangeContext _localctx = new RangeContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_range);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(75);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NUMBER) {
				{
				setState(74);
				((RangeContext)_localctx).rangeStart = match(NUMBER);
				}
			}

			setState(77);
			match(T__6);
			setState(79);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NUMBER) {
				{
				setState(78);
				((RangeContext)_localctx).rangeEnd = match(NUMBER);
				}
			}

			setState(83);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__6) {
				{
				setState(81);
				match(T__6);
				setState(82);
				((RangeContext)_localctx).rangeStep = match(NUMBER);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OperandContext extends ParserRuleContext {
		public Token operandBase;
		public TerminalNode ROOT() { return getToken(JsonPathParser.ROOT, 0); }
		public TerminalNode RELATIVE() { return getToken(JsonPathParser.RELATIVE, 0); }
		public BracketSequenceContext bracketSequence() {
			return getRuleContext(BracketSequenceContext.class,0);
		}
		public DotSequenceContext dotSequence() {
			return getRuleContext(DotSequenceContext.class,0);
		}
		public OperandContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operand; }
	}

	public final OperandContext operand() throws RecognitionException {
		OperandContext _localctx = new OperandContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_operand);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(85);
			((OperandContext)_localctx).operandBase = _input.LT(1);
			_la = _input.LA(1);
			if ( !(_la==RELATIVE || _la==ROOT) ) {
				((OperandContext)_localctx).operandBase = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(88);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
				{
				setState(86);
				bracketSequence();
				}
				break;
			case IDENTITY:
				{
				setState(87);
				dotSequence();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class QueryContext extends ParserRuleContext {
		public QueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_query; }
	 
		public QueryContext() { }
		public void copyFrom(QueryContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class RelationalContext extends QueryContext {
		public OperandContext relationLeft;
		public OperandContext relationRight;
		public TerminalNode RELATIONAL() { return getToken(JsonPathParser.RELATIONAL, 0); }
		public List<OperandContext> operand() {
			return getRuleContexts(OperandContext.class);
		}
		public OperandContext operand(int i) {
			return getRuleContext(OperandContext.class,i);
		}
		public RelationalContext(QueryContext ctx) { copyFrom(ctx); }
	}
	public static class LogicalContext extends QueryContext {
		public QueryContext relationLeft;
		public QueryContext relationRight;
		public TerminalNode LOGICAL() { return getToken(JsonPathParser.LOGICAL, 0); }
		public List<QueryContext> query() {
			return getRuleContexts(QueryContext.class);
		}
		public QueryContext query(int i) {
			return getRuleContext(QueryContext.class,i);
		}
		public LogicalContext(QueryContext ctx) { copyFrom(ctx); }
	}

	public final QueryContext query() throws RecognitionException {
		return query(0);
	}

	private QueryContext query(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		QueryContext _localctx = new QueryContext(_ctx, _parentState);
		QueryContext _prevctx = _localctx;
		int _startState = 14;
		enterRecursionRule(_localctx, 14, RULE_query, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			_localctx = new RelationalContext(_localctx);
			_ctx = _localctx;
			_prevctx = _localctx;

			setState(91);
			((RelationalContext)_localctx).relationLeft = operand();
			setState(92);
			match(RELATIONAL);
			setState(93);
			((RelationalContext)_localctx).relationRight = operand();
			}
			_ctx.stop = _input.LT(-1);
			setState(100);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new LogicalContext(new QueryContext(_parentctx, _parentState));
					((LogicalContext)_localctx).relationLeft = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_query);
					setState(95);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(96);
					match(LOGICAL);
					setState(97);
					((LogicalContext)_localctx).relationRight = query(2);
					}
					} 
				}
				setState(102);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 7:
			return query_sempred((QueryContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean query_sempred(QueryContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\23j\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\3\2\3\2\3\2\5\2\26"+
		"\n\2\3\3\3\3\3\3\3\3\7\3\34\n\3\f\3\16\3\37\13\3\3\4\3\4\5\4#\n\4\3\5"+
		"\6\5&\n\5\r\5\16\5\'\3\6\3\6\3\6\3\6\3\6\3\6\3\6\7\6\61\n\6\f\6\16\6\64"+
		"\13\6\3\6\3\6\3\6\3\6\3\6\7\6;\n\6\f\6\16\6>\13\6\3\6\3\6\3\6\3\6\3\6"+
		"\3\6\3\6\3\6\3\6\3\6\3\6\5\6K\n\6\3\7\5\7N\n\7\3\7\3\7\5\7R\n\7\3\7\3"+
		"\7\5\7V\n\7\3\b\3\b\3\b\5\b[\n\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\7\te"+
		"\n\t\f\t\16\th\13\t\3\t\2\3\20\n\2\4\6\b\n\f\16\20\2\3\3\2\17\20\2q\2"+
		"\22\3\2\2\2\4\27\3\2\2\2\6 \3\2\2\2\b%\3\2\2\2\nJ\3\2\2\2\fM\3\2\2\2\16"+
		"W\3\2\2\2\20\\\3\2\2\2\22\25\7\20\2\2\23\26\5\b\5\2\24\26\5\4\3\2\25\23"+
		"\3\2\2\2\25\24\3\2\2\2\26\3\3\2\2\2\27\35\5\6\4\2\30\31\7\3\2\2\31\34"+
		"\5\6\4\2\32\34\7\16\2\2\33\30\3\2\2\2\33\32\3\2\2\2\34\37\3\2\2\2\35\33"+
		"\3\2\2\2\35\36\3\2\2\2\36\5\3\2\2\2\37\35\3\2\2\2 \"\7\21\2\2!#\5\b\5"+
		"\2\"!\3\2\2\2\"#\3\2\2\2#\7\3\2\2\2$&\5\n\6\2%$\3\2\2\2&\'\3\2\2\2\'%"+
		"\3\2\2\2\'(\3\2\2\2(\t\3\2\2\2)*\7\4\2\2*+\7\r\2\2+K\7\5\2\2,-\7\4\2\2"+
		"-\62\7\22\2\2./\7\6\2\2/\61\7\22\2\2\60.\3\2\2\2\61\64\3\2\2\2\62\60\3"+
		"\2\2\2\62\63\3\2\2\2\63\65\3\2\2\2\64\62\3\2\2\2\65K\7\5\2\2\66\67\7\4"+
		"\2\2\67<\7\n\2\289\7\6\2\29;\7\n\2\2:8\3\2\2\2;>\3\2\2\2<:\3\2\2\2<=\3"+
		"\2\2\2=?\3\2\2\2><\3\2\2\2?K\7\5\2\2@A\7\4\2\2AB\5\f\7\2BC\7\5\2\2CK\3"+
		"\2\2\2DE\7\4\2\2EF\7\7\2\2FG\5\20\t\2GH\7\b\2\2HI\7\5\2\2IK\3\2\2\2J)"+
		"\3\2\2\2J,\3\2\2\2J\66\3\2\2\2J@\3\2\2\2JD\3\2\2\2K\13\3\2\2\2LN\7\22"+
		"\2\2ML\3\2\2\2MN\3\2\2\2NO\3\2\2\2OQ\7\t\2\2PR\7\22\2\2QP\3\2\2\2QR\3"+
		"\2\2\2RU\3\2\2\2ST\7\t\2\2TV\7\22\2\2US\3\2\2\2UV\3\2\2\2V\r\3\2\2\2W"+
		"Z\t\2\2\2X[\5\b\5\2Y[\5\4\3\2ZX\3\2\2\2ZY\3\2\2\2[\17\3\2\2\2\\]\b\t\1"+
		"\2]^\5\16\b\2^_\7\f\2\2_`\5\16\b\2`f\3\2\2\2ab\f\3\2\2bc\7\13\2\2ce\5"+
		"\20\t\4da\3\2\2\2eh\3\2\2\2fd\3\2\2\2fg\3\2\2\2g\21\3\2\2\2hf\3\2\2\2"+
		"\17\25\33\35\"\'\62<JMQUZf";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}