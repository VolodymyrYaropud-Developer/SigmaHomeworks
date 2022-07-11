using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework6
{

    internal static class ReadFromFile
    {
        static string pathForWrite = @"D:\courses\TaskForMe\SigmaHomeworks\Homework6\AddToFileComponents\AddFile.txt";
        static string pathForRead = @"D:\courses\TaskForMe\SigmaHomeworks\Homework6\ReadFromFileComponents\ReadFile.txt";
        static string[] allLines = File.ReadAllLines(pathForWrite);
        static List<string> info = FullInformation(allLines);


        public static void PrintReport()
        {
            IsFile();
            (int numberOfFlastm, int[] valuesForMouths )= GetValues();
            using (FileStream fs = new FileStream(pathForRead, FileMode.OpenOrCreate))
            {
                fs.Close();
                using (StreamWriter sw = new StreamWriter(pathForRead))
                {
                    sw.WriteLine("==========================================================");
                    sw.WriteLine($"|#\t |Name\t\t\t\t\t| {Enum.GetName(typeof(Mounth), valuesForMouths[0] )} | {Enum.GetName(typeof(Mounth), valuesForMouths[01])} |" +
                        $" {Enum.GetName(typeof(Mounth), valuesForMouths[2])} |");


                    for (int i = 1, forName=1, forFirstMounth =4, forSecondMounth = 6, forThitdMounth = 8; i <= numberOfFlastm; i++, forName+=9,
                        forFirstMounth+=9, forSecondMounth += 9, forThitdMounth += 9)
                    {
                        sw.WriteLine("==========================================================");
                        //  sw.WriteLine( $"|{i}\t | {info[forName]}\t\t|{info[forFirstMounth]}\t  |{info[forSecondMounth]}\t\t |{info[forThitdMounth]}|");
                        sw.WriteLine($"{String.Format("|{0,-4}| {1,-21}| {2,-8}| {3,-9}| {4,-6}|",i, info[forName], info[forFirstMounth], info[forSecondMounth], info[forThitdMounth])}");

                    }

                }
            }

        }
        private static void IsFile()
        {
            if (File.Exists(pathForRead))
            {
                if (!(File.ReadAllText(pathForRead).Length == 0))
                    File.Delete(pathForRead);

            }
            else
            {
                File.Create(pathForRead).Close();
                File.Delete(pathForRead);
            }
        }


        private static (int, int[]) GetValues()
        {
            var temp = allLines[0].Split(" | ");
            int num = int.Parse(temp[0].Substring(temp[0].IndexOf(":") + 1));
             int[] valuesForMouths = ExtractMounths(temp);
            return (num, valuesForMouths);
        }

        private static int[] ExtractMounths(string[] temp)
        {
            int quar = int.Parse(temp[1].Substring(temp[1].IndexOf(":") + 1));// 1 (0 1 2) 2 (3 4 5) 3(6 7 8) 4 (9 10 11)
            int[] mounthsOfQuartal = new int[3];
            switch (quar)
            {
                case 1:
                    for (int q = 0; q < 3; q++)
                    {
                        mounthsOfQuartal[q] = q ;
                    }
                    return mounthsOfQuartal;
                    
                case 2:
                    for (int q = 3; q < 6; q++)
                    {
                        mounthsOfQuartal[q] = q;
                    }
                    return mounthsOfQuartal;

                case 3:
                    for (int q = 6; q < 9; q++)
                    {
                        mounthsOfQuartal[q] = q; 
                    }
                    return mounthsOfQuartal;

                case 4:
                    for (int q = 9; q < 12; q++)
                    {
                        mounthsOfQuartal[q] = q;
                    }
                    return mounthsOfQuartal;

                default:
                    Console.WriteLine("#########ERORR#########");
                    return mounthsOfQuartal;
            }

        }

        private static List<string> FullInformation(string[] allLines)
        {
            List<string> NomerFlants = new List<string>();
            for (int i = 1; i < allLines.Length; i++)
            {
                NomerFlants.Add(allLines[i].Substring(allLines[i].IndexOf(": ") + 2));
            }

            return NomerFlants;
        }

        public static void PrintReportAboutOneFlat(int nomer)
        {
            for (int i = 0; i < info.Count; i += 9)
            {
                if (nomer.ToString() == info[i])
                {
                    Console.WriteLine("flats nomer " + info[i]);
                    Console.WriteLine("Name " + info[i + 1]);
                    Console.WriteLine("First pokaz " + info[i + 2]);
                    Console.WriteLine("Poraz ar " + info[i + 3]+ " values of these moment " + info[i+4]);
                    Console.WriteLine("Poraz ar " + info[i + 5] + " values of these moment " + info[i + 6]);
                    Console.WriteLine("Poraz ar " + info[i + 7] + " values of these moment " + info[i + 8]);
                    break;
                }
            }
        }

        public static void MaxDebt(double cost)
        {
            List<int> res = new List<int>();
            for (int i = 2; i < info.Count; i += 9)
            {
                res.Add(int.Parse(info[i + 6]) - int.Parse(info[i]));
            }
            Console.WriteLine(res.Max() * cost);
        }
    }
}