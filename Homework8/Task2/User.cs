using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Task2
{
    internal class User
    {
        private string id;
        private DateTime dateOfYearMounthDay;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DateOfYMD
        {
            get { return dateOfYearMounthDay; }
            set { dateOfYearMounthDay = value; }
        }

        public User()
        {
            id = "";
            dateOfYearMounthDay = DateTime.Now;

        }

        public User(string iD, DateTime date)
        {
            ID = iD;
            DateOfYMD = date;

        }

        public override string ToString()
        {
            return string.Format ($"{id,-20} {DateOfYMD,-20}"); 
        }
    }
}
