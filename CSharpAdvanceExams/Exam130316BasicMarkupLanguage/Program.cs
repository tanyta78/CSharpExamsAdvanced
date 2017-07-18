using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam130316BasicMarkupLanguage
{
    public class Program
    {
        public static void Main()
        {
            string patternForInverse =
                "\\s*<\\s*(\\s*inverse\\s*content\\s*)\\s*=\\s*\"(\\s*[a-zA-Z0-9]*\\s*)\"\\s*\\/>";
            string patternForReverse =
                "\\s*<\\s*(\\s*reverse\\s*content\\s*)\\s*=\\s*\"(\\s*[a-zA-Z0-9]*\\s*)\"\\s*\\/>";
            string patternForRepeat =
                "\\s*<(\\s*repeat\\s*value\\s*)=\\s*\"(\\d+)\" \\s*content\\s*=\\s*\"(\\s*[a-zA-Z0-9]*\\s*)\"\\s*\\/>";

            Regex toInverse = new Regex(patternForInverse);
            Regex toReverse = new Regex(patternForReverse);
            Regex toRepeat = new Regex(patternForRepeat);

            var sb = new StringBuilder();

            string input = Console.ReadLine();
            int row = 1;
            while (!input.Contains("stop"))
            {
                string result = string.Empty;
                bool isPrint = false;
                if (toInverse.IsMatch(input))
                {
                    string forInverse = toInverse.Match(input).Groups[2].ToString();
                    if (forInverse == String.Empty)
                    {
                        input = Console.ReadLine();
                        sb.Clear();
                        continue;
                    }

                    foreach (var ch in forInverse)
                    {
                        if (char.IsLower(ch))
                        {
                            sb.Append(char.ToUpper(ch));
                        }
                        else
                        {
                            sb.Append(char.ToLower(ch));
                        }
                    }
                    result = sb.ToString();
                }
                else if (toReverse.IsMatch(input))
                {
                    string forReverse = toReverse.Match(input).Groups[2].ToString();
                    if (forReverse == String.Empty)
                    {
                        input = Console.ReadLine();
                        sb.Clear();
                        continue;
                    }
                    result = string.Join("", forReverse.Reverse().ToArray());
                }
                else if (toRepeat.IsMatch(input))
                {
                    result = toRepeat.Match(input).Groups[3].ToString();
                    int timesToRepeat = int.Parse(toRepeat.Match(input).Groups[2].ToString());
                    for (int i = 0; i < timesToRepeat; i++)
                    {
                        Console.WriteLine($"{row}. {result}");
                        row++;
                    }
                    isPrint = true;
                }
                if (!isPrint)
                {
                    Console.WriteLine($"{row}. {result}");
                    row++;
                }

                input = Console.ReadLine();
                sb.Clear();
            }
        }

        private static int lineIndex = 1;

        public static void AuthorD()
        {
            string pattern = @"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*";
            Regex rgx = new Regex(pattern);

            string line = Console.ReadLine();
            while (line != "<stop/>")
            {
                Match match = rgx.Match(line);
                string tag = match.Groups[1].Value;
                switch (tag)
                {
                    case "inverse":
                        ProcessInverseTag(match.Groups[3].Value);
                        break;

                    case "reverse":
                        ProcessReverseTag(match.Groups[3].Value);
                        break;

                    case "repeat":
                        ProcessRepeatTag(match.Groups[3].Value, int.Parse(match.Groups[2].Value));
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static void ProcessInverseTag(string input)
        {
            if (input.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in input)
                {
                    if (char.IsUpper(ch))
                    {
                        sb.Append(char.ToLower(ch));
                    }
                    else if (char.IsLower(ch))
                    {
                        sb.Append(char.ToUpper(ch));
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                Console.WriteLine($"{lineIndex++}. {sb}");
            }
        }

        private static void ProcessReverseTag(string input)
        {
            if (input.Length > 0)
            {
                Console.WriteLine($"{lineIndex++}. {string.Join(string.Empty, input.Reverse())}");
            }
        }

        private static void ProcessRepeatTag(string input, int repetitions)
        {
            if (repetitions > 0 && input.Length > 0)
            {
                for (int i = 0; i < repetitions; i++)
                {
                    Console.WriteLine($"{lineIndex++}. {input}");
                }
            }
        }
    }
}