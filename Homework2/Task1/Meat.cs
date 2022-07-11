using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Task1
{
    internal class Meat : Product
    {
        private int valueForCatugory;
        private int valueForKind;

        public int ValueForKind
        {
            get { return valueForKind; }
            set { valueForKind = value; }
        }

        public int ValueForCatugory
        {
            get { return valueForCatugory; }
            set { valueForCatugory = value; }
        }

        enum Category
        {
            HightSort = 1,
            FirstSort,
            SecondSort
        }

        enum Kind
        {
            Mutton = 1,
            Veal,
            Pork,
            Chicken
        }

        public Meat() : this(1, 1, "none ", 0.01m, 0.01m)
        {

        }

        public Meat(int forCategory, int forKind, string name, decimal weight, decimal price) :
            base(name, price, weight)
        {
            ValueForCatugory = forCategory;
            ValueForKind = forKind;
        }

        public Meat(string nameForCategory, string nameForKind)
        {
            ValueForCatugory = ValueFromStringForCategoryEnum(nameForCategory);
            ValueForKind = ValueFromStringForKindEnum(nameForKind);
        }

        private int ValueFromStringForKindEnum(string nameForKind)
        {
            int count = 0;
            foreach (var item in Enum.GetNames(typeof(Kind)))
            {
                count++;
                if (item == nameForKind)
                {
                    return count;
                }

            }
            return count;
        }

        private int ValueFromStringForCategoryEnum(string nameForCategory)
        {
            int count = 0;
            foreach (var item in Enum.GetNames(typeof(Category)))
            {
                count++;
                if (item == nameForCategory)
                {
                    return count;
                }
                count++;
            }
            return count;
        }



        public override void ChangePrice(double percent)
        {
            Price *= 7 / (valueForCatugory + valueForKind) + (decimal)(0.01 * percent);
        }
        public override string ToString()
        {
            return $"{new Product().ToString()}" +
                $"{Enum.GetName(typeof(Category), ValueForCatugory)}\n" +
                $"{Enum.GetName(typeof(Kind), ValueForKind)}";
        }
    }
}
