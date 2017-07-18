using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam130616JediCodeX
{
    public class JediCodeX
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                text.Append(input.Trim());
            }

            string firstPattern = Console.ReadLine();
            string secondPattern = Console.ReadLine();

            string patternForNames =
                Regex.Escape(firstPattern) + @"([a-zA-Z]{" + firstPattern.Length + @"})(?![a-zA-Z])";
            string patternForMessages = Regex.Escape(secondPattern) + @"([a-zA-Z0-9]{" + secondPattern.Length + @"})(?![a-zA-Z0-9])";

            Regex namesRegex = new Regex(patternForNames);
            Regex messagesRegex = new Regex(patternForMessages);

            var allNames = new List<string>();
            var allMessages = new List<string>();

            if (namesRegex.IsMatch(text.ToString()))
            {
                var matches = namesRegex.Matches(text.ToString());
                foreach (Match match in matches)
                {
                    var currentName = match.Groups[1].Value;
                    allNames.Add(currentName);
                }
            }
            if (messagesRegex.IsMatch(text.ToString()))
            {
                var matches = messagesRegex.Matches(text.ToString());
                foreach (Match match in matches)
                {
                    var currentMessage = match.Groups[1].Value;
                    allMessages.Add(currentMessage);
                }
            }

            var indexesForMessages = Console.ReadLine().Split().Select(int.Parse).ToList();
            var result = new List<string>();
            var indexForJedi = 0;
            for (int i = 0; i < indexesForMessages.Count; i++)
            {
                var currentIndex = indexesForMessages[i] - 1;
                if (indexForJedi >= allNames.Count)
                {
                    break;
                }
                if (currentIndex >= 0 && currentIndex < allMessages.Count)
                {
                    result.Add($"{allNames[indexForJedi]} - {allMessages[currentIndex]}");
                    indexForJedi++;
                }
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}