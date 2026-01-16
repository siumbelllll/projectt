using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, 20, 30, 40, 50 };

            try
            {
                //Попросим пользователя выбрать элемент
                Console.WriteLine("массив содерңит 5 элементов (индексы 0-4).");
                Console.Write("Введите индекс элемента для отображения: ");

                int index = int.Parse(Console.ReadLine());

                //Попытка получитҗ элемент по указанному индексу
                Console.WriteLine($"Элемент с индексом {index}: {numbers[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                //Выход за границы массива
                Console.WriteLine("Ошибка: указан неверный индекс!");
                Console.WriteLine("Индекс  должен быть от 0 до 4.");
            }
            catch (FormatException)
            {
                //Введено не число
                Console.WriteLine("Ошибка: нужно вводить только числа!");
            }

            //Программа продолжает работу
            Console.WriteLine("\nВыводим весь массив: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"numbers[{i}] = {numbers[i]}");
            }
        }
    }
}
