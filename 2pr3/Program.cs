using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2pr3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string fileName = "C:\\Users\\Пользователь\\Desktop\\Cписок_покупок.txt";
            Console.WriteLine("СПИСОК ПОКУПОК");

            if (!File.Exists(fileName))
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    //создаем пустой файл
                }
                Console.WriteLine("Создан новый список покупок на рабочем столе.");
            }

            while (true)
            {
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Показать список покупок");
                Console.WriteLine("2. Добавить покупку");
                Console.WriteLine("3. Отметить покупку выполненной");
                Console.WriteLine("4. Очистить список");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // 1. Показать список покупок
                    Console.WriteLine("ВАШ СПИСОК ПОКУПОК");

                    // Проверяем, есть ли записи в файле
                    bool fileIsEmpty = true;
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string firstLine = reader.ReadLine();
                        fileIsEmpty = string.IsNullOrWhiteSpace(firstLine);
                    }

                    if (fileIsEmpty)
                    {
                        Console.WriteLine("Список покупок пуст.");
                    }
                    else
                    {
                        // Читаем и отображаем список покупок
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            int itemNumber = 1;
                            string line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine($"{itemNumber}. {line}");
                                itemNumber++;
                            }
                        }
                    }
                }
                else if (choice == "2")
                {
                    // 2. Добавить покупку
                    Console.Write("Введите название покупки: ");
                    string itemName = Console.ReadLine();

                    // Добавляем покупку в файл
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                         writer.WriteLine($"[ ] {itemName.Trim()}");
                    }
                    Console.WriteLine($"Добавлено: {itemName}");
                    
                }
                else if (choice == "3")
                {
                    // 3. Отметить покупку выполненной

                    // Проверяем, есть ли что-то в файле
                    bool fileIsEmpty = true;
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string firstLine = reader.ReadLine();
                        fileIsEmpty = string.IsNullOrWhiteSpace(firstLine);
                    }

                    if (fileIsEmpty)
                    {
                        Console.WriteLine("Список покупок пуст.");
                    }
                    else
                    {
                        // Сначала читаем весь список
                        List<string> items = new List<string>();

                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                items.Add(line);
                            }
                        }

                        
                        Console.WriteLine("Выберите покупку для отметки");
                        for (int i = 0; i < items.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {items[i]}");
                        }

                        // Запрашиваем номер покупки
                        Console.Write("Введите номер покупки: ");
                        string input = Console.ReadLine();
                        int itemNumber;

                        if (!int.TryParse(input, out itemNumber) || itemNumber < 1 || itemNumber > items.Count)
                        {
                            Console.WriteLine("Неверный номер покупки!");
                        }
                        else
                        {
                                // Меняем статус покупки
                                string selectedItem = items[itemNumber - 1];
                            
                                items[itemNumber - 1] = selectedItem.Replace("[ ]", "[X]");

                                // Перезаписываем весь файл с обновленным статусом
                                using (StreamWriter writer = new StreamWriter(fileName, false))
                                {
                                    foreach (string item in items)
                                    {
                                        writer.WriteLine(item);
                                    }
                                }

                                // Извлекаем название покупки для сообщения
                                string purchaseName = selectedItem.Substring(4);
                                Console.WriteLine($"Покупка {purchaseName} отмечена как выполненная!");
                            
                        }
                    }
                }
                else if (choice == "4")
                {
                      // Создаем пустой файл (перезаписываем существующий)
                        using (StreamWriter writer = new StreamWriter(fileName, false))
                        {
                            // Пустой файл
                        }
                        Console.WriteLine("Список покупок очищен.");
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Выход");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                }
            }
         }
    }
}
