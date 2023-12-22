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
                string input = Console.ReadLine();
                int num;
                if (int.TryParse(input, out num))
                {
                    if (num < 0)
                        break;
                    else
                        nums.Add(num);
                }
            }

            Console.Write("Enter the number a = ");

            int a = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
                if (nums[i] % a == 0)
                    sum += nums[i];

            Console.WriteLine($"The sum of the numbers divisible by the number a: {sum}");
        }
    }
}