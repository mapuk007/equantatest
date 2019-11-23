using System;
using System.Collections.Generic;
using System.Text;

namespace EquantaBook.Db.Tabels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Year { get; set; }
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }


        public ICollection<AuthorBooks> Authors { get; set; }

        public Book()
        {
            Authors = new List<AuthorBooks>();
        }
    }
}
