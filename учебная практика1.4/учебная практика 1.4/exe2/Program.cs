using System;
using System.IO;

namespace exe2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string wayOfInput = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.4/exe2/numsTask2.txt";
            using (StreamReader input = new StreamReader(wayOfInput))
            {    
                string numsInLine = input.ReadToEnd();
                input.Close();    
                
                string[] nums1 = numsInLine.Split(';');    
                float[] nums = new float[nums1.Length];
                for (int i = 0; i < nums1.Length; i ++)    
                {
                    float num;
                    if (float.TryParse(nums1[i], out num))
                    {
                        if (num == 0)
                            break;
                        nums[i] = num;
                    }
                }
                
                float sum = 0;
                for (int i = 0; i < nums.Length; i++)    
                {
                    if (nums[i] == 0)            
                        break;
                    if (nums[i] > 0)           
                        sum += nums[i];
                }
                Console.WriteLine($"The sum of the numbers up to zero: {Math.Round(sum, 3)}");}
        }
    }
}