using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinmass
{
    internal class Program
    {
        static void Main(string[] args)
        {   //пример 1
            //Использование List<T>; Создание динамического массива
            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            //выход элементов
            Console.WriteLine("Элементы списка");
            foreach (int num in numbers)
            {
                Console.WriteLine(num + " ");
            }
            //доступ по индексу
            Console.WriteLine($"1 элемент {numbers[0]}");
            Console.WriteLine($"3 элемент: {numbers[2]}");
            //кол-во элементов
            Console.WriteLine($"Кол-во элементов: {numbers.Count}");

            //пример 2

        }
    }
}
