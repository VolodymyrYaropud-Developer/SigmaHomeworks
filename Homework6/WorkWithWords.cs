using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class WorkWithWords
    {
        private string textWithErrors;
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string TextWithErrors
        {
            get { return textWithErrors; }
            set { textWithErrors = value; }
        }

        public WorkWithWords()
        {

        }
        public WorkWithWords(string text)
        {
            TextWithErrors = text;
        }

        private void ReadTheTextFromFile()
        {
            using (StreamReader sr = new StreamReader(TextWithErrors))
            {
                Text = sr.ReadToEnd();
            }
        }

        public void PrintText()
        {
            EditText();
            TextForResulst();
            Console.WriteLine(Text);
        }

        private void EditText()
        {
            ReadTheTextFromFile();
            RemoveSpaces();
            RemoveNewLineAndTab();
            
        }


        private void RemoveSpaces()
        {
            var temp = Text.Split(" ").ToList();
            while (true)
            {
                if (!temp.Remove(""))
                {
                    break;
                }
            }
            Text = "";
            for (int i = 0; i < temp.Count; i++)
            {
                Text += temp[i] + " ";
            }
        }
        private void RemoveNewLineAndTab()
        {
            Text = Text.Replace(System.Environment.NewLine, "");
        }

        private void TextForResulst()
        {
            var temp = Text.Split(new char[] {'.','?','!'});
            Text = "";
            for (int i = 0; i < temp.Length - 1; ++i)
            {
                if (i + 1 >= temp.Length - 1)
                {
                    Text += temp[i] + ".";
                }
                else
                    Text += temp[i] + ". \n";
                
            }
        }

        public void AddToResults(string path)
        {
            using (FileStream st = new FileStream(path, FileMode.OpenOrCreate))
            {
                st.Close();
                using (StreamWriter sw = new StreamWriter(path))
                {
                    EditText();
                    sw.WriteLine(Text);
                }
            }
        }

        public void PrintTheLargeAndTheSmallestWords()
        {
            EditText();
            TextForResulst();
            TheLarge();
            TheSmallest();
        }

        private void TheLarge()
        {
            string[] stringOfWords = Text.Split(' ');
            var theLarge = stringOfWords.OrderByDescending(n=>n.Length).First();
            Console.WriteLine("the large word " + theLarge);
        }
        private void TheSmallest()
        {
            string[] stringOfWords = Text.Split(' ');
            var theSmallest = stringOfWords.OrderByDescending(n => n.Length).Last();
            Console.WriteLine("the smallest word " + theSmallest); 
        }
    }
}
