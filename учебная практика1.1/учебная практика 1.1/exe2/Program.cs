using System;
using System.Collections.Generic;
namespace exe4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            
            Console.WriteLine("Enter the numbers:");
            while (true)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                    break;
                nums.Add(input);
            }

            float sum = 0;
            int product = 1;
            foreach (int num in nums)
            {
                sum += num;
                product *= num;
            }
            float arithmean = sum / nums.Count;
            
            Console.WriteLine($"The sum of numbers: {sum}, the product of numbers: {product}, the arithmetic mean: {Math.Round(arithmean, 2)}");
        }
    }
}