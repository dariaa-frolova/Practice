using System;
using System.IO;

namespace exe2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string way = "D:/учеба/УЧЕБНАЯ ПРАКТИКА/учебная практика 1.6/exe2/numsTask2.txt";
            using (StreamReader input = new StreamReader(way))
            {    
                string wordsInLine = input.ReadToEnd();
                input.Close();
                
                string[] words = wordsInLine.Split("\r\n");

                for (int i = 0; i < words.Length; i++)        
                    Console.Write(words[i] + " ");
            }
        }
    }
}