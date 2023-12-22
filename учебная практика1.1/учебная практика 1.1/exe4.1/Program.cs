using System;

namespace exe3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the beginning of the range: ");
            int begin = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter the end of the range: ");
            int end = Convert.ToInt32(Console.ReadLine());

            int[] nums = FillingTheArray(begin, end);

            Console.WriteLine("Array:");
            foreach (int num in nums)
                Console.Write(num + " ");

            Console.ReadLine();
            
            int[] FillingTheArray(int begin1, int end1)
            {
                int[] nums1 = new int [10];
                Random random = new Random();
                
                for (int i = 0; i < nums1.Length; i++)
                    nums1[i] = random.Next(begin1, end1);
                
                return nums1;
            }
        }
    }
}