using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework7.Clasess
{
    internal partial class Storage
    {

        public string GetPath()
        {
            Console.WriteLine("please enter full path to file");
            var path = Console.ReadLine();
            for (int i = 1; i < 3; i++)
            {
                if (File.Exists(path))
                {
                    ReadFromFile(path);
                    break;
                }
                else
                {
                    Console.WriteLine($"wrong path. please try again {i}/3");
                    path = Console.ReadLine();
                }

            }
            return path;
        }

        private void ReadFromFile(string path)
        {

            using (var streamReader = new StreamReader(path))
            {
                CreateAndDeleteFiles(@"C:\Programs\SigmaHomeworks-master\Homework7\output.txt");
                CreateAndDeleteFiles(@"C:\Programs\SigmaHomeworks-master\Homework7\errorlist.txt");
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = FirstLetterToUpper(line);

                    if (line.Split().Length == 3 && CheckAllValues(line.Split()))

                        WriteToFile(line, @"C:\Programs\SigmaHomeworks-master\Homework7\output.txt");

                    else
                        WriteToFile(line, @"C:\Programs\SigmaHomeworks-master\Homework7\errorlist.txt");

                }

            }

        }


        private void CreateAndDeleteFiles(string path)
        {
            File.Delete(path);
            File.Create(path).Close();
        }
        private void WriteToFile(string str, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(($"{str,-35}| => time {DateTime.Now,-20}"));
            }
        }

        private bool CheckAllValues(string[] values)
        {
            return IsCorrectName(values) && IsCorrectCaregory(values) && IsCorrectWeight(values);
        }

        private bool IsCorrectName(string[] values)
        {
            return Enum.IsDefined(typeof(Kind), values[0]);
        }

        private bool IsCorrectCaregory(string[] values)
        {
            return Enum.IsDefined(typeof(Category), values[1]);
        }

        private bool IsCorrectWeight(string[] values)
        {
            double a;
            return double.TryParse(values[2], out a);
        }

        private string FirstLetterToUpper(string values)
        {
            return (values != "" ? values[0].ToString().ToUpper() + values[1..] : "empty string");
        }

        public void ChangeErrorList()
        {
            Console.WriteLine("If you want to change information in error list please tab +");
            if (Console.ReadLine() == "+")
            {
                PrintErrorList();
            }
            else
            {
                Console.WriteLine("Not \" + \" ");
            }
        }

        private void PrintErrorList()
        {
            using (StreamReader sr = new StreamReader(@"C:\Programs\SigmaHomeworks-master\Homework7\errorlist.txt"))
            {
                int count = 1;
                string information;
                while ((information = sr.ReadLine()) != null)
                    Console.WriteLine($"{count++}  | {information}");
                ChoiseUser(count);
                sr.Close();
            }

        }
        private void ChoiseUser(int count)
        {
            Console.WriteLine("what string you want to change");
            try
            {
                InTry(count);

            }
            catch (Exception)
            {
                IfCatch(count);
            }
        }

        private void InTry(int count)
        {
            int.TryParse(Console.ReadLine(), out int NumOfString);
            if (NumOfString < count && NumOfString > 0)
            {
                Console.WriteLine("Please write a new string");
                string? line = Console.ReadLine();
                if (line?.Split().Length == 3 && CheckAllValues(line.Split()))
                {
                    WriteToFile(line, @"C:\Programs\SigmaHomeworks-master\Homework7\output.txt");
                    EditErrorlist(NumOfString);
                }
                else
                    Console.WriteLine("not a correect string");
                Console.ReadKey();
            }
        }

        private void IfCatch(int count)
        {
            Console.WriteLine("if you want to exit please tab +");
            if (Console.ReadLine() == "+")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("okey. Try Again");
                ChoiseUser(count);
            }
        }
        private void EditErrorlist(int numberOfString)
        {
            AddToTempFile(numberOfString);
        }

        private void AddToTempFile(int numberOfString)
        {
            using (var reader = new StreamReader(@"C:\Programs\SigmaHomeworks-master\Homework7\errorlist.txt"))
            {
                int count = 0;
                string? line;
                CreateAndDeleteFiles(@"C:\Programs\SigmaHomeworks-master\Homework7\tempFile.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    if (count != numberOfString)
                    {
                        WriteToFile(line, @"C:\Programs\SigmaHomeworks-master\Homework7\tempFile.txt");
                    }
                }
                reader.Close();
            }
        }
    }
}
