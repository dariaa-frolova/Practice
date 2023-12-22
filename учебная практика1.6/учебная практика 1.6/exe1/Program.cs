using System;
using System.IO;

namespace exe1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.6/exe1/numsTask1.txt";
            using (StreamReader input = new StreamReader(way))
            {    
                string wordsInLine = input.ReadToEnd();
                input.Close();   
                
                string[] words = wordsInLine.Split(' ');    
                for (int i = 0; i < words.Length; i++)       
                    if (words[i].Length % 2 != 0)
                        Console.Write(words[i] + " ");
                
            }
        }
    }
}