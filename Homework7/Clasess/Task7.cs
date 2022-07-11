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
            using (var fileStream = File.OpenRead(path))
            {
                using (var streamReader = new StreamReader(path))
                {
                    CreateAndDeleteFiles(@"C:\Programs\SigmaHomeworks-master\Homework7\output.txt");
                    CreateAndDeleteFiles(@"C:\Programs\SigmaHomeworks-master\Homework7\errorlist.txt");
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        line = FirstLetterToUpper(line);
                        var valuesForCheck = line.Split();

                        if (valuesForCheck.Length == 3
                            && IsCorrectName(line, valuesForCheck)
                            && IsCorrectCaregory(line, valuesForCheck)
                            && IsCorrectWeight(line, valuesForCheck))

                            WriteToFileIOutput(line);

                        else
                            WriteToFileErrorList(line);

                    }

                }
            }
        }


        private void CreateAndDeleteFiles(string path)
        {
            File.Delete(path);
            File.Create(path).Close();
        }

        private void WriteToFileIOutput(string str)
        {

            using (StreamWriter sw = new StreamWriter(@"C:\Programs\SigmaHomeworks-master\Homework7\output.txt",true))
            {
                sw.WriteLine(str);
            }
        }
        private void WriteToFileErrorList(string str)
        {

            using (StreamWriter sw = new StreamWriter(@"C:\Programs\SigmaHomeworks-master\Homework7\errorlist.txt",true))
            {
                sw.WriteLine(($"{str,-35}| => time {DateTime.Now,-20}"));
            }

        }

        private bool IsCorrectName(string str, string[] values)
        {
            return Enum.IsDefined(typeof(Kind), values[0]);
        }

        private bool IsCorrectCaregory(string str, string[] values)
        {
            return Enum.IsDefined(typeof(Category), values[1]);
        }

        private bool IsCorrectWeight(string str, string[] values)
        {
            double a;
            return double.TryParse(values[2], out a);
        }

        private string FirstLetterToUpper(string values)
        {
            return (values != "" ? values[0].ToString().ToUpper() + values[1..] : "empty string");
        }
    }
}
