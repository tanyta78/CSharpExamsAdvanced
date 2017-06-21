using System;
using System.Linq;

namespace Exam130316Monopoly
{
    public class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var playGroundRows = dimensions[0];
            var playGroundCols = dimensions[1];

            string[,] playGround = new string[playGroundRows, playGroundCols];

            for (int rowIndex = 0; rowIndex < playGroundRows; rowIndex++)
            {
                var currentRow = Console.ReadLine();
                for (int colIndex = 0; colIndex < playGroundCols; colIndex++)
                {
                    playGround[rowIndex, colIndex] = currentRow[colIndex].ToString();
                }
            }

            Console.WriteLine();
            //lets play
            int hotels = 0;
            int money = 50;
            int turns = 0;

            for (int rowIndex = 0; rowIndex < playGroundRows; rowIndex++)
            {
                if (rowIndex % 2 == 1)
                {
                    //start row from last to first index
                    for (int colIndex = playGroundCols - 1; colIndex >= 0; colIndex--)
                    {
                        var currentCommand = playGround[rowIndex, colIndex];
                        switch (currentCommand)
                        {
                            case "H":
                                hotels++;
                                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                                money = 0;
                                turns++;
                                break;

                            case "F":
                                turns++;
                                break;

                            case "S":
                                var product = (colIndex + 1) * (rowIndex + 1);
                                if (money < product)
                                {
                                    Console.WriteLine($"Spent {money} money at the shop.");
                                    money = 0;
                                    turns++;
                                }
                                else
                                {
                                    Console.WriteLine($"Spent {product} money at the shop.");
                                    money -= product;
                                    turns++;
                                }
                                break;

                            case "J":
                                Console.WriteLine($"Gone to jail at turn {turns}.");
                                turns += 3;
                                money += hotels * 20;
                                break;
                        }

                        money += hotels * 10;
                    }
                }
                else
                {
                    //start row from first to last index
                    for (int colIndex = 0; colIndex < playGroundCols; colIndex++)
                    {
                        var currentCommand = playGround[rowIndex, colIndex];
                        switch (currentCommand)
                        {
                            case "H":
                                hotels++;
                                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                                money = 0;
                                turns++;
                                break;

                            case "F":
                                turns++;
                                break;

                            case "S":
                                var product = (colIndex + 1)* (rowIndex+1);
                                if (money < product)
                                {
                                    Console.WriteLine($"Spent {money} money at the shop.");
                                    money = 0;
                                    turns++;
                                }
                                else
                                {
                                    Console.WriteLine($"Spent {product} money at the shop.");
                                    money -= product;
                                    turns++;
                                }
                                break;

                            case "J":
                                Console.WriteLine($"Gone to jail at turn {turns}.");
                                turns += 3;
                                money += hotels * 20;
                                break;
                        }

                        money += hotels * 10;
                    }
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        public static void AuthorD()
        {
            int rows = int.Parse(Console.ReadLine().Split()[0]);
            int money = 50;
            int numberOfHotels = 0;
            int turns = 0;

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    int index = row % 2 == 0 ? col : currentRow.Length - col - 1;
                    switch (currentRow[index])
                    {
                        case 'H':
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++numberOfHotels}.");
                            money = 0;
                            break;
                        case 'J':
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            turns += 2;
                            money += 2 * (numberOfHotels * 10);
                            break;
                        case 'S':
                            int columnIndex = row % 2 == 0 ? col : index;
                            int moneyToSpend = Math.Min((columnIndex + 1) * (row + 1), money);
                            money -= moneyToSpend;
                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            break;
                    }
                    money += numberOfHotels * 10;
                    turns++;
                }
            }
            Console.WriteLine("Turns " + turns);
            Console.WriteLine("Money " + money);
        }
    }


}