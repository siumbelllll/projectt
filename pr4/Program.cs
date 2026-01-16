using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };

            try
            {
                Console.Write("Введите индекс элемента (0-4): ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine($"Элемент с индексом {index}: {array[index]}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введено не число.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ошибка! Выход за границы массива.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
