using System;
using System.IO;
using System.Linq;

namespace exe1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.5/exe1/numsTask1.txt";
            using (StreamReader input = new StreamReader(way))
            {
                string numsInLIne = input.ReadToEnd();
                input.Close();

                string[] numsStr = numsInLIne.Split(' ');
                int[] nums = new int[numsStr.Length];
                for (int i = 0; i < numsStr.Length; i++)
                {
                    int num;
                    if (int.TryParse(numsStr[i], out num))
                        nums[i] = num;
                }

                int min = nums[0];
                for (int i = 0; i < nums.Length; i++)
                    if (nums[i] < min)
                    {
                        min = nums[i];
                    }

                int product = 1;
                for (int i = nums.Length - 1; i > -1; i--)
                {
                    if (nums[i] == min)
                        break;
                    product *= nums[i];
                }

                Console.WriteLine($"The product of the numbers after the minimum number: {product}");
            }
        }
    }
}