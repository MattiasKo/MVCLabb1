using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVCLabb1.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace MVCLabb1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookBorrowDbContext _bookBorrowDbContext;
        public HomeController(BookBorrowDbContext bookborrowDbContext)
        {
            _bookBorrowDbContext = bookborrowDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Costumer()
        {
            return View(await _bookBorrowDbContext.Costumers.ToListAsync());
        }
        public async Task<IActionResult> Books()
        {
            return View(await _bookBorrowDbContext.Books.ToListAsync());
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //[HttpPost]
        //[Route("{Id:int}/{BookId:int}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> BookBorrow(int Id, int BookId)
        {
            
            var bookamount = _bookBorrowDbContext.Books.Find(BookId);
            if (bookamount == null)
            {
                return NotFound("Book not found.");
            }
            bookamount.AmountInStore -= 1;
            _bookBorrowDbContext.Books.Update(bookamount);

            if (Id != 0 && BookId != 0)
            {
                int latestId = 0;
                int latestCheck = 0;

                do
                {                 
                    var latstBorrower = await _bookBorrowDbContext.BookBorrowCustomers.FirstOrDefaultAsync(c => c.BorrowId == latestId);                   
                    if (latestId == latstBorrower.BorrowId) 
                    {
                        latestId += 1;
                    }
                } while (latestCheck == latestId);

                    BookBorrowCustomer borrower = new BookBorrowCustomer
                {
                    BorrowId = latestId,
                    CostumerId = Id,
                    BookId = BookId,
                    ReturnDate = DateTime.Now,
                };
                _bookBorrowDbContext.BookBorrowCustomers.Add(borrower);
                await _bookBorrowDbContext.SaveChangesAsync();
                return RedirectToAction("Books");
            }
            return NotFound("Error book and user not found.");

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            Customer customer = await _bookBorrowDbContext.Costumers.FindAsync(Id);

            _bookBorrowDbContext.Costumers.Remove(customer);
            await _bookBorrowDbContext.SaveChangesAsync();
            return Ok("Customer deleted");

        }

        public IActionResult AddCostumer() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCostumer([Bind("FirstName, LastName, Phone")] Customer customer)
        {



            if (customer.FirstName != null && customer.LastName != null && customer.Phone != 0)
            {
             
                _bookBorrowDbContext.Costumers.Add(customer);
                await _bookBorrowDbContext.SaveChangesAsync();
                return RedirectToAction("Costumer");
                
              
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View();
            }

        }
        [HttpGet]
        //[Route("{Id:int}")]
        //public async Task<IActionResult> GetCustomerById([FromRoute] int? Id)
        public async Task<IActionResult> GetCustomerById(int? Id)
        {
            var customer = await _bookBorrowDbContext.Costumers.FirstOrDefaultAsync(f => f.CostumerId == Id);
            if (customer != null)
            {
                return View(customer);
            }
            return View(await _bookBorrowDbContext.Costumers.ToListAsync());

        }

        public async Task<IActionResult> UpdateCustomer(int Id)
        {
            Customer customer = await _bookBorrowDbContext.Costumers.FirstOrDefaultAsync(c=>c.CostumerId==Id);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCustomer([Bind("CostumerId, FirstName, LastName, Phone")] Customer customer)
        {
           
            if (customer != null)
            {

                _bookBorrowDbContext.Costumers.Update(customer);
                await _bookBorrowDbContext.SaveChangesAsync();

                return RedirectToAction("index");
            }
            else
            {
                return NotFound("Id not found");
            }
        }
     

       
    }
}