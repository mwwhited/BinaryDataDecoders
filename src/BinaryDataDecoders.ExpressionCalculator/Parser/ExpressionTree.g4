grammar ExpressionTree;
/*
 * Parser Rules

 This version supports defined order of operations
 */
 
start : expression EOF;

value : NUMBER | VARIABLE;

innerExpression 
	: '[' inner=expression ']' 
	| '(' inner=expression ')'
	;

unaryOperatorLeftExpression
	: operator=SUB (value | innerExpression | unaryOperatorLeftExpression)
	;
	
unaryOperatorRightExpression
	: value  operator=FACTORIAL
	| innerExpression  operator=FACTORIAL
	| unaryOperatorRightExpression operator=FACTORIAL 
	;

expression
	: value                 
	| unaryOperatorLeftExpression 
	| unaryOperatorRightExpression          
	| innerExpression
	| left=expression operator=POW right=expression
	| left=expression operator=(MUL|DIV|MOD) right=expression
	| left=expression operator=(ADD|SUB) right=expression
	;

/*
 * Lexer Rules
 */

POW: '^';
MUL: '*';
DIV: '/';
ADD: '+';
SUB: '-';
MOD: '%';
FACTORIAL: '!';

NUMBER: /*'-'?*/ [0-9]+ ('.' [0-9]+)?;
/* Allowed Examples
1
1.1
0.5
-1
-1.1
...
*/

VARIABLE: [A-Z][a-zA-Z0-9]*;
/* Allowed Examples
A
Ab
A1
Abbb
A123
*/

WHITESPACE: [ \r\n\t]+ -> skip;