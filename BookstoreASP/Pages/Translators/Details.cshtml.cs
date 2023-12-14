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
    public class DetailsModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public DetailsModel(BookstoreASP.Data.BookstoreDbContext context)
        {
            _context = context;
        }

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
    }
}
