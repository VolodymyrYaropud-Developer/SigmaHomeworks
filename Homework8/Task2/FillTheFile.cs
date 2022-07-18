using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Task2
{
    internal static class FillTheFile
    {
        private static string path = @"C:\Programs\SigmaHomeworks-master\Homework8\Task2\UsersView.txt";

        public static void FillFile()
        {
            DelateAndCreateFile(path);
            using (var strWritter = new StreamWriter(path, true))
            {
                try
                {
                    Console.WriteLine("please enter amount of users");
                    int.TryParse(Console.ReadLine(), out int amountOfUsers);
                    for (int i = 0; i < amountOfUsers; i++)
                    {
                        User user = new User(CreateRandIp(), GetRandomDate(new DateTime(2022, 8, 11), new DateTime(2022, 8, 17)));
                        strWritter.WriteLine(user.ToString());
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("not correct value");
                }
            }
        }

        private static void DelateAndCreateFile(string path)
        {
            File.Delete(path);
            File.Create(path).Close();
        }

        private static string CreateRandIp()
        {
            return (new Random()).Next(0, 256).ToString() + "."
                + (new Random()).Next(0, 256).ToString() + "."
                + (new Random()).Next(0, 256).ToString() + "."
                + (new Random()).Next(0, 256).ToString();
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)((new Random()).NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }

    }
}
