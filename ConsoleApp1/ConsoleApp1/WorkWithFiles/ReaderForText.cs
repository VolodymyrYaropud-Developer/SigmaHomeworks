using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ConsoleApp1.Types;

namespace ConsoleApp1.WorkWithFiles
{
    internal static class ReaderForText
    {
        internal static Text ReadFromFile(string path)
        {
            if (IsFile(path))
            {
                using (var Reader = new StreamReader(path))
                {
                    string line;
                    Text text = new Text();
                    while ((line = Reader.ReadLine()) != null)
                    {
                        text += line; 
                    }
                    return text;
                }
            }return new Text();
        }

        private static bool IsFile (string path)
        {
            return File.Exists (path);
        }
    }
}
