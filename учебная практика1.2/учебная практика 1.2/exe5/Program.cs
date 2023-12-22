using System;
using System.Collections.Generic;
using System.Linq;

namespace exe5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int[]> averageTemperature = new Dictionary<string, int[]>() {};

            int[,] calendar = new int[12,30];
            Random random = new Random();

            for (int i = 0; i < 12; i++)
            {
                int[] temp = new int[30];
                for (int j = 0; j < 30; j++)
                {
                    if (i == 0)
                    {
                        calendar[i, j] = random.Next(-28, -10);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("January", temp);
                    }
                    if (i == 1)
                    {
                        calendar[i, j] = random.Next(-14, 4);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("February", temp);
                    }
                    if (i == 2)
                    {
                        calendar[i, j] = random.Next(-9, 12);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("March", temp);
                    }
                    if (i == 3)
                    {
                        calendar[i, j] = random.Next(-4, 18);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("April", temp);
                    }
                    if (i == 4)
                    {
                        calendar[i, j] = random.Next(3, 23);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("May", temp);
                    }
                    if (i == 5)
                    {
                        calendar[i, j] = random.Next(15, 33);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("June", temp);
                    }
                    if (i == 6)
                    {
                        calendar[i, j] = random.Next(22, 30);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("July", temp);
                    }
                    if (i == 7)
                    {
                        calendar[i, j] = random.Next(15, 25);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("August", temp);
                    }
                    if (i == 8)
                    {
                        calendar[i, j] = random.Next(9, 20);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("September", temp);
                    }
                    if (i == 9)
                    {
                        calendar[i, j] = random.Next(-3, 16);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("October", temp);
                    }
                    if (i == 10)
                    {
                        calendar[i, j] = random.Next(-10, 3);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("November", temp);
                    }
                    if (i == 11)
                    {
                        calendar[i, j] = random.Next(-35, -15);
                        temp[j] = calendar[i, j];
                        if (j == 29)
                            averageTemperature.Add("December", temp);
                    }
                }
            }

            Dictionary<string, float> result = CalculationOfAverageTemperatures(averageTemperature);

            for (int i = 0; i < 12; i++)
            {
                var mon = result.ElementAt(i);
                string month = mon.Key;
                var temp = result.ElementAt(i);
                float tempr = temp.Value;
                Console.WriteLine($"The average temperature of {month} month is {Math.Round(tempr, 1)};");
            }



            Dictionary<string, float> CalculationOfAverageTemperatures(Dictionary<string, int[]> averageTemperature1)
            {
                Dictionary<string, float> calendarOfAverageTemp = new Dictionary<string, float>();
                float[] averageTemp = new float[12];
                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    var tem = averageTemperature1.ElementAt(i);
                    int[] tempOfMonth = tem.Value;
                    for (int j = 0; j < 30; j++)
                    {
                        sum += tempOfMonth[j];
                        if (j == 29)
                        {
                            averageTemp[i] = sum / 30;
                            var mon = averageTemperature1.ElementAt(i);
                            string month = mon.Key;
                            calendarOfAverageTemp.Add(month, averageTemp[i]);
                        }
                    }
                }
                return calendarOfAverageTemp;
            }
        }
    }
}