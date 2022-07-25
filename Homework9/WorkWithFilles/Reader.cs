using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework9.WorkWithFilles
{
    internal static class Reader
    {
        static public Menu ReadFromFileMenu(string path)
        {
            List<Dish> dishes = new List<Dish>();
            if (IsFile(path))
                using (var streamReader = new StreamReader(path))
                {
                    string line;


                    while (!streamReader.EndOfStream)
                    {
                        Dish dish = new Dish();
                        int count = 0;
                        while ((line = streamReader.ReadLine()) != "" && line != null)
                        {
                            count++;
                            if (count > 1)
                            {
                                try
                                {
                                    dish.Ingridients.Add(new Ingridients(
                                        nameOfIngridients: line.Split("-")[0].ToString(),
                                        weightOfIngridients: double.Parse(line.Split("-")[1])));
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message + " не вірні вхідні дані");
                                }
                            }
                            else
                            {
                                dish.NameOfDish = line;
                            }
                        }

                        dishes.Add(dish);

                    }
                }
            return new Menu(dishes);

        }

        static public List<(string name, double price)> ReadFromPrices(string path)
        {
            if (IsFile(path))
            {
                using (var streamReader = new StreamReader(path))
                {
                    string line;
                    var resList = new List<(string name, double price)>();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        resList.Add((line.Split("-")[0], double.Parse(line.Split("-")[1])));
                    }
                    return resList; 
                }
            }
            return default;
        }


            static public (double, string) ReadFromFileCourses(string path)
            {
                if (IsFile(path))
                {
                    using (var streamReader = new StreamReader(path))
                    {
                        string line;
                        var tempStr = GetCurrency();
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Contains(tempStr))
                            {
                                return (double.Parse(line.Split("-")[1]), tempStr.ToString());
                            }
                        }
                    }
                }
                return (1, "empty");
            }

            static private bool IsFile(string path)
            {
                if (File.Exists(path))
                {
                    return true;
                }
                Console.WriteLine("file is not exist");
                return false;
            }

            private static string GetCurrency()
            {
                Console.WriteLine("Hello please pick the currency(UAH, USD, EUR)");
                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "UAH":
                        return answer;
                    case "USD":
                        return answer;
                    case "EUR":
                        return answer;
                    default:
                        Console.WriteLine("no correct currency");
                        return "";
                }
            }
        }
    }
