using System;
using System.IO;

namespace exe2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way_of_nums = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.3/exe2/nums.txt";
            using (StreamReader input = new StreamReader(way_of_nums))
            {    
                string nums_in_line = input.ReadLine();
                input.Close();    
                
                string[] nums = nums_in_line.Split(' ');
                using (StreamWriter output = new StreamWriter(way_of_nums))    
                {
                    foreach (var number in nums)        
                    {
                        int num;                
                        if (int.TryParse(number, out num)) 
                            if (num % 2 != 0)                        
                                output.Write(num + " ");
                    }    
                }
            }
        }
    }
}
//56 84 57 -5 -46 23 15 73 84 93 75 83