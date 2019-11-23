using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EquantaBook.Db.Tabels;

namespace EquantaBook.Db
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        { 
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AuthorBooks>()
                .HasKey(x => new { x.AuthorId, x.BookId });
            modelBuilder.Entity<AuthorBooks>()
                .HasOne(x => x.Book)
                .WithMany(m => m.Authors)
                .HasForeignKey(x => x.BookId);
            modelBuilder.Entity<AuthorBooks>()
                .HasOne(x => x.Author)
                .WithMany(e => e.Books)
                .HasForeignKey(x => x.AuthorId);
        }

    }
}
