
# BinaryDataDecoders.Apple2.ApplesoftBASIC.TokenMap
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Apple2_TokenMap.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Apple2.ApplesoftBASIC.TokenMap            | 
| Assembly             | BinaryDataDecoders.Apple2                                    | 
| Coveredlines         | 114                                                          | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 114                                                          | 
| Totallines           | 131                                                          | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\ApplesoftBASIC\TokenMap.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | GetToken | 
| 1          | 100   | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\ApplesoftBASIC\TokenMap.cs

```CSharp
〰1:   using System.Linq;
〰2:   
〰3:   namespace BinaryDataDecoders.Apple2.ApplesoftBASIC
〰4:   {
〰5:       /// <summary>
〰6:       /// AppleSoft Basic token map
〰7:       /// </summary>
〰8:       public class TokenMap
〰9:       {
〰10:          /// <summary>
〰11:          /// Lookup token for provided byte
〰12:          /// </summary>
〰13:          /// <param name="code"></param>
〰14:          /// <returns></returns>
✔15:          public string GetToken(byte code) => tokens.Where(t => t.code == code).Select(t => t.token).FirstOrDefault();
〰16:  
✔17:          private (int code, string token)[] tokens = new[]
✔18:          {
✔19:              (0x80, "END"),
✔20:              (0x81, "FOR"),
✔21:              (0x82, "NEXT"),
✔22:              (0x83, "DATA"),
✔23:              (0x84, "INPUT"),
✔24:              (0x85, " DEL"),
✔25:              (0x86, "DIM"),
✔26:              (0x87, "READ"),
✔27:              (0x88, "GR"),
✔28:              (0x89, "TEXT"),
✔29:              (0x8A, "PR #"),
✔30:              (0x8B, "IN #"),
✔31:              (0x8C, "CALL"),
✔32:              (0x8D, "PLOT"),
✔33:              (0x8E, "HLIN"),
✔34:              (0x8F, "VLIN"),
✔35:              (0x90, "HGR2"),
✔36:              (0x91, "HGR"),
✔37:              (0x92, "HCOLOR="),
✔38:              (0x93, "HPLOT"),
✔39:              (0x94, "DRAW"),
✔40:              (0x95, "XDRAW"),
✔41:              (0x96, "HTAB"),
✔42:              (0x97, "HOME"),
✔43:              (0x98, "ROT="),
✔44:              (0x99, "SCALE="),
✔45:              (0x9A, "SHLOAD"),
✔46:              (0x9B, "TRACE"),
✔47:              (0x9C, "NOTRACE"),
✔48:              (0x9D, "NORMAL"),
✔49:              (0x9E, "INVERSE"),
✔50:              (0x9F, "FLASH"),
✔51:              (0xA0, "COLOR="),
✔52:              (0xA1, "POP"),
✔53:              (0xA2, "VTAB"),
✔54:              (0xA3, "HIMEM:"),
✔55:              (0xA4, "LOMEM:"),
✔56:              (0xA5, "ONERR"),
✔57:              (0xA6, "RESUME"),
✔58:              (0xA7, "RECALL"),
✔59:              (0xA8, "STORE"),
✔60:              (0xA9, "SPEED="),
✔61:              (0xAA, "LET"),
✔62:              (0xAB, " GOTO"),
✔63:              (0xAC, "RUN"),
✔64:              (0xAD, "IF"),
✔65:              (0xAE, "RESTORE"),
✔66:              (0xAF, "&"),
✔67:              (0xB0, "GOSUB"),
✔68:              (0xB1, "RETURN"),
✔69:              (0xB2, "REM"),
✔70:              (0xB3, "STOP"),
✔71:              (0xB4, "ON"),
✔72:              (0xB5, "WAIT"),
✔73:              (0xB6, "LOAD"),
✔74:              (0xB7, "SAVE"),
✔75:              (0xB8, "DEF FN"),
✔76:              (0xB9, "POKE"),
✔77:              (0xBA, "PRINT"),
✔78:              (0xBB, "CONT"),
✔79:              (0xBC, "LIST"),
✔80:              (0xBD, "CLEAR"),
✔81:              (0xBE, "GET"),
✔82:              (0xBF, "NEW"),
✔83:              (0xC0, "TAB"),
✔84:              (0xC1, " TO"),
✔85:              (0xC2, "FN"),
✔86:              (0xC3, "SPC("),
✔87:              (0xC4, " THEN"),
✔88:              (0xC5, " AT"),
✔89:              (0xC6, "NOT"),
✔90:              (0xC7, " STEP"),
✔91:              (0xC8, " +"),
✔92:              (0xC9, " -"),
✔93:              (0xCA, " *"),
✔94:              (0xCB, " /"),
✔95:              (0xCC, ";"),
✔96:              (0xCD, " AND"),
✔97:              (0xCE, " OR"),
✔98:              (0xCF, " >"),
✔99:              (0xD0, "="),
✔100:             (0xD1, " <"),
✔101:             (0xD2, "SGN"),
✔102:             (0xD3, "INT"),
✔103:             (0xD4, "ABS"),
✔104:             (0xD5, "USR"),
✔105:             (0xD6, "FRE"),
✔106:             (0xD7, "SCRN ("),
✔107:             (0xD8, "PDL"),
✔108:             (0xD9, "POS"),
✔109:             (0xDA, "SQR"),
✔110:             (0xDB, "RND"),
✔111:             (0xDC, "LOG"),
✔112:             (0xDD, "EXP"),
✔113:             (0xDE, "COS"),
✔114:             (0xDF, "SIN"),
✔115:             (0xE0, "TAN"),
✔116:             (0xE1, "ATN"),
✔117:             (0xE2, "PEEK"),
✔118:             (0xE3, "LEN"),
✔119:             (0xE4, "STR$"),
✔120:             (0xE5, "VAL"),
✔121:             (0xE6, "ASC"),
✔122:             (0xE7, "CHR$"),
✔123:             (0xE8, "LEFT$"),
✔124:             (0xE9, "RIGHT$"),
✔125:             (0xEA, "MID$"),
✔126:             (0xFD, "("),
✔127:             (0xFE, "("),
✔128:             (0xFF, "("),
✔129:         };
〰130:     }
〰131: }

```
## Footer 
[Return to Summary](Summary.md)

