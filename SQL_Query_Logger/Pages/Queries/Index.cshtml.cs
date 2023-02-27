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
    public class IndexModel : PageModel
    {
        private readonly SQL_Query_Logger.Data.SQL_Query_LoggerContext _context;

        public IndexModel(SQL_Query_Logger.Data.SQL_Query_LoggerContext context)
        {
            _context = context;
        }

        public IList<Query> Query { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Types_of_Queries { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Query_Type { get; set; }



        public async Task OnGetAsync()
        {
            // using System. Linq
            var queries = from q in _context.Query
                          select q;
            if (!string.IsNullOrEmpty(SearchString) ) {
                queries = queries.Where(s => s.Title_of_Query.Contains(SearchString));
            }

            Query = await queries.ToListAsync();

            if (_context.Query != null)
            {
                Query = await _context.Query.ToListAsync();
            }
        }
    }
}
