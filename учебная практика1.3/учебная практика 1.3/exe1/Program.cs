using System;
using System.IO;

namespace exe1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string wayOfInput = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.3/exe1/input.txt";
            using (StreamReader input = new StreamReader(wayOfInput))
            {    
                string luckyNumbersInLine = input.ReadLine();

                string[] luckyNumbersStr = luckyNumbersInLine.Split(' ');
                int[] lucky_numbers = new int[luckyNumbersStr.Length];
                for (int i = 0; i < luckyNumbersStr.Length; i++)
                {
                    int num;
                    if (int.TryParse(luckyNumbersStr[i], out num))
                        lucky_numbers[i] = num;
                }

                int n = Convert.ToInt32(input.ReadLine());
                string lucky = "Lucky", unlucky = "Unlucky";
                
                string way_of_output = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.3/exe1/output.txt";
                using (StreamWriter output = new StreamWriter(way_of_output))
                {
                    for (int i = 0; i < n; i++)        
                    {
                        string option_in_line = input.ReadLine();
                        string[] optionStr = option_in_line.Split(' ');
                        int[] option = new int[6];
                        for (int j = 0; j < optionStr.Length; j++)
                        {
                            int opt;
                            if (int.TryParse(optionStr[j], out opt))
                                option[j] = opt;
                        }

                        int counter = 0;
                        for (int j = 0; j < 10; j++)                
                            for (int k = 0; k < 6; k++)
                                if (lucky_numbers[j] == option[k])                        
                                    counter++;
                        if (counter >= 3)                
                            output.WriteLine(lucky);
                        else                
                            output.WriteLine(unlucky);
                    }
                }
            }
        }
    }
}