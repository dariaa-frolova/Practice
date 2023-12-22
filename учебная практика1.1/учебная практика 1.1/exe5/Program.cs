using System;

namespace exe5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentence:");
            string sentence = Console.ReadLine();

            int quantity = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ' && sentence[i - 1] != ' ')
                    quantity++;
                if (i == sentence.Length - 1)
                    if (sentence[i] != ' ')
                        quantity++;
            }

            Console.WriteLine($"The quantity of words: {quantity}");
            Console.WriteLine($"Start {sentence} End");
        }
    }
}