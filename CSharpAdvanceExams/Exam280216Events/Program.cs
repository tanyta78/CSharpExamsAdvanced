using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam280216Events
{
   public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = "^#([a-zA-Z]*):\\s*@([a-zA-Z]*)\\s*((0[0-9]|1[0-9]|2[0-3]):[0-5][0-9])$";
            Regex rgx = new Regex(pattern);
            int lines = int.Parse(Console.ReadLine());

            var eventsInfo = new SortedDictionary<string,SortedDictionary<string,List<string>>>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                if (rgx.IsMatch(input))
                {
                    var eventMatches = rgx.Match(input);
                    var name = eventMatches.Groups[1].ToString();
                    var evento = eventMatches.Groups[2].ToString();
                    var time = eventMatches.Groups[3].ToString();

                    if (!eventsInfo.ContainsKey(evento))
                    {
                        eventsInfo.Add(evento,new SortedDictionary<string, List<string>>());
                    }

                    if (!eventsInfo[evento].ContainsKey(name))
                    {
                        eventsInfo[evento].Add(name,new List<string>());
                    }

                    eventsInfo[evento][name].Add(time);

                }
                
            }

            var toPrint = Console.ReadLine().Split(',');

            foreach (var pair in eventsInfo)
            {
                var currentEvent = pair.Key;
                if (toPrint.Contains(currentEvent))
                {
                    Console.WriteLine(currentEvent+":");
                    var count = 1;
                    foreach (var peoplePair in pair.Value)
                    {
                        Console.WriteLine($"{count}. {peoplePair.Key} -> {string.Join(", ",peoplePair.Value.OrderBy(x=>x))}");
                        count++;
                    }
                }
            }


        }
    }
}
