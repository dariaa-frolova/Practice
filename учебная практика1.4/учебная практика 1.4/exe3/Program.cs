using System;
using System.IO;

namespace exe3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.4/exe3/numsTask3.txt";
            using (StreamReader input = new StreamReader(way))
            {    
                string numsInLine = input.ReadToEnd();
                input.Close();    
                
                string[] nums1 = numsInLine.Split(',');    
                int[] nums = new int[nums1.Length];
                for (int i = 0; i < nums1.Length; i++)
                {
                    int num;        
                    if (int.TryParse(nums1[i], out num))
                        nums[i] = num;    
                }
                
                int min = nums[0], max = nums[0];
                for (int i = 0; i < nums.Length; i++)    
                {
                    if (nums[i] == 0)            
                        break;
                    else
                    {
                        if (max < nums[i])
                            max = nums[i];
                        if (min > nums[i])
                            min = nums[i];
                    }
                }
                
                Console.WriteLine($"The ratio of the minimum ({min}) to the maximum ({max}): {Math.Round((double)min / max, 2)}");
            }
        }
    }
}