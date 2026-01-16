using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
           
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"Вы ввели число: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введено не число");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
