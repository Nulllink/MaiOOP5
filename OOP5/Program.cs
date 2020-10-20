using System;
using System.IO;


namespace OOP5
{
    class Program
    {
        static string path = "output.txt";
        static StreamWriter csw = new StreamWriter("document.txt");
        static void Main(string[] args)
        {
            int[] numbers = new int[100]; // Создание массива
            
            doublewrite("Введите количество элементов массива: ");
            string text = Console.ReadLine();
            int n;
            if (int.TryParse(text, out n))
            {
                //int n = int.Parse(Console.ReadLine()); //Чтение и перевод в число
                if (n <= 100 && n > 0) // Если н меньше 100 и н больше нуля
                {
                    Random r = new Random(); // Создание объекта класса Random
                    for (int i = 0; i < n; i++) // Цикл для прохода массива
                    {
                        numbers[i] = r.Next(-50, 50); // Заполнение случайными числами
                    }
                    vivod(n, numbers);
                    consolevivod();
                }
                else // Вывод если указано неверное количество элементов
                {
                    doublewrite("Указано неверное количество элементов массива");
                }
            }
            else
            {
                doublewrite("Введено не число");
            }
            csw.Close();
            Console.ReadKey(); // Что бы не закрывалась консоль
        }

        static void doublewrite(string text)
        {
            Console.WriteLine(text);
            csw.WriteLine(text);
        }

        static void vivod(int n, int[] numbers)
        {
            if (File.Exists(path)) //проверка существования файла
            {
                doublewrite("Файл output.txt существует, данные будут записанны в output1.txt");
                path = "output1.txt";
            }
            StreamWriter sw = new StreamWriter(path); // Запись в файл
            for (int i = 0; i < n; i++) // Проход по массиву
            {
                sw.WriteLine(numbers[i]); // Вывод в файл элемента массива
            }
            sw.Close(); //Закрытия потока записи
            if (File.Exists(path))
            {
                doublewrite("Файл успешно записан");
            }
            else
            {
                doublewrite("Файл не был записан");
            }
        }

        static void consolevivod()
        {
            // Вывод в консоль
            StreamReader sr = new StreamReader(path);// Создание потока чтения
            string text; //значение из файла
            int sum = 0; // сумма значений из файла
            while ((text = sr.ReadLine()) != null) //Проход файла с 1 до последней строчки
            {
                sum += int.Parse(text); //Сумма элементов
                doublewrite(text); // Вывод в консоль
            }
            doublewrite("Сумма равна " + sum); // Вывод в консоль
            sr.Close(); // Закрытие потока чтения
        }
    }
}
