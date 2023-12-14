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
    public class IndexModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public IndexModel(BookstoreASP.Data.BookstoreDbContext context)
        {
            _context = context;
        }

        public IList<Translator> Translator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Translator = await _context.Translators.ToListAsync();
        }
    }
}
