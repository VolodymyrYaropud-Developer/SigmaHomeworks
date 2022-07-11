using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    internal class Buy
    {
        private decimal sumOfWeight;
        private decimal sumOfPrice;
        private int countOfProducts;

        public int CountOfProducts
        {
            get { return countOfProducts; }
            set
            {
                if (value > 0)
                    countOfProducts = value;
            }
        }
        public decimal SumOfPrice
        {
            get { return sumOfPrice; }
            set { sumOfPrice = value; }
        }
        public decimal SumOfWeight
        {
            get { return sumOfWeight; }
            set { sumOfWeight = value; }
        }

        public Buy() : this(0, default)
        {

        }
        public Buy(int cop, Product product)
        {
            CountOfProducts = cop;
            GetPrice(product);
            GetWeight(product);
        }

        private void GetPrice(Product p)
        {
            SumOfPrice = countOfProducts * p.Price;
        }

        private void GetWeight(Product p)
        {
            SumOfWeight = countOfProducts * p.Weight;
        }

        public override string ToString()
        {
            return $"Price {SumOfPrice}\n" +
                $"Weight {SumOfWeight}\n" +
                $"Amount {CountOfProducts}";
        }
    }
}
