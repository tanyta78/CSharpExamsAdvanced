using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam22082016
{
    public class Exam
    {
        public static void Main()
        {
            string pattern = "\\b^Grow <([A-Z][a-z]+)> <([a-zA-Z0-9]+)> ([0-9]+)";
            Regex newRegex = new Regex(pattern);
            var regionColorRoses = new SortedDictionary<string, SortedDictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != null && !input.Equals("Icarus, Ignite!"))
            {
                if (Regex.IsMatch(input, pattern))
                {
                    var region = newRegex.Match(input).Groups[1].ToString();
                    var color = newRegex.Match(input).Groups[2].ToString();
                    long count = long.Parse(newRegex.Match(input).Groups[3].ToString());
                    if (!regionColorRoses.ContainsKey(region))
                    {
                        regionColorRoses.Add(region, new SortedDictionary<string, long>());
                    }
                    if (!regionColorRoses[region].ContainsKey(color))
                    {
                        regionColorRoses[region].Add(color, 0);
                    }
                    regionColorRoses[region][color] += count;
                }

                input = Console.ReadLine();
            }

            foreach (var pair in regionColorRoses.OrderByDescending(rcr => rcr.Value.Values.Sum()))
            {
                Console.WriteLine(pair.Key);
                foreach (var colorRoses in pair.Value.OrderBy(c => c.Value))
                {
                    Console.WriteLine($"*--{colorRoses.Key} | {colorRoses.Value}");
                }
            }
        }

        public static void Nms()
        {
            string input = Console.ReadLine();
            List<string> wordsList = new List<string>();
            var text = new StringBuilder();

            while (input != null && !input.Equals("---NMS SEND---"))
            {
                text.Append(input);

                input = Console.ReadLine();
            }

            char[] textCharArray = text.ToString().ToCharArray();
            var word = new StringBuilder();
            for (int i = 0; i < textCharArray.Length - 1; i++)
            {
                word.Append(text[i]);
                if (char.ToUpperInvariant(text[i]) <= char.ToUpperInvariant(text[i + 1]))
                {
                    continue;
                }
                else
                {
                    wordsList.Add(word.ToString());
                    word.Clear();
                }
            }

            word.Append(text[text.Length - 1]);
            wordsList.Add(word.ToString());

            string delimiter = Console.ReadLine();

            Console.WriteLine(string.Join(delimiter, wordsList));
        }

        public static void NatureProfit()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            //create garden
            List<List<int>> garden = new List<List<int>>();
            for (int rowsIndex = 0; rowsIndex < rows; rowsIndex++)
            {
                var currentRow = new List<int>();
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    currentRow.Add(0);
                }
                garden.Add(currentRow);
            }

            List<List<int>> bloomGarden = new List<List<int>>();
            for (int rowsIndex = 0; rowsIndex < rows; rowsIndex++)
            {
                var currentRow = new List<int>();
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    currentRow.Add(0);
                }
                bloomGarden.Add(currentRow);
            }

            //plant flowers
            string input = Console.ReadLine();
            while (input != null && !input.Equals("Bloom Bloom Plow"))
            {
                int[] coordinates = input.Split(' ').Select(int.Parse).ToArray();
                int rowIndex = coordinates[0];
                int colIndex = coordinates[1];
                garden[rowIndex][colIndex] = 1;
                input = Console.ReadLine();
            }

            //make bloomGarden
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                while (garden[rowIndex].IndexOf(1) != -1)
                {
                    int affectedCol = garden[rowIndex].IndexOf(1);
                    //change bloomgardenRow
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        bloomGarden[rowIndex][colIndex] += 1;
                    }
                    //change bloomgardenCol
                    for (int rIndex = 0; rIndex < rows; rIndex++)
                    {
                        bloomGarden[rIndex][affectedCol] += 1;
                    }
                    bloomGarden[rowIndex][affectedCol] -= 1;
                    garden[rowIndex][affectedCol] = 0;
                }
            }

            //print bloomGarden
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", bloomGarden[rowIndex]));
            }
        }

        public static void SecondNature()
        {
            List<int> flowersDust = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> bucketsOfWater = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> secondNatureFlowers = new List<int>();

            LinkedList<int> flowers = new LinkedList<int>();
            foreach (var flower in flowersDust)
            {
                flowers.AddLast(flower);
            }

            Stack<int> buckets = new Stack<int>();
            foreach (var bucket in bucketsOfWater)
            {
                buckets.Push(bucket);
            }

            while (flowers.Count > 0 && buckets.Count > 0)
            {
                int currentBucket = buckets.Pop();

                if (currentBucket > flowers.First.Value)
                {
                    if (buckets.Count == 0)
                    {
                        buckets.Push(currentBucket - flowers.First.Value);
                    }
                    else
                    {
                        buckets.Push(buckets.Pop() + currentBucket - flowers.First.Value);
                    }
                    flowers.RemoveFirst();
                }
                else if (currentBucket < flowers.First.Value)
                {
                    var cuurentFlower = flowers.First.Value - currentBucket;
                    flowers.RemoveFirst();
                    flowers.AddFirst(cuurentFlower);
                }
                else
                {
                    secondNatureFlowers.Add(flowers.First.Value);
                    flowers.RemoveFirst();
                }
            }

            var sb = new StringBuilder();

            if (flowers.Count == 0 && buckets.Count > 0)
            {
                while (buckets.Count > 0)
                {
                    sb.Append(buckets.Pop() + " ");
                }
                Console.WriteLine(sb.ToString());
            }
            else if (flowers.Count > 0 && buckets.Count == 0)
            {
                //while (flowers.Count > 0)
                //{
                //    sb.Append(flowers.Dequeue() + " ");
                //}
                Console.WriteLine(string.Join(" ", flowers));
            }

            Console.WriteLine(secondNatureFlowers.Count != 0 ? string.Join(" ", secondNatureFlowers) : "None");
        }
    }
}