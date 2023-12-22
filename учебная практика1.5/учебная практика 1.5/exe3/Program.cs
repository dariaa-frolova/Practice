using System;
using System.IO;

namespace exe3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.5/exe3/numsTask3.txt";
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

                int min = nums[0], index = 0;
                for(int i = 0; i < nums.Length; i++)
                    if (nums[i] < min)
                    {
                        min = nums[i];
                        index = i;
                    }

                float arithMean = 0;
                for (int i = 0; i < index; i++)
                    arithMean += nums[i];
                arithMean /= index;
                
                Console.WriteLine($"Arithmetic mean of numbers up to the minimum number: {Math.Round(arithMean, 2)}");
            }
        }
    }
}