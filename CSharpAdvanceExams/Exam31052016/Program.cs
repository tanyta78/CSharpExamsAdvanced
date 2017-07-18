using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam31052016
{
    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string commandLine = Console.ReadLine();
            var result = input;
            while (commandLine.Equals("end"))
            {
                var tokens = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                switch (tokens[0])
                {
                    case "reverse": result = ReversePartOfList(tokens, result); break;
                    case "sort": result = SortPartOfList(tokens, result); break;
                    case "rollLeft": result = RollLeftPartOfList(tokens, result); break;
                    case "rollRight": result = RollRightPartOfList(tokens, result); break;
                }
            }
        }

        private static List<string> RollRightPartOfList(List<string> tokens, List<string> result)
        {
            throw new NotImplementedException();
        }

        private static List<string> RollLeftPartOfList(List<string> tokens, List<string> result)
        {
            throw new NotImplementedException();
        }

        private static List<string> SortPartOfList(List<string> tokens, List<string> result)
        {
            throw new NotImplementedException();
        }

        private static List<string> ReversePartOfList(List<string> tokens, List<string> result)
        {
            throw new NotImplementedException();
        }
    }
}