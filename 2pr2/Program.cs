using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2pr2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ДНЕВНИК НАСТРОЕНИЙ");
            string fileName = "C:\\Users\\Пользователь\\Desktop\\Документы\\Дневник\\Дневник_настроений.txt";
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {

                // Ввод и проверка настроения
                int mood;
                while (true)
                {
                    Console.Write("Оцените свое настроение (1-5): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out mood) && mood >= 1 && mood <= 5)
                        break;
                    Console.WriteLine("Ошибка! Введите число от 1 до 5.");
                }

                // Ввод комментария
                string comment;
                do
                {
                    Console.Write("Введите комментарий: ");
                    comment = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(comment))
                        Console.WriteLine("Комментарий не может быть пустым!");
                } while (string.IsNullOrWhiteSpace(comment));

                // Формирование записи
                string entry = $"[{DateTime.Now:dd.MM.yyyy}] Настроение: {mood}/5 - {comment}";

                Console.WriteLine("\nЗапись добавлена!");
                writer.WriteLine(entry);
            }
            if (File.Exists(fileName))
            {
                Console.WriteLine("Последние 3 записи:");

                using (StreamReader reader = new StreamReader(fileName))
                {
                    // Читаем все строки 
                    List<string> allLines = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        allLines.Add(line);
                    }

                    // Показываем макс 3 последние записи
                    int start = Math.Max(0, allLines.Count - 3);
                    int number = 1;

                    for (int i = start; i < allLines.Count; i++)
                    {
                        Console.WriteLine($"{number}. {allLines[i]}");
                        number++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Записей пока нет.");
            }

        }
    }
 }
