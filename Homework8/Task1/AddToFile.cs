using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework8.Task1
{

    internal static class AddToFile
    {
        static Random rand = new Random();
        static string path = @"C:\Programs\SigmaHomeworks-master\Homework8\Task1\Information.txt";
        public static void PrintToFile()
        {

            if (File.Exists(path))
            {
                if (File.ReadAllText(path).Length == 0)
                    SomeInformation();
                else
                {
                    File.Delete(path);
                    SomeInformation();
                }
            }
            else
            {
                File.Create(path).Close();
                File.Delete(path);
                SomeInformation();
            }

        }
        private static (int, int) InputValues()
        {
            int Flats, quarter;

            Console.WriteLine("input count of flats");
            int.TryParse(Console.ReadLine(), out Flats);
            do
            {

                Console.WriteLine("input quarter");
                int.TryParse(Console.ReadLine(), out quarter);
            }
            while (quarter > 4 || quarter < 1);
            return (Flats, quarter);
        }
        private static string Names()
        {
            Random rand = new Random();
            var Names = new string[] { "Аврора", "Аїда", "Альбіна", "Анжела", "Анжеліка", "Богдана", "Дарія", "Андрій", "Артур", "Борис", "Василь", "Броніслав", "Гліб", "Дмитро", "Дмитро", "Леонід", "Людомир" };
            var lastNames = new string[] { "Мельник", "Мельник", "Коваленко", "Бондаренко", "Бойко", "Кравченко", "	Олійник" };

            return Names[rand.Next(Names.Length - 1)] + " " + lastNames[rand.Next(lastNames.Length - 1)];
        }
        private static void SomeInformation()
        {
            (int Flats, int quarter) = InputValues();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"\t\t\t\t Номер квартир: {Flats} | Номер кварталу: {quarter}");
                for (int i = 1; i <= Flats; i++)
                {
                    sw.WriteLine($"номер квартири: {i}");
                    sw.WriteLine($"ПІБ: {Names()}");
                    sw.WriteLine($"Вхідний показ: {rand.Next(100)}");
                    PrintQuarter(quarter, sw);

                }
            }
        }

        private static void PrintQuarter(int quarter, StreamWriter sw)
        {
            switch (quarter)
            {
                case 1:
                    for (int q = 0; q < 3; q++)
                    {
                        sw.WriteLine($"Дата знімання показу: {DateTime.Now.Year}.{Enum.GetName(typeof(Mounth), q)}.{rand.Next(1, 6)}");
                        sw.WriteLine($"Вихідний показ: {rand.Next(1000, 1000 * (q + 3))}");
                    }
                    break;
                case 2:
                    for (int q = 3; q < 6; q++)
                    {
                        sw.WriteLine($"Дата знімання показу:{DateTime.Now.Year}. {Enum.GetName(typeof(Mounth), q)}.{rand.Next(1, 6)}");
                        sw.WriteLine($"Вихідний показ: {rand.Next(1000, 1000 * (q + 3))}");
                    }
                    break;
                case 3:
                    for (int q = 6; q < 9; q++)
                    {
                        sw.WriteLine($"Дата знімання показу:{DateTime.Now.Year}. {Enum.GetName(typeof(Mounth), q)}.{rand.Next(1, 6)}");
                        sw.WriteLine($"Вихідний показ: {rand.Next(1000, 1000 * (q + 3))}");
                    }
                    break;
                case 4:
                    for (int q = 9; q < 12; q++)
                    {
                        sw.WriteLine($"Дата знімання показу:{DateTime.Now.Year}. {Enum.GetName(typeof(Mounth), q)}.{rand.Next(1, 6)}");
                        sw.WriteLine($"Вихідний показ: {rand.Next(1000, 1000 * (q + 3))}");
                    }
                    break;
                default:
                    sw.WriteLine("#########ERORR#########");
                    break;
            }
        }
    }
}