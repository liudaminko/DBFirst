﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookstoreASP.Data;
using BookstoreASP.Models;

namespace BookstoreASP.Pages.Publishers
{
    public class EditModel : PageModel
    {
        private readonly BookstoreASP.Data.BookstoreDbContext _context;

        public EditModel(BookstoreASP.Data.BookstoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher =  await _context.Publishers.FirstOrDefaultAsync(m => m.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }
            Publisher = publisher;
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

            _context.Attach(Publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(Publisher.Id))
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

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }
    }
}
