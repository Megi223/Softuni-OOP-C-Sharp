using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimensions[0];
            int y = dimensions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowEvil = evil[0];
                int colEvil = evil[1];

                while (rowEvil >= 0 && colEvil >= 0)
                {
                    if (rowEvil >= 0 && rowEvil < matrix.GetLength(0) && colEvil >= 0 && colEvil < matrix.GetLength(1))
                    {
                        matrix[rowEvil, colEvil] = 0;
                    }
                    rowEvil--;
                    colEvil--;
                }

                int rowIvo = ivoS[0];
                int colIvo = ivoS[1];

                while (rowIvo >= 0 && colIvo < matrix.GetLength(1))
                {
                    if (rowIvo >= 0 && rowIvo < matrix.GetLength(0) && colIvo >= 0 && colIvo < matrix.GetLength(1))
                    {
                        sum += matrix[rowIvo, colIvo];
                    }

                    colIvo++;
                    rowIvo--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
