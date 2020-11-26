# Base32Codec.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Codecs/Base32Codec.cs

## Public Class - Base32Codec

### Comments

 <summary>
 
 </summary>
 <remarks>
  https://tools.ietf.org/html/rfc4648

 The case for base 32 is shown in the following figure, borrowed from
 [7].  Each successive character in a base-32 value represents 5
 successive bits of the underlying octet sequence.  Thus, each group
 of 8 characters represents a sequence of 5 octets (40 bits).
             1          2          3
  01234567 89012345 67890123 45678901 23456789
 +--------+--------+--------+--------+--------+
 |&lt; 1 &gt;&lt; 2| &gt;&lt; 3 &gt;&lt;|.4 &gt;&lt; 5.|&gt;&lt; 6 &gt;&lt;.|7 &gt;&lt; 8 &gt;|
 +--------+--------+--------+--------+--------+
                                         &lt;===&gt; 8th character
                                   &lt;====&gt; 7th character
                              &lt;===&gt; 6th character
                        &lt;====&gt; 5th character
                  &lt;====&gt; 4th character
             &lt;===&gt; 3rd character
       &lt;====&gt; 2nd character
  &lt;===&gt; 1st character
 
  01234567 01234567 01234567 01234567 01234567
  00000000 11111111 22222222 33333333 44444444
  AAAAABBB BBCCCCCD DDDDEEEE EFFFFFGG GGGHHHHH
 </remarks>

### Members

#### Private ReadOnly Field - _base32Alphabet

##### Summary

 * Type: 

#### Public Method - Encode

##### Comments

 <summary>
 Encoding 8bit binary data as base32 string
 </summary>
 <paramname="data">8bit data</param>
 <returns>base32 string</returns>

#####  Parameters

 - byte [  ] data 

#### Public Method - Decode

##### Comments

 <summary>
 Decode base32 string into 8bit binary
 </summary>
 <paramname="input">base32 string</param>
 <returns>8bit data</returns>

#####  Parameters

 - string input 

