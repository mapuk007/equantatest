﻿// <auto-generated />
using System;
using EquantaBook.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EquantaBook.Db.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20191123161507_BookMigration")]
    partial class BookMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EquantaBook.Db.Tabels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Василий Светлый"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Игорь Темный"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Артем Никудышнов"
                        });
                });

            modelBuilder.Entity("EquantaBook.Db.Tabels.AuthorBooks", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            AuthorId = 1,
                            BookId = 2
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 3
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 4
                        },
                        new
                        {
                            AuthorId = 3,
                            BookId = 2
                        },
                        new
                        {
                            AuthorId = 3,
                            BookId = 4
                        });
                });

            modelBuilder.Entity("EquantaBook.Db.Tabels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Властелин света",
                            PageCount = 23,
                            PublisherId = 1,
                            Year = 2019
                        },
                        new
                        {
                            Id = 2,
                            Name = "Красный рассвет",
                            PageCount = 26,
                            PublisherId = 1,
                            Year = 2019
                        },
                        new
                        {
                            Id = 3,
                            Name = "Властелин тьмы",
                            PageCount = 28,
                            PublisherId = 2,
                            Year = 2019
                        },
                        new
                        {
                            Id = 4,
                            Name = "Красный закат",
                            PageCount = 280,
                            PublisherId = 2,
                            Year = 2019
                        });
                });

            modelBuilder.Entity("EquantaBook.Db.Tabels.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Издательство Рассвет"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Издательство Закат"
                        });
                });

            modelBuilder.Entity("EquantaBook.Db.Tabels.AuthorBooks", b =>
                {
                    b.HasOne("EquantaBook.Db.Tabels.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquantaBook.Db.Tabels.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquantaBook.Db.Tabels.Book", b =>
                {
                    b.HasOne("EquantaBook.Db.Tabels.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");
                });
#pragma warning restore 612, 618
        }
    }
}
