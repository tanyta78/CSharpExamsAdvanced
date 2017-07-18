using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam130616JediGalaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var jediMatrix = new List<List<int>>();
            var count = 0;

            FillMatrix(dimensions, jediMatrix, count);
            // Console.WriteLine();

            long ivoPowers = 0;
            var input = Console.ReadLine();
            while (!input.Equals("Let the Force be with you"))
            {
                var ivoCoordinates = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var evilCoordinates = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentEvilRow = evilCoordinates[0];
                var currentEvilCol = evilCoordinates[1];
                while (currentEvilRow >= 0 && currentEvilCol >= 0)
                {
                    if (IsInMatrix(currentEvilCol, currentEvilRow, jediMatrix))
                    {
                        jediMatrix[currentEvilRow][currentEvilCol] = 0;
                    }
                    currentEvilCol--;
                    currentEvilRow--;
                }

                var currentIvoRow = ivoCoordinates[0];
                var currentIvoCol = ivoCoordinates[1];
                while (currentIvoRow >= 0 && currentIvoCol < dimensions[1])
                {
                    if (IsInMatrix(currentIvoCol, currentIvoRow, jediMatrix))
                    {
                        ivoPowers += jediMatrix[currentIvoRow][currentIvoCol];
                    }
                    currentIvoCol++;
                    currentIvoRow--;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(ivoPowers);
        }

        private static bool IsInMatrix(int currentIvoCol, int currentIvoRow, List<List<int>> jediMatrix)
        {
            bool result = currentIvoRow >= 0
                && currentIvoRow < jediMatrix.Count
                && currentIvoCol >= 0
                && currentIvoCol < jediMatrix[0].Count;
            return result;
        }

        private static void FillMatrix(int[] dimensions, List<List<int>> jediMatrix, int count)
        {
            for (int rowIndex = 0; rowIndex < dimensions[0]; rowIndex++)
            {
                var currentRow = new List<int>();
                for (int colIndex = 0; colIndex < dimensions[1]; colIndex++)
                {
                    currentRow.Add(count);
                    count++;
                }
                jediMatrix.Add(currentRow);
            }
        }
    }
}