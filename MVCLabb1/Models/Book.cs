using System.ComponentModel.DataAnnotations;

namespace MVCLabb1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookISBN { get; set; }
        public int AmountInStore { get; set; }
        public string BookPictureUrl { get; set; }
        public List<BookBorrowCustomer> Book_Borrow { get; set; }

    }
}
