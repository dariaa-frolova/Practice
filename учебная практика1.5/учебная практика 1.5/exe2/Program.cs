using System;
using System.IO;

namespace exe2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.5/exe2/numsTask2.txt";
            using (StreamReader input = new StreamReader(way))
            {
                string numsInLine = input.ReadToEnd();
                input.Close();

                string[] numsStr = numsInLine.Split(';');
                float[] nums = new float[numsStr.Length];
                for (int i = 0; i < numsStr.Length; i++)
                {
                    float num;
                    if (float.TryParse(numsStr[i], out num))
                        nums[i] = num;
                }

                for (int i = 0; i < nums.Length; i++)
                    Console.Write(nums[i] + " ");
                Console.WriteLine();
                
                using (StreamWriter output = new StreamWriter(way))
                {
                    float num1 = 0;
                    for (int i = 0; i < nums.Length; i++)
                        for (int j = 0; j < nums.Length; j++)
                            if (nums[i] < nums[j])
                            {
                                num1 = nums[i];
                                nums[i] = nums[j];
                                nums[j] = num1;
                            }

                    for (int i = 0; i < nums.Length; i++)
                        output.Write(nums[i] + " ");
                    output.Close();
                }
            }
        }
    }
}
//-6,8;9,2;-12,5;65,8;9,3;0;23,6;89,6;-34,8