using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//создание и запись в файл

namespace tema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //указываем имя файла.Создается в одной папке с программой
            string fileName = "Приветствие.txt";

            //используем конструкцию using, которая автоматически закрывает поток
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                //записываем первую строку
                writer.WriteLine("Привет! Это мой первый файл в Си шарп");
                //Записываем вторую строку
                writer.WriteLine($"Дата создания файла: {DateTime.Now}");
                //Записываем третью строку без перехода на новую строку
                writer.Write("Этот текст ");
                writer.Write("будет записан на одной строке ");

                Console.WriteLine("Данные успешно записаны.");

            }
            //после выхода из блока юсинг поток автоматический закрывается
            //все данные гарантированно записаны на диск

            Console.WriteLine("Добавляем данные в конец файла");
            //Второй параметр true дает возможность дополнить текстовый файл 
            //по умолчанию передается false, в таком случае файл перезаписычается
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine("\n=== Новая запись ===");
                writer.WriteLine($"Дата: {DateTime.Now}");
                writer.WriteLine("Сегодня"

            }

        }
    }
}
