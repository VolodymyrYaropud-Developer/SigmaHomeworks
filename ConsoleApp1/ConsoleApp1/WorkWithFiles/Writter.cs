using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1.WorkWithFiles
{
    internal static class Writter
    {
        internal static void PrintInFile(string path, string message)
        {
            DeleteAndCreateFile(path);
            using (var Writter = new StreamWriter(path, true))
            {
                Writter.Write(message);
            }
        }
        internal static void AddToVocablaryFile(string path, string message)
        {
            using (var Writter = new StreamWriter(path, true))
            {
                Writter.Write(message);
            }
        }
        private static void DeleteAndCreateFile(string path)
        {
            if (!(new FileInfo(path).Length == 0))
            {
                File.Delete(path);
                File.Create(path).Close();
            }
        }

    }
}
