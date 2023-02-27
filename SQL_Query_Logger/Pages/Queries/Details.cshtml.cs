using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQL_Query_Logger.Data;
using SQL_Query_Logger.Models;

namespace SQL_Query_Logger.Pages.Queries
{
    public class DetailsModel : PageModel
    {
        private readonly SQL_Query_Logger.Data.SQL_Query_LoggerContext _context;

        public DetailsModel(SQL_Query_Logger.Data.SQL_Query_LoggerContext context)
        {
            _context = context;
        }

      public Query Query { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Query == null)
            {
                return NotFound();
            }

            var query = await _context.Query.FirstOrDefaultAsync(m => m.Id == id);
            if (query == null)
            {
                return NotFound();
            }
            else 
            {
                Query = query;
            }
            return Page();
        }
    }
}
