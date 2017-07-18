using System;
using System.Numerics;

namespace Exam280216SUNumerals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] keyConverter = new[] { "aa", "aba", "bcc", "cc", "cdc" };
            string result = String.Empty;
            string input = Console.ReadLine();

            while (input.Length > 0)
            {
                for (int index = 0; index < keyConverter.Length; index++)
                {
                    var currentString = keyConverter[index];
                    if (input.StartsWith(currentString))
                    {
                        result += index;
                        input = input.Substring(currentString.Length);
                        break;
                    }
                }
            }

            //result is number string to convert to 10
            Console.WriteLine(ConvertBase5toBase10(result));
        }

        private static BigInteger ConvertBase5toBase10(string result)
        {
            BigInteger numberToPrint = 0;
            for (int index = 0; index < result.Length; index++)
            {
                //start from last digit
                BigInteger nextDigit = result[result.Length - 1 - index] - '0';
                //5 is base = can use for diff bases
                numberToPrint += nextDigit * BigInteger.Pow(5, index);
            }
            return numberToPrint;
        }
    }
}