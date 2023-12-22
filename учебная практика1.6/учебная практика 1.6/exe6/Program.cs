using System;

namespace exe6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            
            float[] nums = new float[num];
            
            int counterOfPositiveNums = 0, counterOfNegativeNums = 0;
            Random random = new Random();
            
            for (int i = 0; i < num; i++)
            {
                nums[i] = random.Next(-50,50);   
                if (nums[i] < 0)
                    counterOfNegativeNums++;   
                else if (nums[i] > 0)
                    counterOfPositiveNums++;
            }
            
            float[] positiveNums = new float[counterOfPositiveNums];
            float[] negativeNums = new float[counterOfNegativeNums];
            int indexOfPositive = 0, indexOfNegative = 0;
            for (int i = 0; i < num; i++)
            {   
                if (nums[i] > 0)
                {       
                    positiveNums[indexOfPositive] = nums[i];
                    indexOfPositive++;
                }
                if (nums[i] < 0)    
                {
                    negativeNums[indexOfNegative] = nums[i];     
                    indexOfNegative++;
                }
            }
            
            Console.WriteLine("Negative array:");
            for (int i = 0; i < counterOfNegativeNums; i++)   
                Console.Write(negativeNums[i] + " ");
            
            Console.WriteLine();
            
            Console.WriteLine("Positive array:");
            for(int i = 0; i < counterOfPositiveNums; i++)
                Console.Write(positiveNums[i] + " ");
        }
    }
}