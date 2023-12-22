using System;

namespace exe5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the quantity of lines: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter the quantity of columns: ");
            int m = Convert.ToInt32(Console.ReadLine());
            
            int[,] a = new int[n, m + 1];Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int counter = 0; 
                for (int j = 0; j < m + 1; j++)
                {        
                    if (j != m)
                    {           
                        a[i, j] = random.Next(0, 2);
                        if (a[i, j] == 1)                
                            counter++;
                    }   
                    else
                    {           
                        if (counter % 2 != 0)
                            a[i, j] = 1;           
                        else
                            a[i, j] = 0;        
                    }
                    Console.Write(a[i,j] + " ");    
                }
                Console.WriteLine();
            }
        }
    }
}