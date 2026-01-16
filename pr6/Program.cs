using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                bool validInput = false;

                while (!validInput)
                {
                    try
                    {
                        Console.Write($"Введите элемент [{i}]: ");
                        array[i] = int.Parse(Console.ReadLine());
                        validInput = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка! Введено не число. Повторите ввод.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
                    }
                }
            }
            Console.WriteLine("Массив:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

        }
    }
}
