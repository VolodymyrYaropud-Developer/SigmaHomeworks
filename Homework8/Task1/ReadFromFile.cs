using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework8.Task1
{
    internal class ReadFromFile
    {
        private string pathForWrite = @"C:\Programs\SigmaHomeworks-master\Homework8\Task1\Information.txt";
        private string pathForRead = @"C:\Programs\SigmaHomeworks-master\Homework8\Task1\InformationForView.txt";
        private List<User> users = new List<User>();
        private User user = new User();

        public void ReadLineByLine()
        {
            using (var streaReader = new StreamReader(pathForWrite))
            {
                DeleteAndCreateFile(pathForRead);
                string line = "";
                int count = 0;
                line = streaReader.ReadLine();
                Display(line.Replace("Номер квартир: ", "Кількість квартир ").Replace("| Номер кварталу:", "Квартал ").Trim().TrimStart());

                while ((line = streaReader.ReadLine()) != null)
                {
                    var temp = line.Remove(0, line.IndexOf(":") + 2);
                    count++;
                    count = InCase(line, count, temp);
                }

            }
        }

        private int InCase(string line, int count, string temp)
        {
            switch (count)
            {
                case 1:
                    user.NumberOfFlat = Convert.ToInt16(temp);
                    break;

                case 2:
                    user.Name = line.Remove(0, line.IndexOf(":") + 1); ;
                    break;

                case 4:
                    user.DateOfFirstMounth = line.Remove(0, line.IndexOf(":") + 1);
                    break;

                case 5:
                    user.ResultOfFirstMounth = double.Parse(line.Remove(0, line.IndexOf(":") + 1));
                    break;

                case 6:
                    user.DateOfSecond = line.Remove(0, line.IndexOf(":") + 1);
                    break;

                case 7:
                    user.ResultOfSecondMounth = double.Parse(line.Remove(0, line.IndexOf(":") + 1));
                    break;

                case 8:
                    user.DateOfThirdMounth = line.Remove(0, line.IndexOf(":") + 1); ;
                    break;
                case 9:
                    user.ResultOfThitdMounth = double.Parse(line.Remove(0, line.IndexOf(":") + 1));
                    users.Add(new User(user.NumberOfFlat, user.Name, user.ResultOfFirstMounth, user.ResultOfSecondMounth, user.ResultOfThitdMounth, user.DateOfFirstMounth, user.DateOfSecond, user.DateOfThirdMounth));
                    Display(user);
                    count = 0;
                    break;
                default:
                    break;
            }

            return count;
        }

        public static List<User> operator +(List<User> first, ReadFromFile second)
        {

            foreach (var item in second.users)
            {
                first += item;
            }
            return first;
        }

        public static List<User> operator - (List<User> first, ReadFromFile second)
        {
            foreach (var item in second.users)
            {
                first -= item;
            }
            return first - second;
        }

        private void Display(string line)
        {
            using (var writter = new StreamWriter(pathForRead, true))
            {
                writter.WriteLine(line);
                writter.WriteLine("=========================================================================================================================================================");
            }
        }

        private void Display(User us)
        {
            using (var writter = new StreamWriter(pathForRead, true))
            {
                writter.WriteLine(us.ToString());
            }
        }

        private void DeleteAndCreateFile(string path)
        {
            File.Delete(path);
            File.Create(path).Close();
        }

    }
}