using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stopWord = Console.ReadLine();
            while (stopWord != "s")
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    int a = int.Parse(Console.ReadLine());

                    Console.Write("Введите второе число: ");
                    int b = int.Parse(Console.ReadLine());

                    // Попытка выполнить деление
                    int result = a / b;
                    Console.WriteLine($"Результат: {result}");
                }
                catch (DivideByZeroException)
                {
                    // Этот блок выполнится ТОЛЬКО если произошло деление на ноль
                    Console.WriteLine("Ошибка: деление на ноль невозможно!");
                }
                catch (FormatException)
                {
                    // Этот блок выполнится ТОЛЬКО если введено не число
                    Console.WriteLine("Ошибка: нужно вводить только числа!");
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
                }

                Console.WriteLine("Программа продолжает работу...");
                stopWord = Console.ReadLine();
            }
        }
    }
}
