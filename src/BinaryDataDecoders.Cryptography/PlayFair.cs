using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.Cryptography;

public class PlayFair
{
    /*
    [edit] Using Playfair
    The Playfair cipher uses a 5 by 5 table containing a key word or phrase. Memorization of the keyword and 4 simple rules was all that was required to create the 5 by 5 table and use the cipher.

    To generate the key table, one would first fill in the spaces in the table with the letters of the keyword (dropping any duplicate letters), then fill the remaining spaces with the rest of the letters of the alphabet in order (usually omitting "Q" to reduce the alphabet to fit, other versions put both "I" and "J" in the same space). The key can be written in the top rows of the table, from left to right, or in some other pattern, such as a spiral beginning in the upper-left-hand corner and ending in the center. The keyword together with the conventions for filling in the 5 by 5 table constitute the cipher key.

    To encrypt a message, one would break the message into digraphs (groups of 2 letters) such that, for example, "HelloWorld" becomes "HE LL OW OR LD", and map them out on the key table. The two letters of the digraph look like the corners of a rectangle in the key table. Note the relative position of the corners of this rectangle. Then apply the following 4 rules, in order, to each pair of letters in the plaintext:

    If both letters are the same (or only one letter is left), add an "X" after the first letter. Encrypt the new pair and continue. Some variants of Playfair use "Q" instead of "X", but any uncommon monograph will do. 
    If the letters appear on the same row of your table, replace them with the letters to their immediate right respectively (wrapping around to the left side of the row if a letter in the original pair was on the right side of the row). 
    If the letters appear on the same column of your table, replace them with the letters immediately below respectively (wrapping around to the top side of the column if a letter in the original pair was on the bottom side of the column). 
    If the letters are not on the same row or column, replace them with the letters on the same row respectively but at the other pair of corners of the rectangle defined by the original pair. The order is important – the first encrypted letter of the pair is the one that lies on the same row as the first plaintext letter. 
    To decrypt, use the inverse of these 4 rules (dropping any extra "X"s (or "Q"s) that don't make sense in the final message when you finish).
    */
    public enum Mode
    {
        Q = 1, //to X
        J = 2, //to I
        I = 3  //to J
    }

    public enum Swap
    {
        X = 1,
        Z = 2
    }

    public static char[] BuildKey(string key, Mode mode, Swap swap)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException("key");

        string seed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        char[] cipherKey = new char[5 * 5];
        key = key.ToUpper();
        char cSwap;
        char cMode;

        switch (swap)
        {
            case Swap.X:
                cSwap = 'X';
                break;
            case Swap.Z:
                cSwap = 'Z';
                break;
            default:
                throw new ArgumentOutOfRangeException("swap");
        }

        switch (mode)
        {
            case Mode.Q:
                cMode = 'Q';
                key = key.Replace('Q', cSwap);
                break;
            case Mode.J:
                cMode = 'J';
                key = key.Replace('J', 'I');
                break;
            case Mode.I:
                cMode = 'I';
                key = key.Replace('I', 'J');
                break;
            default:
                throw new ArgumentOutOfRangeException("mode");
        }
        seed = seed.Replace(cMode.ToString(), "");
        int pos = 0;

        foreach (char currentChar in key.ToCharArray())
        {
            if (seed.IndexOf(currentChar) >= 0)
            {
                seed = seed.Replace(currentChar.ToString(), "");
                cipherKey[pos++] = currentChar;
            }

            if (pos >= cipherKey.Length)
                break;
        }

        foreach (char currentChar in seed.ToCharArray())
        {
            if (pos >= cipherKey.Length)
                break;
            cipherKey[pos++] = currentChar;
        }

        return cipherKey;
    }

    public static string Cipher(char[] cryptic, string message, Mode mode, Swap swap)
    {
        if (cryptic == null)
            throw new ArgumentNullException("cryptic");

        if (cryptic.Length != 25)
            throw new ArgumentOutOfRangeException("cryptic");

        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("message");

        message = message.ToUpper();

        char cSwap;
        char cMode;

        switch (swap)
        {
            case Swap.X:
                cSwap = 'X';
                break;
            case Swap.Z:
                cSwap = 'Z';
                break;
            default:
                throw new ArgumentOutOfRangeException("swap");
        }

        string check = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        switch (mode)
        {
            case Mode.Q:
                cMode = 'Q';
                check = check.Replace("Q", "");
                message = message.Replace('Q', cSwap);
                break;
            case Mode.J:
                cMode = 'J';
                check = check.Replace("J", "");
                message = message.Replace('J', 'I');
                break;
            case Mode.I:
                cMode = 'I';
                check = check.Replace("I", "");
                message = message.Replace('I', 'J');
                break;
            default:
                throw new ArgumentOutOfRangeException("mode");
        }

        List<char> newMessage = new List<char>();
        foreach (char currentChar in message.ToCharArray())
            if (check.IndexOf(currentChar) >= 0)
                newMessage.Add(currentChar);
        message = new string(newMessage.ToArray());

        foreach (char currentChar in check.ToCharArray())
        {
            if (currentChar != cSwap)
                message = message.Replace(
                    new string(new char[] { currentChar, currentChar }),
                    new string(new char[] { currentChar, cSwap, currentChar }));
        }

        message = message.PadRight(message.Length + (message.Length % 2), cSwap);

        string sCryptic = new string(cryptic);

        List<char> cipherText = new List<char>();

        for (int i = 0; i < message.Length; i += 2)
        {
            int p1 = sCryptic.IndexOf(message[i]);
            int p2 = sCryptic.IndexOf(message[i + 1]);

            int mn = Math.Min(p1, p2);
            int mx = Math.Max(p1, p2);

            bool column = mn % 5 == mx % 5;
            bool row = mx - mn < 5;

            if (row)
            {
                p1 = p1++ % 5 == 0 ? p1 - 5 : p1;
                p2 = p2++ % 5 == 0 ? p2 - 5 : p2;
            }
            else if (column)
            {
                p1 = p1 += 5 >= 25 ? p1 - 25 : p1;
                p2 = p2 += 5 >= 25 ? p2 - 25 : p2;
            }
            else
            {
                int x1 = p1 % 5;
                int y1 = p1 / 5;

                int x2 = p2 % 5;
                int y2 = p2 / 5;
            }

            cipherText.Add(sCryptic[p1]);
            cipherText.Add(sCryptic[p2]);
        }

        return new string(cipherText.ToArray());
    }
}
