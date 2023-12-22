using System;
using System.IO;

namespace exe4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.4/exe4/numsTask4.txt";
            using (StreamReader input = new StreamReader(way))
            {
                string numsInLine = input.ReadToEnd();
                input.Close();
                
                string[] nums1 = numsInLine.Split(' ');
                
                int[] nums = new int[nums1.Length];
                for (int i = 0; i < nums.Length; i++)    
                {
                    int num;        
                    if (int.TryParse(nums1[i], out num))
                        nums[i] = num;    
                }
                
                int counter = 0;
                for (int i = 1; i < nums.Length; i++)        
                    if (nums[i] == nums[i - 1]) 
                        counter++;
                
                Console.WriteLine($"The number of times the same numbers stood side by side: {counter}");}
        }
    }
}