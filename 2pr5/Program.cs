using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2pr5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Пользователь\\Desktop\\Документы\\учебные_предметы.txt";

            // Создаем файл если его нет
            if (!File.Exists(fileName))
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.WriteLine("Математика=4");
                    writer.WriteLine("Физика=5");
                    writer.WriteLine("Информатика=5");
                    writer.WriteLine("Химия=3");
                }
            }

            Console.WriteLine("УЧЕТ УЧЕБНЫХ ПРЕДМЕТОВ");

            while (true)
            {
                Console.WriteLine("1. Показать все 2. Добавить 3. Изменить оценку 4. Удалить 5. Статистика 6. Выход");
                Console.Write("Выбор: ");
                string choice = Console.ReadLine();

                if (choice == "1") // Показать все
                { 

                    Console.WriteLine("ПРЕДМЕТЫ");
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        int i = 1;
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            if (!string.IsNullOrWhiteSpace(line))
                                Console.WriteLine($"{i++}. {line}");
                    }
                }
                else if (choice == "2") // Добавить
                {
                    Console.Write("Предмет: ");
                    string subject = Console.ReadLine()?.Trim();

                    // Проверка существования
                    bool exists = false;
                    if (File.Exists(fileName))
                    {
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Split('=')[0].Trim().ToLower() == subject.ToLower())
                                {
                                    exists = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (exists)
                    {
                        Console.WriteLine("Предмет уже есть");
                    }
                    else
                    {
                        Console.Write("Оценка (1-5): ");
                        if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 1 && grade <= 5)
                        {
                            using (StreamWriter writer = new StreamWriter(fileName, true))
                                writer.WriteLine($"{subject}={grade}");
                            Console.WriteLine("Добавлено");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: оценка 1-5");
                        }
                    }
                }
                else if (choice == "3") // Изменить
                {
                    
                    Console.Write("Предмет для изменения: ");
                    string subject = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(subject))
                    {
                        Console.WriteLine("Ошибка");
                        continue;
                    }

                    List<string> lines = new List<string>();
                    bool changed = false;

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length == 2 && parts[0].Trim().ToLower() == subject.ToLower())
                            {
                                Console.Write($"Новая оценка для {parts[0].Trim()}: ");
                                if (int.TryParse(Console.ReadLine(), out int newGrade) && newGrade >= 1 && newGrade <= 5)
                                {
                                    lines.Add($"{parts[0].Trim()}={newGrade}");
                                    changed = true;
                                }
                                else
                                {
                                    lines.Add(line);
                                    Console.WriteLine("Ошибка: оценка 1-5");
                                }
                            }
                            else
                            {
                                lines.Add(line);
                            }
                        }
                    }

                    if (changed)
                    {
                        using (StreamWriter writer = new StreamWriter(fileName, false))
                            foreach (string l in lines) writer.WriteLine(l);
                        Console.WriteLine("Изменено");
                    }
                    else
                    {
                        Console.WriteLine("Предмет не найден");
                    }
                }
                else if (choice == "4") // Удалить
                {

                    Console.Write("Предмет для удаления: ");
                    string subject = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(subject))
                    {
                        Console.WriteLine("Ошибка");
                        continue;
                    }

                    List<string> lines = new List<string>();
                    bool deleted = false;

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length == 2 && parts[0].Trim().ToLower() == subject.ToLower())
                            {
                                deleted = true;
                            }
                            else
                            {
                                lines.Add(line);
                            }
                        }
                    }

                    if (deleted)
                    {
                        using (StreamWriter writer = new StreamWriter(fileName, false))
                            foreach (string l in lines) writer.WriteLine(l);
                        Console.WriteLine("Удалено");
                    }
                    else
                    {
                        Console.WriteLine("Предмет не найден");
                    }
                }
                else if (choice == "5") // Статистика
                {
                    if (!File.Exists(fileName) || new FileInfo(fileName).Length == 0)
                    {
                        Console.WriteLine("Файл пуст");
                        continue;
                    }

                    int count = 0;
                    int sum = 0;
                    string best = "";
                    int bestGrade = 0;
                    string worst = "";
                    int worstGrade = 6;

                    using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int grade))
                            {
                                count++;
                                sum += grade;

                                if (grade > bestGrade)
                                {
                                    bestGrade = grade;
                                    best = parts[0].Trim();
                                }

                                if (grade < worstGrade)
                                {
                                    worstGrade = grade;
                                    worst = parts[0].Trim();
                                }
                            }
                        }
                    }

                    if (count > 0)
                    {
                        double avg = (double)sum / count;
                        Console.WriteLine($"\nПредметов: {count}");
                        Console.WriteLine($"Средний балл: {avg:F2}");
                        if (bestGrade > 0) Console.WriteLine($"Лучший: {best} ({bestGrade})");
                        if (worstGrade < 6) Console.WriteLine($"Худший: {worst} ({worstGrade})");
                    }
                }
                else if (choice == "6") // Выход
                {
                    Console.WriteLine("Выход");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор");
                }
            }
        }
    }
}
