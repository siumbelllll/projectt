using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n <= 100)
                    throw new ArgumentException("Размер массива должен быть не больше 100.");
                
                int[,] matrix = new int[n, n];


                
        }
    }
}
