using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первое целое число: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Введите второе целое число: ");
                int num2 = int.Parse(Console.ReadLine());

                double result = (double)num1 / num2;
                Console.WriteLine($"Результат деления: {num1} / {num2} = {result:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введено не число.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка! Деление на ноль невозможно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
