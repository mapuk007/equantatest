using System;
using System.Collections.Generic;
using System.Text;

namespace EquantaBook.Db.Tabels
{
    public class AuthorBooks
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
