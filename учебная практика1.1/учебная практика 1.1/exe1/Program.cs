using System;
namespace учебная_практика_1._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[10];
            Random random = new Random();
            
            Console.WriteLine("Array:");
            for (int i = 0; i < 10; i++)
            {
                arr[i] = random.Next(100);
                if (i == 9)
                    Console.Write(arr[i]);
                else
                    Console.Write(arr[i] + ", ");
            }

            Console.WriteLine();

            int min = arr[0];
            for (int i = 0; i < 10; i ++)
                if (min > arr[i])
                    min = arr[i];
            
            Console.WriteLine($"Minimum element of array: {min}");
        }
    }
}