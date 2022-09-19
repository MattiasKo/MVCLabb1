using Microsoft.EntityFrameworkCore;

namespace MVCLabb1.Models
{
    public class BookBorrowDbContext : DbContext
    {
        public BookBorrowDbContext(DbContextOptions<BookBorrowDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Costumers { get; set; }
        public DbSet<BookBorrowCustomer> BookBorrowCustomers { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBorrowCustomer>().HasKey(bk => new
            {
                bk.CostumerId,
                bk.BookId
            });
            modelBuilder.Entity<BookBorrowCustomer>().HasOne(m => m.Book).WithMany(bk => bk.Book_Borrow).HasForeignKey(m => m.BookId);
            modelBuilder.Entity<BookBorrowCustomer>().HasOne(m => m.Customer).WithMany(bk => bk.Customer_Borrow).HasForeignKey(m => m.CostumerId);


            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Title = "Entity kursbook",
                BookISBN = "23468635",
                AmountInStore=1,
                BookPictureUrl= "https://papunet.net/sites/papunet.net/files/kuvapankki/20190807/kirja_vari.jpg"

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Title = "advancerad Asp.net",
                BookISBN = "112323",
                AmountInStore = 1,
                BookPictureUrl= "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT3yGr3_kAc0rzeCubEwS6odjfOrhQ6r5f26LJZ7QVzqmojcvcR"

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Title = "sql server programmering",
                BookISBN = "12341233",
                AmountInStore = 2,
                BookPictureUrl= "https://s2.adlibris.com/images/41587515/sql-in-10-minutes-a-day-sams-teach-yourself.jpg"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Title = "MVC model view controller",
                BookISBN = "32412",
                AmountInStore = 20,
                BookPictureUrl= "https://s2.adlibris.com/images/768665/beginning-aspnet-mvc-4.jpg"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Title = "C# programmering",
                BookISBN = "263563",
                AmountInStore = 1,
                BookPictureUrl= "https://s1.adlibris.com/images/30710334/programmering-2-c.jpg"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CostumerId = 1,
                FirstName = "Mattias",
                LastName = "Kokkonen",
                Phone = 070555555

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CostumerId = 2,
                FirstName = "Edwin",
                LastName = "Noccomannen",
                Phone = 070444444

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CostumerId = 3,
                FirstName = "Daniel",
                LastName = "Vandraren",
                Phone = 07033333

            });
            modelBuilder.Entity<BookBorrowCustomer>().HasData(new BookBorrowCustomer
            {
        
                BookId = 1,
                CostumerId = 1
            });
            modelBuilder.Entity<BookBorrowCustomer>().HasData(new BookBorrowCustomer
            {
               
                BookId = 2,
                CostumerId = 1
            });
            modelBuilder.Entity<BookBorrowCustomer>().HasData(new BookBorrowCustomer
            {
                BookId = 4,
                CostumerId = 3
            });
            modelBuilder.Entity<BookBorrowCustomer>().HasData(new BookBorrowCustomer
            {
              
                BookId = 2,
                CostumerId = 3
            });
        }
    }
}
