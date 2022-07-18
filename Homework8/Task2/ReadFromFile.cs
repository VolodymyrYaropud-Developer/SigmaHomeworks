using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Task2
{
    internal class ReadFromFile
    {
        private string path = @"C:\Programs\SigmaHomeworks-master\Homework8\Task2\UsersView.txt";
        List<User> users = new List<User>();


        public void ReadLineByLine()
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    users.Add(GetValue(line));
                }
            }
        }

        private User GetValue(string line)
        {
            var temp = GetArray(line);
            return new User(temp[0], Convert.ToDateTime(temp[1]));
        }

        private string[] GetArray(string line)
        {
            var temp = line.Split().ToList();
            while (true)
            {
                if (!temp.Remove(""))
                {
                    break;
                }
            }
            temp[1] = temp[1] + " " + temp[2];
            temp.RemoveAt(2);
            return temp.ToArray();
        }

        public void CountScoreOfVisit()
        {
            var duplicates = users.GroupBy(x => x.ID)
                   .Where(g => g.Count() >= 1)
                   .Select(y => new { User = y.Key, Count = y.Count() })
                   .ToList();
            foreach (var item in duplicates)
            {
                Console.WriteLine(item);
            }
        }

        public void PopularDay()
        {
            var day = users.GroupBy(x => x.DateOfYMD.DayOfWeek)
                .Where(g => g.Count() >= 1)
                .Select(y => new { Day = y.Key, Count = y.Count() })
                .ToList();
            
        }

        public void PopularHours()
        {
            var hours = users.GroupBy(x => x.DateOfYMD.Hour)
                .Where(g => g.Count() >= 1)
                .Select(y => new { Hours = y.Key, Count = y.Count() })
                .ToList();
            foreach (var item in hours)
            {
                Console.WriteLine(item);
            }
        }
    }
}
