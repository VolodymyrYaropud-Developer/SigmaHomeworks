using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class ReaderForVocablary
    {
        public static Vocablary ReadFromFile(string path)
        {
            if (IsFile(path))
            {
                using (var Reader = new StreamReader(path))
                {
                    Vocablary v1 = new Vocablary();
                    var strForReader = "";
                    while ((strForReader = Reader.ReadLine()) != null)
                    {
                        v1.GetDictionary(strForReader);               
                    }
                    return v1;
                }
                
            }return new Vocablary();
        }
        private static bool IsFile(string path)
        {

            return File.Exists(path);
        }
    }
}
