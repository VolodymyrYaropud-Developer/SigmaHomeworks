using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Task1
{
    internal class User 
    {
        private int numberOfFlat;
        private string name;

        private string dateOfFirstMounth;
        private string dateOfSecondMounth;
        private string dateOfThirdMounth;


        private double resultOfFirstMounth;
        private double resultOfSecondMounth;
        private double resultOfThitdMounth;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberOfFlat
        {
            get { return numberOfFlat; }
            set
            {
                if (value >= 1)
                    numberOfFlat = value;
                else
                    numberOfFlat = 0;
            }
        }
        public string DateOfFirstMounth
        {
            get
            {
                return dateOfFirstMounth;
            }
            set
            {
                dateOfFirstMounth = value;
            }
        }
        public string DateOfSecond
        {
            get
            {
                return dateOfSecondMounth;
            }
            set
            {
                dateOfSecondMounth = value;
            }
        }
        public string DateOfThirdMounth
        {
            get
            {
                return dateOfThirdMounth;
            }
            set
            {
                dateOfThirdMounth = value;
            }
        }
        public double ResultOfFirstMounth
        {
            get
            {
                return resultOfFirstMounth;
            }
            set
            {
                resultOfFirstMounth = value;
            }
        }
        public double ResultOfSecondMounth
        {
            get
            {
                return resultOfSecondMounth;
            }
            set
            {
                resultOfSecondMounth = value;
            }
        }
        public double ResultOfThitdMounth
        {
            get
            {
                return resultOfThitdMounth;
            }
            set
            {
                resultOfThitdMounth = value;
            }
        }


        public User()
        {
            Name = "none";
            NumberOfFlat = 0;

            resultOfFirstMounth = 0;
            resultOfSecondMounth = 0;
            resultOfThitdMounth = 0;

            dateOfFirstMounth = "";
            dateOfSecondMounth = "";
            dateOfThirdMounth = "";
        }

        public User(int Flant, string name, double resOfFirst, double resOfSecond, double resOfthird, string dateFitrst, string dateSecond, string dateThird)
        {
            NumberOfFlat = Flant;
            Name = name;

            resultOfFirstMounth = resOfFirst;
            resultOfSecondMounth = resOfSecond;
            resultOfThitdMounth = resOfthird;

            dateOfFirstMounth = dateFitrst;
            dateOfSecondMounth = dateSecond;
            dateOfThirdMounth = dateThird;
        }
        // check
        public static List<User> operator +(List<User> first, User us)
        {
            first.Add(us);
            return first;
        }

        public static List<User> operator - (List<User> first, User us)
        {
            for (int i = 0; i < first.Count; i++)
            {
                if (Comparison(first[i], us))
                {
                    first.Remove(us);
                    return first;
                }
            }return first;

        }

        private static bool Comparison (User first, User second)
        {
            if (first.Name == second.Name && first.NumberOfFlat == second.NumberOfFlat)
                return true;
            return false;
        }


        public override string ToString()
        {
            return string.Format($"||{NumberOfFlat,-7}||{Name,-18}|| {dateOfFirstMounth,-8}  =>  {resultOfFirstMounth,-18}||{dateOfSecondMounth,-8}  =>  {resultOfSecondMounth,-18}||{dateOfThirdMounth,-8}  =>  {resultOfThitdMounth,-18}||");
        }
    }
}
