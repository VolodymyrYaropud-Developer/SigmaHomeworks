using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Task1
{
    internal class DairyProducts : Product
    {

        private int expirationDate;

        public int ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                if (value > 0)
                {
                    expirationDate = value;
                }
            }
        }


        public DairyProducts() : this(0)
        {

        }

        public DairyProducts(int exDate)
        {
            ExpirationDate = exDate;
        }

        public override void ChangePrice(double percent)
        {
            Price *= (decimal)(0.01 * percent) + (ExpirationDate < 3 ? 0.5m * Price : 0.25m * Price);
        }

        public override string ToString()
        {
            return $"{new Product().ToString()}\n" +
                $"Expiration date: {ExpirationDate}";
        }
    }
}
