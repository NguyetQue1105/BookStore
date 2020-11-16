using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public float BookPrice { get; set; }
        public Book()
        {
            BookID = 0;
            BookName = "";
            BookPrice = 0;
        }
        public Book (int ID, string Name, float Price)
        {
            BookID = ID;
            BookName = Name;
            BookPrice = Price;
        }
    }
}
