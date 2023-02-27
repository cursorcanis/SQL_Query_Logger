using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQL_Query_Logger.Data;
using SQL_Query_Logger.Models;

namespace SQL_Query_Logger.Pages.Queries
{
    public class CreateModel : PageModel
    {
        private readonly SQL_Query_Logger.Data.SQL_Query_LoggerContext _context;

        public CreateModel(SQL_Query_Logger.Data.SQL_Query_LoggerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Query Query { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Query == null || Query == null)
            {
                return Page();
            }

            _context.Query.Add(Query);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
