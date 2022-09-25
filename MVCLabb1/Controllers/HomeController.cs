using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//using MVCLabb1.Migrations;
using MVCLabb1.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Dynamic;
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


                BookBorrowCustomer borrower = new BookBorrowCustomer
                {
                    BorrowId = await generateId(),
                    CostumerId = Id,
                    BookId = BookId,
                    ReturnDate = DateTime.Now.AddMonths(1),
                };
                _bookBorrowDbContext.BookBorrowCustomers.Add(borrower);
                await _bookBorrowDbContext.SaveChangesAsync();
                return RedirectToAction("Books",new { Id });
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
            return RedirectToAction("Costumer");

        }

        public IActionResult AddCostumer() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCostumer([Bind("FirstName, LastName, Phone, Email")] Customer customer)
        {

            

            if (ModelState.IsValid)
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
        public async Task<IActionResult> UpdateCustomer([Bind("CustomerId, FirstName, LastName, Phone, Email")] Customer customer,int Id)
        {

            if (ModelState.IsValid)
            {
                customer.CostumerId = Id;
                _bookBorrowDbContext.Costumers.Update(customer);
                await _bookBorrowDbContext.SaveChangesAsync();

                return RedirectToAction("Costumer");
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
        }

        public async Task<IActionResult> BorrowedBooks(int? Id)
        {
            IEnumerable<BookBorrowCustomer> GroupingBorrowedBook = _bookBorrowDbContext.BookBorrowCustomers.Where(c => c.CostumerId == Id);

            return View(GroupingBorrowedBook);

        }
        public async Task<IActionResult> Borrowed(int? Id)
        {

            dynamic Borrowing = new ExpandoObject();
            Borrowing.Book = await _bookBorrowDbContext.Books.ToListAsync();
            Borrowing.BorrowCust = _bookBorrowDbContext.BookBorrowCustomers.Where(c => c.CostumerId == Id);
            return View(Borrowing);

        }

      public async Task<int> generateId()
        {
            Random rnd = new Random();
            int newId = rnd.Next();
            return await check(newId);
        }
        public async Task<int> check(int newId)
        {

            if(await _bookBorrowDbContext.Costumers.FirstOrDefaultAsync(f=>f.CostumerId ==newId) == null)
            {
                return (newId);
            }
            else
            {
                return await generateId();
            }
        }
        public async Task<IActionResult> ReturnBook(int Id, int BookId, int BorrowId)
        {

            var bookamount = _bookBorrowDbContext.Books.Find(BookId);
            bookamount.AmountInStore += 1;
            _bookBorrowDbContext.Books.Update(bookamount);

            var returnBook = await _bookBorrowDbContext.BookBorrowCustomers.FirstOrDefaultAsync(f=>f.BorrowId == BorrowId);
            returnBook.ReturnedToLibrary = DateTime.Now;
            returnBook.Returned = true;
            _bookBorrowDbContext.BookBorrowCustomers.Update(returnBook);
            
                await _bookBorrowDbContext.SaveChangesAsync();
                return RedirectToAction("Borrowed", new { Id });
        }


    }
}