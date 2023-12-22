using System;


namespace exe2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[20];
            int meaning = 1;
            for (int i = 1; i < 20; i++)
            {
                arr[i] = meaning;
                meaning += 2;
                Console.Write(arr[i] + " ");
            }

        }
    }
}