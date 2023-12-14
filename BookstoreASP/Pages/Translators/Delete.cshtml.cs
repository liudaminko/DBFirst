using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookstoreASP.Data;
using BookstoreASP.Models;

namespace BookstoreASP.Pages.Translators
{
    public class DeleteModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public DeleteModel(BookstoreASP.Data.BookstoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Translator Translator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators.FirstOrDefaultAsync(m => m.Id == id);

            if (translator == null)
            {
                return NotFound();
            }
            else
            {
                Translator = translator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators.FindAsync(id);
            if (translator != null)
            {
                Translator = translator;
                _context.Translators.Remove(Translator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
