﻿// <auto-generated />
using System;
using MVCLabb1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCLabb1.Migrations
{
    [DbContext(typeof(BookBorrowDbContext))]
    [Migration("20220914094016_NewRelationships")]
    partial class NewRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCLabb1.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmountInStore")
                        .HasColumnType("int");

                    b.Property<int?>("BookBorrowCustomerBookId")
                        .HasColumnType("int");

                    b.Property<int?>("BookBorrowCustomerCostumerId")
                        .HasColumnType("int");

                    b.Property<string>("BookISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookPictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookBorrowCustomerCostumerId", "BookBorrowCustomerBookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountInStore = 1,
                            BookISBN = "23468635",
                            BookPictureUrl = "https://papunet.net/sites/papunet.net/files/kuvapankki/20190807/kirja_vari.jpg",
                            Title = "Entity kursbook"
                        },
                        new
                        {
                            Id = 2,
                            AmountInStore = 1,
                            BookISBN = "112323",
                            BookPictureUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT3yGr3_kAc0rzeCubEwS6odjfOrhQ6r5f26LJZ7QVzqmojcvcR",
                            Title = "advancerad Asp.net"
                        },
                        new
                        {
                            Id = 3,
                            AmountInStore = 2,
                            BookISBN = "12341233",
                            BookPictureUrl = "https://s2.adlibris.com/images/41587515/sql-in-10-minutes-a-day-sams-teach-yourself.jpg",
                            Title = "sql server programmering"
                        },
                        new
                        {
                            Id = 4,
                            AmountInStore = 20,
                            BookISBN = "32412",
                            BookPictureUrl = "https://s2.adlibris.com/images/768665/beginning-aspnet-mvc-4.jpg",
                            Title = "MVC model view controller"
                        },
                        new
                        {
                            Id = 5,
                            AmountInStore = 1,
                            BookISBN = "263563",
                            BookPictureUrl = "https://s1.adlibris.com/images/30710334/programmering-2-c.jpg",
                            Title = "C# programmering"
                        });
                });

            modelBuilder.Entity("MVCLabb1.Models.BookBorrowCustomer", b =>
                {
                    b.Property<int>("CostumerId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CostumerId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookBorrowCustomers");

                    b.HasData(
                        new
                        {
                            CostumerId = 1,
                            BookId = 1,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CostumerId = 1,
                            BookId = 2,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CostumerId = 3,
                            BookId = 4,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CostumerId = 3,
                            BookId = 2,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MVCLabb1.Models.Customer", b =>
                {
                    b.Property<int>("CostumerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostumerId"), 1L, 1);

                    b.Property<int?>("BookBorrowCustomerBookId")
                        .HasColumnType("int");

                    b.Property<int?>("BookBorrowCustomerCostumerId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("CostumerId");

                    b.HasIndex("BookBorrowCustomerCostumerId", "BookBorrowCustomerBookId");

                    b.ToTable("Costumers");

                    b.HasData(
                        new
                        {
                            CostumerId = 1,
                            FirstName = "Mattias",
                            LastName = "Kokkonen",
                            Phone = 70555555
                        },
                        new
                        {
                            CostumerId = 2,
                            FirstName = "Edwin",
                            LastName = "Noccomannen",
                            Phone = 70444444
                        },
                        new
                        {
                            CostumerId = 3,
                            FirstName = "Daniel",
                            LastName = "Vandraren",
                            Phone = 7033333
                        });
                });

            modelBuilder.Entity("MVCLabb1.Models.Book", b =>
                {
                    b.HasOne("MVCLabb1.Models.BookBorrowCustomer", null)
                        .WithMany("BookViewModel")
                        .HasForeignKey("BookBorrowCustomerCostumerId", "BookBorrowCustomerBookId");
                });

            modelBuilder.Entity("MVCLabb1.Models.BookBorrowCustomer", b =>
                {
                    b.HasOne("MVCLabb1.Models.Book", "Book")
                        .WithMany("Book_Borrow")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCLabb1.Models.Customer", "Customer")
                        .WithMany("Customer_Borrow")
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MVCLabb1.Models.Customer", b =>
                {
                    b.HasOne("MVCLabb1.Models.BookBorrowCustomer", null)
                        .WithMany("CustoimerViewModel")
                        .HasForeignKey("BookBorrowCustomerCostumerId", "BookBorrowCustomerBookId");
                });

            modelBuilder.Entity("MVCLabb1.Models.Book", b =>
                {
                    b.Navigation("Book_Borrow");
                });

            modelBuilder.Entity("MVCLabb1.Models.BookBorrowCustomer", b =>
                {
                    b.Navigation("BookViewModel");

                    b.Navigation("CustoimerViewModel");
                });

            modelBuilder.Entity("MVCLabb1.Models.Customer", b =>
                {
                    b.Navigation("Customer_Borrow");
                });
#pragma warning restore 612, 618
        }
    }
}
