# BinaryDataDecoders.Apple2.Tests.ApplesoftBASIC.DetokenizerTests

## GetLinesTest

### Targets

* BinaryDataDecoders.Apple2.ApplesoftBASIC::Detokenizer::GetLines
  * BinaryDataDecoders.Apple2, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
$$$ FILE SIZE :419
10 TEXT :HOME 
20 D$= CHR$ (4):REM  CTRL-D
30 VTAB 2:A$= "APPLE II":GOSUB 1000
40 VTAB 4:A$= "DOS VERSION 3.3  SYSTEM MASTER":GOSUB 1000
50 VTAB 7:A$= "JANUARY 1, 1983":GOSUB 1000
60 PRINT D$;"BLOAD LOADER.OBJ0"
70 CALL 4096:REM  FAST LOAD IN INTEGER BASIC
80 VTAB 10:CALL  - 958:A$= "COPYRIGHT APPLE COMPUTER,INC. 1980,1982":GOSUB 1000
90 C= PEEK ( - 1101):IF C= 6 THEN PRINT :INVERSE :A$= "BE SURE CAPS LOCK IS DOWN":GOSUB 1000:NORMAL 
100 PRINT CHR$ (4);"FP"
1000 REM  CENTER STRING A$
1010 B= INT (20 - (LEN (A$) / 2)):IF B=  < 0 THEN B= 1
1020 HTAB B:PRINT A$:RETURN
```

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
