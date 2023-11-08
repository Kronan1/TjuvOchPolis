using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class City
    {
        public char[,] Board { get; set; } = new char[18, 140];
        public List<string> NameList { get; set; } = Helpers.NameList();
        public DateTime Datetime { get; set; } = DateTime.Now;
        public int NumberOfThieves { get; set; } = 0;
        public List<Person> Persons { get; set; } = new List<Person>();

        public City()
        {
            Persons = Person.CreateList(Board, NameList);
        }
    }
}
