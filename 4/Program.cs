using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ввведите возраст: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 0)
                {
                    throw new Exception();
                }
                Console.WriteLine("Возраст принят: " + age);
            }
            catch
            {
                Console.WriteLine("Ошибка! Возраст не может быть отрицательным.");
            }
        }
    }
}
