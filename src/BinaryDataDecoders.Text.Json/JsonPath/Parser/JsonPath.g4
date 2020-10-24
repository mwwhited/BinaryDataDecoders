grammar JsonPath;

start 
    : ROOT (
        bracketSequence
        | CHILDPATH dotSequence
    ) EOF
    ;

dotSequence 
    : dotElement (CHILDPATH dotSequence)?  //|  DESCENDANTS)?
    ;

dotElement 
    : property bracketSequence?
    ;

property
    : identity
    | WILDCARD
    ;

bracketSequence 
    : bracket bracketSequence?
    ;

bracket 
    : '[' WILDCARD ']' #wildcard
    | '[' NUMBER (',' NUMBER)* ']' #unionNumber
    | '[' QUOTED_STRING (',' QUOTED_STRING)* ']' #unionString
    | '[' range ']' #slicer
    | '[' '?(' query ')' ']' #filter
    ;

range : rangeStart=NUMBER? ':' rangeEnd=NUMBER? (':' rangeStep=NUMBER)?;

path
    : pathBase=(ROOT | RELATIVE) (
        bracketSequence
        | '.' dotSequence
    )
    ;

operand
    : path
    | QUOTED_STRING
    | NUMBER
    ;

query
    : relationLeft=operand RELATIONAL relationRight=operand #relational
    | relationLeft=query LOGICAL relationRight=query #logical
    ;

identity 
    : IDENTITY
    ;

string 
    : QUOTED_STRING
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

CHILDPATH : '.';
WILDCARD : '*';
DECENDANTS : '..';
RELATIVE : '@';
ROOT : '$';
IDENTITY : [a-zA-Z][a-zA-Z0-9]* ;
NUMBER   : '0' | '-'? [1-9][0-9]* ;
WS       :  [ \t\n\r]+ -> skip ;
