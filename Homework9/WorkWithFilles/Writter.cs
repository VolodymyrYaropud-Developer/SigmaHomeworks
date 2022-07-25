using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9.WorkWithFilles
{
    internal static class Writter
    {
        public static void PrintToFile(string path, StringBuilder sb)
        {
            if (IsFile(path))
            {
                DeleteAndCreate(path);
                using (var writter = new StreamWriter(path, true))
                {

                    writter.Write(sb);
                }
            }
        }

        private static bool IsFile(string path)
        {
            if (File.Exists(path))
                return true;
            return false;
        }

        private static void DeleteAndCreate(string path)
        {
            File.Delete(path);
            File.Create(path).Close();
        }
    }
}
