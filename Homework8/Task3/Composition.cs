using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Task3
{
    internal class Composition
    {
        private List<Product> products= new List<Product>();

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public Composition()
        {

        }
        public Composition(List<Product> pr)
        {
            Products= pr;
        }
        public Composition(Product pr)
        {
            Products.Add(pr);
        }

        public void EqualsAndDifferentProducts(Composition c1)
        {
            HashSet<Product> inOneComposition = new HashSet<Product>();
            HashSet<Product> atTwoCompisition = new HashSet<Product>();
            AddElementsToLists(c1, inOneComposition, atTwoCompisition);
            inOneComposition.ToHashSet().Distinct().ToList();
            DisplayRes(inOneComposition);
            Console.WriteLine("========================================");
            DisplayRes(atTwoCompisition);
        }

        public void UnionElements(Composition c1)
        {
            HashSet<Product> unionElements = this.Products.ToHashSet<Product>();
            foreach (var item in c1.Products)
            {
                unionElements.Add(item);
            }
            DisplayRes(unionElements);
        }


        private void AddElementsToLists(Composition c1, HashSet<Product> inOneComposition, HashSet<Product> atTwoCompisition)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Product? firstItem = this.Products[i];
                foreach (var secondItem in c1.Products)
                {
                    if (firstItem.Equals(secondItem))
                    {
                        atTwoCompisition.Add(firstItem);
                    }
                    else
                    {
                        inOneComposition.Add(firstItem);
                    }
                }
            }
        }

        private void DisplayRes(HashSet<Product> res)
        {
            Console.WriteLine("==========================================================");
            foreach (var item in res)
            {
                Console.Write(item);
            }
            Console.WriteLine("==========================================================");
        }

    }
}
