using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CheckItem : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Check { get; set; }
        public CheckItem(int id, string name, bool check)
        {
            Id = id;
            Name = name;
            Check = check;
        }
        public int CompareTo(object o)
        {
            CheckItem p = o as CheckItem;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
