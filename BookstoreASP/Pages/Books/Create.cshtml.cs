using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookstoreASP.Data;
using BookstoreASP.Models;

namespace BookstoreASP.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public CreateModel(BookstoreASP.Data.BookstoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id");
        ViewData["TranslatorId"] = new SelectList(_context.Translators, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
