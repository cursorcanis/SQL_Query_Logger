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
    public class IndexModel : PageModel
    {
        private readonly SQL_Query_Logger.Data.SQL_Query_LoggerContext _context;

        public IndexModel(SQL_Query_Logger.Data.SQL_Query_LoggerContext context)
        {
            _context = context;
        }

        public IList<Query> Query { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Query != null)
            {
                Query = await _context.Query.ToListAsync();
            }
        }
    }
}
