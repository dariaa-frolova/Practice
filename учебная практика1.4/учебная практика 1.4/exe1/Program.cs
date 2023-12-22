using System;

namespace exe1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];
            int product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
                if (arr[i] % 3 == 0 && arr[i] != 0)
                    product *= arr[i];
            }
            Console.WriteLine($"The product of numbers that are multiples of 3: {product}");
        }
    }
}