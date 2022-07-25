using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework9.WorkWithFilles;

namespace Homework9
{
    internal class Menu
    {
        private List<Dish> dishes = new List<Dish>();

        public List<Dish> Dishes
        {
            get { return dishes; }
            set { dishes = value; }
        }
        public Menu()
        {

        }

        public Menu(Dish dish)
        {
            dishes.Add(dish);
        }

        public Menu(List<Dish> dishes) : this()
        {
            this.dishes = dishes;
        }

        public void CostForAll()
        {
            var res = Reader.ReadFromFileCourses(@"C:\Programs\SigmaHomeworks-master\Homework9\Files\Course.txt");
            var men = Reader.ReadFromFileMenu(@"C:\Programs\SigmaHomeworks-master\Homework9\Files\Menu.txt");

            var components = men.Dishes.SelectMany(
                d => d.Ingridients).
                GroupBy(i => i, (key, forSum) =>
                (key.NameOfIngridients, Weight:
                forSum.Sum(q => q.WeightOfIngridients)));
            
            var ListOfPrices = Reader.ReadFromPrices(@"C:\Programs\SigmaHomeworks-master\Homework9\Files\Prices.txt");
            

            var ingredientsCost = from p in ListOfPrices
                                  join i in components on p.name equals i.NameOfIngridients
                                  select new
                                  {
                                      p.name,
                                      i.Weight,
                                      p.price,
                                      Cost = p.price / res.Item1 * (i.Weight / 1000d)
                                  };
            ingredientsCost.ToArray();
            var strbld = new StringBuilder();
            foreach (var item in ingredientsCost)
            {
                strbld.AppendLine($"{item.name} {item.price} {item.Weight} {item.Cost} ");
            }
            Writter.PrintToFile(@"C:\Programs\SigmaHomeworks-master\Homework9\Files\result.txt", strbld);
        }

        public override string ToString()
        {
            var strBuild = new StringBuilder();

            foreach (var item in Dishes)
            {
                strBuild.Append(item);
            }
            return strBuild.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Menu temp)
            {
                if (Dishes.Count != temp.Dishes.Count)
                {
                    return false;
                }
                for (int i = 0; i < Dishes.Count; i++)
                {
                    if (!Dishes[i].Equals(temp.Dishes[i]))
                        return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return Dishes.GetHashCode();
        }
    }
}
