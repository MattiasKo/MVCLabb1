using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLabb1.Models

{
    public class Customer
    {
        [Key]
        public int CostumerId { get; set; }

        [Required(ErrorMessage ="FirstName is required")]
        [Column(TypeName = "nvarchar(25)")]
        [DisplayName("FirstName")]
        [MaxLength(25, ErrorMessage = "LastName cant be longer than 25 characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Lastname is required")]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("LastName")]
        [MaxLength(50, ErrorMessage = "Name cant be longer than 50 characters")]
        public string LastName { get; set; }
        
        

        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone")]

        public int Phone { get; set; }
        public List<BookBorrowCustomer> Customer_Borrow { get; set; }
       

    }
}
