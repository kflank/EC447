using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Program
    {

        static void Main()
        {
            Fibonacci();
        }

        public static void Fibonacci()
        {
            int first = 1;
            int second = 1;
            int term;
            Console.WriteLine("Kfir Flank");

            for (int i = 0; i < 20; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(1);
                }
                else if (i == 1)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    term = first + second;
                    first = second;
                    second = term;
                    Console.WriteLine(term);
                }
            }
        }
    }
}
