using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLabb1.Models
{
    public class BookBorrowCustomer
    {
       
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerat‌ed(System.ComponentM‌​odel.DataAnnotations‌​.Schema.DatabaseGeneratedOp‌​tion.None)]
        public int BorrowId { get; set; }
       

        [ForeignKey("CostumerId")]
        public int CostumerId { get; set; }
        public Customer Customer { get; set; }



        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnedToLibrary { get; set; }
        public bool Returned { get; set; }
        public IEnumerable<Book> BookViewModel { get; set; }
        public IEnumerable<Customer> CustomerViewModel { get; set; }
    }
}
