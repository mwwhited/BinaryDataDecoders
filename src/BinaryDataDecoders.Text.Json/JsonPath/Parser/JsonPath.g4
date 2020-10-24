grammar JsonPath;

start 
    : ROOT (
        bracketSequence
        | dotSequence
    )
    ;

dotSequence 
    : dotElement ('.' dotElement | '..')*
    ;

dotElement 
    : IDENTITY bracketSequence?
    ;

bracketSequence 
    : bracket+
    ;

bracket 
    : '[' WILDCARD ']' #wildcard
    | '[' NUMBER (',' NUMBER)* ']' #unionNumber
    | '[' QUOTED_STRING (',' QUOTED_STRING)* ']' #unionString
    | '[' range ']' #slicer
    | '[' '?(' query ')' ']' #filter
    ;

range : rangeStart=NUMBER? ':' rangeEnd=NUMBER? (':' rangeStep=NUMBER)?;

operand
    : operandBase=(ROOT | RELATIVE) (
        bracketSequence
        | dotSequence
    )
    ;

query
    : relationLeft=operand RELATIONAL relationRight=operand #relational
    | relationLeft=query LOGICAL relationRight=query #logical
    ;

fragment ESCAPED_QUOTE : '\\\'';
QUOTED_STRING :   '\'' ( ESCAPED_QUOTE | ~('\n'|'\r') )*? '\'';

LOGICAL
    : 'and' | 'or'
    ;

RELATIONAL 
    : '==' | '!=' | '<' | '<=' | '>' | '>='
    //| '=~'
    ;

WILDCARD : '*';
DECENDANTS : '..';
RELATIVE : '@';
ROOT : '$';
IDENTITY : [a-zA-Z][a-zA-Z0-9]* ;
NUMBER   : '0' | '-'? [1-9][0-9]* ;
WS       :  [ \t\n\r]+ -> skip ;
