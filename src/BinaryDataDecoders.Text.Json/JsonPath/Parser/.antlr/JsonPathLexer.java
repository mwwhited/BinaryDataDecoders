// Generated from c:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonPath\Parser\JsonPath.g4 by ANTLR 4.8
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JsonPathLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, QUOTED_STRING=8, 
		LOGICAL=9, RELATIONAL=10, WILDCARD=11, DECENDANTS=12, RELATIVE=13, ROOT=14, 
		IDENTITY=15, NUMBER=16, WS=17;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "ESCAPED_QUOTE", 
			"QUOTED_STRING", "LOGICAL", "RELATIONAL", "WILDCARD", "DECENDANTS", "RELATIVE", 
			"ROOT", "IDENTITY", "NUMBER", "WS"
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


	public JsonPathLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "JsonPath.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\23z\b\1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\6\3\7\3\7\3\b\3\b"+
		"\3\t\3\t\3\t\3\n\3\n\3\n\7\n=\n\n\f\n\16\n@\13\n\3\n\3\n\3\13\3\13\3\13"+
		"\3\13\3\13\5\13I\n\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\5\fU\n\f"+
		"\3\r\3\r\3\16\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21\7\21b\n\21\f\21"+
		"\16\21e\13\21\3\22\3\22\5\22i\n\22\3\22\3\22\7\22m\n\22\f\22\16\22p\13"+
		"\22\5\22r\n\22\3\23\6\23u\n\23\r\23\16\23v\3\23\3\23\3>\2\24\3\3\5\4\7"+
		"\5\t\6\13\7\r\b\17\t\21\2\23\n\25\13\27\f\31\r\33\16\35\17\37\20!\21#"+
		"\22%\23\3\2\b\4\2\f\f\17\17\4\2C\\c|\5\2\62;C\\c|\3\2\63;\3\2\62;\5\2"+
		"\13\f\17\17\"\"\2\u0085\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2"+
		"\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27"+
		"\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2"+
		"\2\2#\3\2\2\2\2%\3\2\2\2\3\'\3\2\2\2\5)\3\2\2\2\7+\3\2\2\2\t-\3\2\2\2"+
		"\13/\3\2\2\2\r\62\3\2\2\2\17\64\3\2\2\2\21\66\3\2\2\2\239\3\2\2\2\25H"+
		"\3\2\2\2\27T\3\2\2\2\31V\3\2\2\2\33X\3\2\2\2\35[\3\2\2\2\37]\3\2\2\2!"+
		"_\3\2\2\2#q\3\2\2\2%t\3\2\2\2\'(\7\60\2\2(\4\3\2\2\2)*\7]\2\2*\6\3\2\2"+
		"\2+,\7_\2\2,\b\3\2\2\2-.\7.\2\2.\n\3\2\2\2/\60\7A\2\2\60\61\7*\2\2\61"+
		"\f\3\2\2\2\62\63\7+\2\2\63\16\3\2\2\2\64\65\7<\2\2\65\20\3\2\2\2\66\67"+
		"\7^\2\2\678\7)\2\28\22\3\2\2\29>\7)\2\2:=\5\21\t\2;=\n\2\2\2<:\3\2\2\2"+
		"<;\3\2\2\2=@\3\2\2\2>?\3\2\2\2><\3\2\2\2?A\3\2\2\2@>\3\2\2\2AB\7)\2\2"+
		"B\24\3\2\2\2CD\7c\2\2DE\7p\2\2EI\7f\2\2FG\7q\2\2GI\7t\2\2HC\3\2\2\2HF"+
		"\3\2\2\2I\26\3\2\2\2JK\7?\2\2KU\7?\2\2LM\7#\2\2MU\7?\2\2NU\7>\2\2OP\7"+
		">\2\2PU\7?\2\2QU\7@\2\2RS\7@\2\2SU\7?\2\2TJ\3\2\2\2TL\3\2\2\2TN\3\2\2"+
		"\2TO\3\2\2\2TQ\3\2\2\2TR\3\2\2\2U\30\3\2\2\2VW\7,\2\2W\32\3\2\2\2XY\7"+
		"\60\2\2YZ\7\60\2\2Z\34\3\2\2\2[\\\7B\2\2\\\36\3\2\2\2]^\7&\2\2^ \3\2\2"+
		"\2_c\t\3\2\2`b\t\4\2\2a`\3\2\2\2be\3\2\2\2ca\3\2\2\2cd\3\2\2\2d\"\3\2"+
		"\2\2ec\3\2\2\2fr\7\62\2\2gi\7/\2\2hg\3\2\2\2hi\3\2\2\2ij\3\2\2\2jn\t\5"+
		"\2\2km\t\6\2\2lk\3\2\2\2mp\3\2\2\2nl\3\2\2\2no\3\2\2\2or\3\2\2\2pn\3\2"+
		"\2\2qf\3\2\2\2qh\3\2\2\2r$\3\2\2\2su\t\7\2\2ts\3\2\2\2uv\3\2\2\2vt\3\2"+
		"\2\2vw\3\2\2\2wx\3\2\2\2xy\b\23\2\2y&\3\2\2\2\f\2<>HTchnqv\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}