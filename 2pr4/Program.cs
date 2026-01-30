using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2pr4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string file1 = "C:\\Users\\Пользователь\\Desktop\\исходный.txt";
            string file2 = "C:\\Users\\Пользователь\\Desktop\\обработанный.txt";

            Console.WriteLine("ОБРАБОТКА ТЕКСТОВОГО ФАЙЛА");

            // 1. Проверяем и создаем исходный файл если его нет
            if (!File.Exists(file1))
            {
                Console.WriteLine("Исходный файл не найден. Создаю новый файл с примером текста...");

                using (StreamWriter writer = new StreamWriter(file1, false))
                {
                    writer.WriteLine("привет");
                    writer.WriteLine("как дела?");
                    writer.WriteLine("");
                    writer.WriteLine("хорошо");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("это пример текста");
                    writer.WriteLine("");
                    writer.WriteLine("последняя строка");
                }

                Console.WriteLine("Файл создан на рабочем столе.");
            }

            // 2. Читаем исходный файл и подсчитываем строки
            int ishod = 0;

            using (StreamReader reader = new StreamReader(file1))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ishod++;
                }
            }

            Console.WriteLine($"В исходном файле: {ishod} строк");

            // 3. Обрабатываем текст и записываем в новый файл
            int newF = 0;

            using (StreamReader reader = new StreamReader(file1))
            using (StreamWriter writer = new StreamWriter(file2, false))
            {
                string line;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    // Проверяем, что строка не пустая
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                       
                        string newLine = line.ToUpper();

                        // Форматируем номер строки c нуля
                        string numberedLine = $"{lineNumber:D2}. {newLine}";

                        // Записываем в новый файл
                        writer.WriteLine(numberedLine);

                        newF++;
                        lineNumber++;
                    }
                }
            }

            Console.WriteLine($"После обработки: {newF} строк");
            Console.WriteLine($"Результат сохранен в новый файл");

            // 4. Показываем первые 3 строки из обработанного файла
            if (File.Exists(file2) && newF > 0)
            {
                Console.WriteLine("Первые 3 строки обработанного файла:");

                int liness = 0;

                using (StreamReader reader = new StreamReader(file2))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null && liness < 3)
                    {
                        Console.WriteLine(line);
                        liness++;

                        if (liness >= 3)
                        {
                            break;
                        }
                    }
                }

                // Если в файле меньше 3 строк
                if (liness < 3)
                {
                    Console.WriteLine($"В обработанном файле всего {liness} строк");
                }
            }
            else
            {
                Console.WriteLine("Обработанный файл пуст или не создан.");
            }

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
