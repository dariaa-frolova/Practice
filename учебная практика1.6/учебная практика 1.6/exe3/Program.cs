using System;

namespace exe3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number = ");
            int num = Convert.ToInt32(Console.ReadLine());
            
            if (num % 2 == 0 && num % 10 == 0)
                Console.WriteLine("The number is even and a multiple of 10");
            else
                Console.WriteLine("The number is odd and non-multiple 10");
        }
    }
}