using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async void OnGet(int id)
        {
            Book = await db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            { 
                var bookformdb = await db.Book.FindAsync(Book.id);
                bookformdb.name = Book.name;
                bookformdb.isbn = Book.isbn;
                bookformdb.author = Book.author;

                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
