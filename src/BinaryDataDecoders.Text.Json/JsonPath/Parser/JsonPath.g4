grammar JsonPath;

start 
    : path EOF
    ;

path
    : pathBase sequence
    ;

pathBase 
    : ROOT 
    | RELATIVE
    ;

sequence
    : sequenceItem  sequence?
    ;

sequenceItem
    : '.'? (
            WILDCARD        		//.*
            | identity      		// .item or ./item['bracketChain']
            | bracket          		// .[...] ir [...]
            | filter          		// .[?(...)] ir [?(...)]
        )
    | DESCENDANTS                   // ..
    ;

bracket 
    : '[' WILDCARD ']' 
    | '[' NUMBER (',' NUMBER)* ']'
    | '[' string (',' string)* ']'
    | '[' range ']'
    ;

filter
    : '[' '?(' query ')' ']'
    ;

range : rangeStart=NUMBER? ':' rangeEnd=NUMBER? (':' rangeStep=NUMBER)?;

operand
    : path
    | string
    | NUMBER
    ;

query
    : path #queryPath
    | relationLeft=operand RELATIONAL relationRight=operand #queryRelational
    | relationLeft=query LOGICAL relationRight=query #queryLogical
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
    : '&&' | '||'
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
