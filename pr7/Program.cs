using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размер массивов: ");
                int size = int.Parse(Console.ReadLine());

                if (size <= 0)
                    throw new ArgumentException("Размер массива должен быть положительным числом.");

                double[] array1 = new double[size];
                double[] array2 = new double[size];
                double[] resultArray = new double[size];

                Console.WriteLine("Введите элементы первого массива:");
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Элемент [{i}]: ");
                    array1[i] = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("Введите элементы второго массива:");
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Элемент [{i}]: ");
                    array2[i] = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("Результат деления элементов первого массива на второй:");
                for (int i = 0; i < size; i++)
                {
                    if (array2[i] == 0)
                        throw new DivideByZeroException($"Деление на ноль в элементе [{i}]");

                    resultArray[i] = array1[i] / array2[i];
                    Console.WriteLine($"[{i}]: {array1[i]} / {array2[i]} = {resultArray[i]:F2}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введено не число.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
