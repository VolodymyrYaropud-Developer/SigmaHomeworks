using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Task3
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price{ get; set; }
        public double Weight { get; set; }

        public Product()
        {
            Name = default;
            Price = default;
            Weight = default;
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Name {Name}\nWeight {Weight}\nPrice {Price}\n";
        }
    }
}
