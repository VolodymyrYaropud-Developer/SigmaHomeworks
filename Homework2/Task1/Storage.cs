using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Task1
{
    internal class Storage
    {
        private static List<Product> products = new List<Product>();
        private decimal sumForAll = 0;

        public decimal SumForAll
        {
            get { return sumForAll; }
            set { sumForAll = value; }
        }


        #region Dialoge
        public static void Dialoge()
        {
            Meat meats = new Meat();
            Console.WriteLine("Hello. What are you want");

            Console.WriteLine("Products:");
            GetProductName(meats);

            Console.WriteLine("Categores:");
            GetCategories(meats);

            GetWeight(meats);

            Console.WriteLine("Okey, maybe are you want something else? ");
            Console.WriteLine("1: Yes, 2: No");

            bool choice = Console.ReadLine() == "1" ? true : false;

            products.Add(new Meat(meats.ValueForCatugory, meats.ValueForKind, meats.Name, meats.Weight, meats.Price));

            if (choice)
                Dialoge();
            else
                Console.WriteLine("thanks goodbye\n");
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
                string value = Console.ReadLine();
                if (value == "4" || value == "Exit")
                    Environment.Exit(0);

                switch (value)
                {
                    case "1":
                        p.ValueForCatugory = 1;
                        break;

                    case "2":
                        p.ValueForCatugory = 2;
                        break;

                    case "3":
                        p.ValueForCatugory = 3;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        GetProductName(p);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void GetProductName(Meat p)
        {

            try
            {
                Console.WriteLine("1: Mutton, 2: Veal, 3: Pork, 4: Chicken\nExit: 5");
                string value = Console.ReadLine();
                if (value == "5" || value == "Exit")
                    Environment.Exit(1);
                switch (value)
                {
                    case "1":
                        p.Name = "Mutton";
                        p.ValueForKind = 1;
                        break;

                    case "2":
                        p.Name = "Veal";
                        p.ValueForKind = 2;
                        break;

                    case "3":
                        p.Name = "Pork";
                        p.ValueForKind = 3;
                        break;

                    case "4":
                        p.Name = "Chicken";
                        p.ValueForKind = 4;
                        break;
                    case "5":
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Try again");
                        GetProductName(p);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("try again");
                GetProductName(p);
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        public void PrintAllInformatoin()
        {
            foreach (var item in products)
            {
                Console.WriteLine("name " + item.Name);
                Console.WriteLine("\nPrice " + item.Price);
                Console.WriteLine("\nItem " + item.Weight);
            }
            Console.WriteLine($"\nSum for all {SumForAll}");
        }

        public void PriceForAll()
        {
            foreach (var item in products)
            {
                item.Price = new Random().Next(1000);
            }
        }

        public void SumForAllProducts()
        {
            foreach (var item in products)
            {
                sumForAll += item.Price;
            }
        }

        public void ChangeAllPrice(double percent)
        {
            foreach (var item in products)
            {
                item.ChangePrice(percent);
            }
        }
    }
}
