using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Types;

namespace ConsoleApp1.WorkWithFiles
{
    internal static class Translate
    {
        public static void TranslateTheSentence()
        {
            try
            {

                Console.WriteLine("please put a path to vocablary.txt");
                var vocablary = ReaderForVocablary.ReadFromFile(Console.ReadLine());
                Console.WriteLine("please put a path to text.txt");
                var text = ReaderForText.ReadFromFile(Console.ReadLine());
                Match(text, vocablary);
            }
            catch (NullReferenceException e )
            {

                Console.WriteLine("empty string "+ e.Message);
            }
        }

        private static void Match(Text txt, Vocablary voc)
        {
            string str = "", res = "";
            foreach (var item in txt.WorldsFromFile)
            {

                if (voc.VocablaryForClass.ContainsKey(item))
                {
                    voc.VocablaryForClass.TryGetValue(item, out str);
                    res += str + " ";
                }
                else
                {
                    voc.FixTheVocablary(item);
                    voc.VocablaryForClass.TryGetValue(item, out str);
                    res += str + " ";
                }

            }
            Writter.PrintInFile(@"C:\Programs\ConsoleApp1\ConsoleApp1\Files txt\Output.txt", res);
        }
    }
}
