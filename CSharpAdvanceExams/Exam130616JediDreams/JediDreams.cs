using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam130616JediDreams
{
    public class JediDreams
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, List<string>>();

            string patternForMethods = @"static\s+.*?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)\s*\(";
            string patternForInsideMethods = @"([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(";

            var regexForMethods = new Regex(patternForMethods);
            var regexForInsideMethods = new Regex(patternForInsideMethods);

            string currentMethod = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                string inputLine = Console.ReadLine();
                if (regexForMethods.IsMatch(inputLine))
                {
                    Match method = regexForMethods.Match(inputLine);
                    currentMethod = method.Groups[1].Value;

                    if (!result.ContainsKey(currentMethod))
                    {
                        result.Add(currentMethod,new List<string>());
                    }
                }
                else if (regexForInsideMethods.IsMatch(inputLine) && currentMethod!=String.Empty)
                {
                    var insidesMethodsMatches = regexForInsideMethods.Matches(inputLine);

                    foreach (Match insidesMethodsMatch in insidesMethodsMatches)
                    {
                        result[currentMethod].Add(insidesMethodsMatch.Groups[1].Value);
                    }
                   
                }
            }

            var sortedResult = result.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key);

            foreach (var pair in sortedResult)
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine(
                        $"{pair.Key} -> {pair.Value.Count} -> {string.Join(", ", pair.Value.OrderBy(x => x))}");
                }
                else
                {
                    Console.WriteLine($"{pair.Key} -> None");
                }
               
            }
        }
    }
}