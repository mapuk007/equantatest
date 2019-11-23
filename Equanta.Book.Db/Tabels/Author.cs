using System;
using System.Collections.Generic;
using System.Text;

namespace EquantaBook.Db.Tabels
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AuthorBooks> Books { get; set; }

        public Author()
        {
            Books = new List<AuthorBooks>(); 
        }
    }
}
