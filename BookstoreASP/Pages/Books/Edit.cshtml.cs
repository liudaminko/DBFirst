using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookstoreASP.Data;
using BookstoreASP.Models;

namespace BookstoreASP.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public EditModel(BookstoreASP.Data.BookstoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  await _context.Books.FirstOrDefaultAsync(m => m.ItemId == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
           ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
           ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id");
           ViewData["TranslatorId"] = new SelectList(_context.Translators, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ItemId == id);
        }
    }
}
