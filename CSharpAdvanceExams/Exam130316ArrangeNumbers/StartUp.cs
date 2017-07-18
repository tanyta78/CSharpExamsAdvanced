using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam130316ArrangeNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numberDictionary = new Dictionary<int, string>()
          {
              {0, "zero"},
              {1, "one"},
              {2, "two"},
              {3, "three"},
              {4, "four"},
              {5, "five"},
              {6, "six"},
              {7, "seven"},
              {8, "eigth"},
              {9, "nine"}
          };

            var inputNumbers = Console.ReadLine().Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var result = new SortedDictionary<string, int>();
            var sb = new StringBuilder();

            foreach (var number in inputNumbers)
            {
                var currentNumber = number;
                var stackNumber = new Stack<int>();
                if (currentNumber == 0)
                {
                    stackNumber.Push(0);
                }
                else
                {
                    while (currentNumber > 0)
                    {
                        var currentDigit = currentNumber % 10;
                        stackNumber.Push(currentDigit);
                        currentNumber = currentNumber / 10;
                    }
                }

                while (stackNumber.Count > 0)
                {
                    sb.Append(numberDictionary[stackNumber.Pop()]);
                    sb.Append("-");
                }
                sb.Length -= 1;

                result.Add(sb.ToString(), number);
                sb.Clear();
            }

            foreach (var pair in result)
            {
                sb.Append(pair.Value);
                sb.Append(", ");
            }
            sb.Length -= 2;

            Console.WriteLine(sb.ToString());
        }

        public static void AuthorD()
        {
            string[] IntegerNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            Console.WriteLine(string.Join(", ", Console.ReadLine()
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .OrderBy(str => string.Join(string.Empty, str.Select(ch => IntegerNames[ch - '0'])))));
        }
    }
}