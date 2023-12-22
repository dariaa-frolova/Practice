using System;
using System.IO;

namespace exe5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.5/exe5/numsTask5.txt";
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
                int min = nums[0], max = nums[0], indexOfMax = 0, indexOfMin = 0;
                for (int i = 0; i < nums.Length; i++)   
                {
                    if (nums[i] < min)        
                    {
                        min = nums[i];            
                        indexOfMin = i;
                    }        
                    
                    if (nums[i] > max)
                    {            
                        max = nums[i];
                        indexOfMax = i;        
                    }
                }
                
                float arithMean = 0;    
                int counter = 0;
                if (indexOfMax > indexOfMin)
                    for (int i = indexOfMin + 1; i < indexOfMax; i++)
                    {            
                        arithMean += nums[i];
                        counter++;        
                    }
                else        
                    for (int i = indexOfMax + 1; i < indexOfMin; i++)
                    {  
                        arithMean += nums[i];
                        counter++;
                    }
                arithMean /= counter;
                
                Console.WriteLine($"The arithmetic mean of the numbers located between the minimum and maximum: {Math.Round(arithMean, 2)}");
            }
        }
    }
}