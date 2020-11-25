using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit
{
    public static class ConsoleEx
    {        
        public static string? Prompt(string? prompt = null, string? defaultValue = null)
        {
            if (!string.IsNullOrWhiteSpace(prompt))
                Console.Write("{0} ", prompt);
            if (!string.IsNullOrWhiteSpace(defaultValue))
                Console.Write("{0}", defaultValue);

            var chars = new List<char>(defaultValue ?? "");
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    return null;
                else if (key.Key == ConsoleKey.Enter)
                    break;
                else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
                {
                    if (chars.Count > 0)
                    {
                        chars.RemoveAt(chars.Count - 1);
                        Console.Write((char)8);
                        Console.Write(" ");
                        Console.Write((char)8);
                    }
                }
                else
                {
                    chars.Add(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            Console.WriteLine();
            var result = new string(chars.ToArray());
            return result;
        }

        public static string? PromptSecure(string? prompt = null, string? defaultValue = null, char hideWith = '*')
        {
            if (!string.IsNullOrWhiteSpace(prompt))
                Console.Write($"{prompt} ");
            if (!string.IsNullOrWhiteSpace(defaultValue))
                Console.Write($"{new string(hideWith, defaultValue.Length)}");

            var chars = new List<char>(defaultValue ?? "");
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    return null;
                else if (key.Key == ConsoleKey.Enter)
                    break;
                else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
                {
                    if (chars.Count > 0)
                    {
                        chars.RemoveAt(chars.Count - 1);
                        Console.Write((char)8);
                        Console.Write(" ");
                        Console.Write((char)8);
                    }
                }
                else
                {
                    chars.Add(key.KeyChar);
                    Console.Write(hideWith);
                }
            }
            Console.WriteLine();
            var result = new string(chars.ToArray());
            return result;
        }
    }
}
