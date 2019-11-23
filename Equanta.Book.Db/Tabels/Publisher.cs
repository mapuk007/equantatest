using System;
using System.Collections.Generic;
using System.Text;

namespace EquantaBook.Db.Tabels
{
    public class Publisher
    {        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
