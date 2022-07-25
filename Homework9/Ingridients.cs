using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class Ingridients
    {
        private string nameOfIngridients;
        private double weightOfIngridients;

        public double WeightOfIngridients
        {
            get { return weightOfIngridients; }
            set { weightOfIngridients = value; }
        }

        public string NameOfIngridients
        {
            get { return nameOfIngridients; }
            set { nameOfIngridients = value; }
        }


        List<Ingridients> ListOfIngrigients{ get; set; }

        public Ingridients()
        {
            NameOfIngridients = default;
            WeightOfIngridients = default;
            ListOfIngrigients = new();
        }

        public Ingridients(string nameOfIngridients, double weightOfIngridients)
        {
            NameOfIngridients = nameOfIngridients;
            WeightOfIngridients = weightOfIngridients;
        }

        public override string ToString()
        {
            return $"{nameOfIngridients} - {weightOfIngridients}"; 
        }

        public override bool Equals(object? obj)
        {
            if (obj is Ingridients temp)
                return NameOfIngridients == temp.NameOfIngridients;
            return false;
        }

        public override int GetHashCode()
        {
            return NameOfIngridients.GetHashCode();  
        }


    }
}
