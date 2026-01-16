using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размер массива: ");
                int size = int.Parse(Console.ReadLine());

                if (size <= 0)
                    throw new ArgumentException("Размер массива должен быть положительным числом.");

                int[] array = new int[size];
                int sum = 0;

                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Введите элемент [{i}]: ");
                    array[i] = int.Parse(Console.ReadLine());
                    sum += array[i];
                }

                Console.WriteLine($"Сумма всех элементов массива: {sum}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введено не число.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
