grammar JsonPath;

start 
    : path EOF
    ;

path
    : pathBase=(ROOT | RELATIVE) (
        DESCENDANTS? bracketSequence 
        | DESCENDANTS dotSequence
        | '.' dotSequence
    )
    ;

bracketSequence 
    : bracket bracketSequence?
    ;

dotSequence 
    : (
        dotElement 
        | DESCENDANTS
        | WILDCARD
    ) (PATH_SEPERATOR dotSequence)?
    ;

dotElement 
    : identity bracketSequence?
    ;

bracket 
    : '[' WILDCARD ']' 
    | '[' NUMBER (',' NUMBER)* ']'
    | '[' string (',' string)* ']'
    | '[' range ']'
    | '[' '?(' query ')' ']'
    ;

range : rangeStart=NUMBER? ':' rangeEnd=NUMBER? (':' rangeStep=NUMBER)?;


operand
    : path
    | string
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

PATH_SEPERATOR : '.';
WILDCARD : '*';
DESCENDANTS : '..';
RELATIVE : '@';
ROOT : '$';
IDENTITY : [a-zA-Z][a-zA-Z0-9]* ;
NUMBER   : '0' | '-'? [1-9][0-9]* ;
WS       :  [ \t\n\r]+ -> skip ;
