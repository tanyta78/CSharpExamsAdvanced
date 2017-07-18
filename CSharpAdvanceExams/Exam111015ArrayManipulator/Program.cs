using System;
using System.Linq;

namespace Exam111015resultayManipulator
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                var commands = input.Split();
                switch (commands[0])
                {
                    case "exchange":
                        numbers = ExchangeNumbers(numbers, commands[1]);
                        break;

                    case "max":
                    case "min":
                        Console.WriteLine(GetIndexOf(commands, numbers));
                        break;

                    case "first":
                    case "last":
                        Console.WriteLine(GetNewList(commands, numbers));
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }

        private static string GetNewList(string[] commands, int[] numbers)
        {
            var r = commands[2];
            int count = int.Parse(commands[1]);
            var reminder = r == "odd" ? 1 : 0;
            if (count > numbers.Length)
            {
                return "Invalid count";
            }
            else
            {
                var filtered = numbers.Where(x => x % 2 == reminder).ToArray();
                if (!filtered.Any())
                {
                    return "[]";
                }
                else
                {
                    return commands[0] == "first"
                        ? "[" + string.Join(", ", filtered.Take(count)) + "]"
                        : "[" + string.Join(", ",
                             filtered.Reverse().Take(count).Reverse()) + "]";
                }
            }
        }

        private static string GetIndexOf(string[] commands, int[] numbers)
        {
            string r = commands[1];
            int reminder = r == "odd" ? 1 : 0;
            var filtered = numbers.Where(x => x % 2 == reminder).ToArray();
            if (!filtered.Any())
            {
                return "No matches";
            }
            else
            {
                return commands[0] == "max"
                     ? Array.LastIndexOf(numbers, filtered.Max()).ToString()
                     : Array.LastIndexOf(numbers, filtered.Min()).ToString();
            }
        }

        private static int[] ExchangeNumbers(int[] numbers, string s)
        {
            var index = int.Parse(s);

            if (index >= numbers.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }
            else
            {
                return numbers.Skip(index + 1).Concat(numbers.Take(index + 1)).ToArray();
            }
        }
    }
}