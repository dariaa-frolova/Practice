using System;
using System.IO;

namespace exe4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.5/exe4/numsTask4.txt";
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
                
                int max = nums[0];
                for (int i = 0; i < nums.Length; i++)        
                    if (nums[i] > max)
                        max = nums[i];
                
                int sum = 0;   
                for (int i = 0; i < nums.Length; i++)
                    if (nums[i] == max - 1)            
                        sum += nums[i];
                
                Console.WriteLine($"The sum of the numbers that are less than the maximum by 1: {sum}");
            }
        }
    }
}