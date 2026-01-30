using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tema2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Текстовый 223.txt";

            //Проверяем сущ-ет ли файл
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден");
                return; //выход из программы
            }
            Console.WriteLine("Способ 1: ");
            //Способ1: чтение всего файла целиком
            using (StreamReader reader = new StreamReader(fileName))
            {
                string allText = reader.ReadToEnd();//читаем весь файл целиком
                Console.WriteLine(allText);
            }

            Console.WriteLine("Способ 2: ");
            //Способ2: чтение файла построчно
            using(StreamReader reader = new StreamReader(fileName))
            {
                int lines = 1;
                string line;

                //Читаем строку за строкой, пока не достигнем конца файла
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Строка {lines}: {line}");
                    lines++;
                }
            }
            //Способ 3: чтение посимвольно
            using (StreamReader reader = new StreamReader(fileName))
            {
                Console.WriteLine("Первые 20 символов");
                for (int i = 1; i <= 20; i++)
                {
                    int charCode = reader.Read();
                    if (charCode == 0)//конец файла
                        break;

                    char symbol = (char)charCode;
                    Console.WriteLine(symbol);
                }

                Console.WriteLine();
            }
        }
    }
}
