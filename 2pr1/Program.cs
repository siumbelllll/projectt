using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2pr1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Моя_биография.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("- Нас зовут Ильзиля и Сюмбель");
                writer.WriteLine("- Нам 18 лет");
                writer.WriteLine("- Мы учимся программированию");
                writer.WriteLine("- Наше хобби - спать");
                writer.WriteLine("- Мы мечтаем стать программистами");

                Console.WriteLine("Данные успешно записаны.");

            }
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден");
                return; 
            }
            
            
            string[] lines = File.ReadAllLines("Моя_биография.txt");

            Console.WriteLine("Содержимое файла:");

            for (int i = 0; i < lines.Length; i++)
            {
                
                if (lines[i].StartsWith("- "))
                {
                    string Marker = lines[i].Substring(2); 
                    Console.WriteLine($"{i + 1}. {Marker}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {lines[i]}");
                }
                
            }
            Console.WriteLine($"Всего строк в файле: {lines.Length}");
        }
    }
}
