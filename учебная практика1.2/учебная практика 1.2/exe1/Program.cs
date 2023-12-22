using System;

namespace учебная_практика_1._2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[100];

            arr[99] = 102;
            for (int i = 98; i > -1; i--)
            {
                arr[i] = arr[i + 1] - 3;
                Console.Write(arr[i] + " ");
            }
        }
    }
}