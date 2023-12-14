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

namespace BookstoreASP.Pages.Translators
{
    public class EditModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public EditModel(BookstoreASP.Data.BookstoreDbContext context)
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

            var translator =  await _context.Translators.FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }
            Translator = translator;
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

            _context.Attach(Translator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslatorExists(Translator.Id))
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

        private bool TranslatorExists(int id)
        {
            return _context.Translators.Any(e => e.Id == id);
        }
    }
}
