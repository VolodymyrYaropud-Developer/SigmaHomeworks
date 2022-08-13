using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Types;
using ConsoleApp1.WorkWithFiles;

namespace ConsoleApp1
{
    internal class Vocablary
    {
        public Dictionary<string, string> VocablaryForClass { get; set; }

        public Vocablary()
        {
            VocablaryForClass = new Dictionary<string, string>();
        }
        public Vocablary(Dictionary<string, string> vocablary)
        {
            VocablaryForClass = vocablary;
        }

        public void Add(Dictionary<string, string> parametr)
        {
            VocablaryForClass.Add(parametr.Keys.ToString(), parametr.Values.ToString());
        }

        internal void GetDictionary(string str)
        {

            try
            {
                VocablaryForClass.Add(str.Split(" - ")[0].ToString(), str.Split(" - ")[1].ToString());
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
        }

        internal void FixTheVocablary(string str)
        {
            if (str.Length > 0)
            {
                Console.WriteLine($"program no data about this world \"{str}\"");

                try
                {
                    var newValue = Console.ReadLine();
                    VocablaryForClass.Add(str, newValue);
                    Writter.AddToVocablaryFile(@"C:\Programs\ConsoleApp1\ConsoleApp1\Files txt\Vocablary.txt", str + " - " + newValue + "\n");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("if you want to print again please tab 1");
                    if (Console.ReadLine() == "1") FixTheVocablary(str);
                }
            }
            else
            {
                Console.WriteLine("your world is empty");
            }
        }



        public override string ToString()
        {
            string str = "";
            foreach (var item in VocablaryForClass)
            {
                str += item.ToString();
            }
            return str;
        }
    }
}
