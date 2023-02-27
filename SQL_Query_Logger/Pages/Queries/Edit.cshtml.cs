using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQL_Query_Logger.Data;
using SQL_Query_Logger.Models;

namespace SQL_Query_Logger.Pages.Queries
{
    public class EditModel : PageModel
    {
        private readonly SQL_Query_Logger.Data.SQL_Query_LoggerContext _context;

        public EditModel(SQL_Query_Logger.Data.SQL_Query_LoggerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Query Query { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Query == null)
            {
                return NotFound();
            }

            var query =  await _context.Query.FirstOrDefaultAsync(m => m.Id == id);
            if (query == null)
            {
                return NotFound();
            }
            Query = query;
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

            _context.Attach(Query).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryExists(Query.Id))
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

        private bool QueryExists(int id)
        {
          return (_context.Query?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
