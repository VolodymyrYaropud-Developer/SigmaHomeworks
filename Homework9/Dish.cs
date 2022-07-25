using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class Dish
    {
        private List<Ingridients> ingridients = new List<Ingridients>();
        private string nameOfDish;

        public List<Ingridients> Ingridients
        {
            get { return ingridients; }
            set { ingridients = value; }
        }

        public string NameOfDish
        {
            get { return nameOfDish; }
            set { nameOfDish = value; }
        }

        

        public Dish()
        {
            List<Ingridients> list = new List<Ingridients>();
            nameOfDish = default;
        }
        public Dish(string name, Ingridients ingridients)
        {
            nameOfDish = name;
            this.ingridients.Add(ingridients);
        }

        public Dish(List<Ingridients> ingridients, string nameOfDish)
        {
            this.ingridients = ingridients;
            this.nameOfDish = nameOfDish;
        }


        public override string ToString()
        {
            var strBiuld = new StringBuilder(nameOfDish);
            foreach (var item in ingridients)
            {
                strBiuld.Append(item.ToString());
            }
            return strBiuld.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Dish temp)
                return nameOfDish == temp.NameOfDish;
            return false;
        }

        public override int GetHashCode()
        {
            return nameOfDish.GetHashCode();
        }
    }
}
