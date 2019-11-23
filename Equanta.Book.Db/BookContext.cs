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



            modelBuilder.Entity<Publisher>().HasData(
                  new Publisher[]
                  {
                        new Publisher { Id=1, Name="Издательство Рассвет"},
                        new Publisher { Id=2, Name="Издательство Закат"}
                  });

            modelBuilder.Entity<Book>().HasData(
                  new Book[]
                  {
                        new Book { Id=1, Name="Властелин света", PageCount=23, PublisherId = 1, Year = 2019},
                        new Book { Id=2, Name="Красный рассвет", PageCount=26,  PublisherId = 1, Year = 2019},
                        new Book { Id=3, Name="Властелин тьмы", PageCount=28,  PublisherId = 2, Year = 2019},
                        new Book { Id=4, Name="Красный закат", PageCount=280,  PublisherId = 2, Year = 2019}
                  });

            modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                        new Author { Id=1, Name="Василий Светлый"},
                        new Author { Id=2, Name="Игорь Темный"},
                        new Author { Id=3, Name="Артем Никудышнов"},
                });

            modelBuilder.Entity<AuthorBooks>().HasData(
               new AuthorBooks[]
               {
                        new AuthorBooks { AuthorId = 1, BookId = 1},
                        new AuthorBooks { AuthorId = 1, BookId = 2},
                        new AuthorBooks { AuthorId = 2, BookId = 3},
                        new AuthorBooks { AuthorId = 2, BookId = 4},
                        new AuthorBooks {AuthorId = 3, BookId = 2},
                        new AuthorBooks {AuthorId = 3, BookId = 4},
               });

        }

    }
}
