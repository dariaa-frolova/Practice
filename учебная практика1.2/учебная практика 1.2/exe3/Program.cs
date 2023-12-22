using System;


namespace exe3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = matrix[i, j - 1] + matrix[i - 1, j];
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}