using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Types
{
    internal class Text
    {
        private string text = "";
        private string[] worlds;

        public string TextFromFile
        {
            get { return text; }
            set
            {
                if (value.Length == 0 || value != null)

                {
                    text = value;
                }
                else
                    text = "none";
            }
        }

        public string[] WorldsFromFile
        {
            get { return worlds; }
            set { worlds = text.Split(); }
        }
        public Text()
        {
            TextFromFile = "";
            WorldsFromFile = new string[0];
        }

        public Text(string text)
        {
            TextFromFile = text;
        }

        public static Text operator + (Text a, Text b)
        {
            var res = new Text();
            res.TextFromFile= a.TextFromFile+ b.TextFromFile;
            res.WorldsFromFile = a.WorldsFromFile;
            for (int i = res.WorldsFromFile.Length, q = 0; i < res.WorldsFromFile.Length+ b.WorldsFromFile.Length;q++, i++)
            {
                res.WorldsFromFile[i] = b.WorldsFromFile[q]; 
            }
            return res;
        }
        public static Text operator +(Text a, string b)
        {
            var res = new Text();
            res.TextFromFile = a.TextFromFile + b;
            res.WorldsFromFile = a.WorldsFromFile;
            var temp = b.Split();

            return res;
        }
    }
}
