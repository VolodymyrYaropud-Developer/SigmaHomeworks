using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Task1
{
    public static class Dialog
    {
        public static void Dialoge()
        {
            List<Meat> meats = new List<Meat>();
            Meat p = new Meat();
            Console.WriteLine("Hello. What are you want");

            Console.WriteLine("Products:");
            GetProductName(p);

            Console.WriteLine("Categores:");
            GetCategories(p);


            GetWeight(p);

            Console.WriteLine("Okey, maybe are you want something else? ");
            Console.WriteLine("1: Yes, 2: No");
            meats.Add(p);
            Dialoge();
        }

        private static void GetWeight(Meat p)
        {
            try
            {
                Console.WriteLine("how many are you want?");
                p.Weight = decimal.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("try again or you want to exit? press 5 for exit");
                if (Console.ReadLine() == "5")
                {
                    Environment.Exit(1);
                }
            }

        }

        private static void GetCategories(Meat p)
        {
            try
            {
                Console.WriteLine("1: HightSort, 2: FirstSort, 3: SecondSort\nExit: 4");
                if (Console.ReadLine() == "4" || Console.ReadLine() == "Exit")
                    Environment.Exit(0);
                p.ValueForCatugory =
                    Console.ReadLine() == "1" || Console.ReadLine() == "HightSort" ? 1 : 
                    Console.ReadLine() == "2" || Console.ReadLine() == "FirstSort" ? 2 : 3;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void GetProductName(Product p)
        {

            try
            {
                Console.WriteLine("1: Mutton, 2: Veal, 3: Pork, 4: Chicken\nExit: 5");
                if (Console.ReadLine() == "5" || Console.ReadLine() == "Exit")
                    Environment.Exit(1);
                p.Name =
                Console.ReadLine() == "1" || Console.ReadLine() == "Mutton" ? "Mutton" : 
                Console.ReadLine() == "2" || Console.ReadLine() == "Veal" ? "Veal" : 
                Console.ReadLine() == "3" || Console.ReadLine() == "Pork" ? "Pork" : 
                Console.ReadLine() == "4" || Console.ReadLine() == "Chicken" ? "Chicken" : "no Product";
            }
            catch (Exception e)
            {
                Console.WriteLine("try again");
                GetProductName(p);
                Console.WriteLine(e.Message);
            }
        }
    }
}
