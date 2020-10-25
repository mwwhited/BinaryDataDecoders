grammar JsonPath;

start 
    : path EOF
    ;

path
    : pathBase=(ROOT | RELATIVE) (
        bracketSequence
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
    : '[' WILDCARD ']' #wildcard
    | '[' NUMBER (',' NUMBER)* ']' #unionNumber
    | '[' QUOTED_STRING (',' QUOTED_STRING)* ']' #unionString
    | '[' range ']' #slicer
    | '[' '?(' query ')' ']' #filter
    ;

range : rangeStart=NUMBER? ':' rangeEnd=NUMBER? (':' rangeStep=NUMBER)?;


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

PATH_SEPERATOR : '.';
WILDCARD : '*';
DESCENDANTS : '..';
RELATIVE : '@';
ROOT : '$';
IDENTITY : [a-zA-Z][a-zA-Z0-9]* ;
NUMBER   : '0' | '-'? [1-9][0-9]* ;
WS       :  [ \t\n\r]+ -> skip ;
