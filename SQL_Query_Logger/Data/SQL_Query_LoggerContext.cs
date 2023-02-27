using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQL_Query_Logger.Models;

namespace SQL_Query_Logger.Data
{
    public class SQL_Query_LoggerContext : DbContext
    {
        public SQL_Query_LoggerContext (DbContextOptions<SQL_Query_LoggerContext> options)
            : base(options)
        {
        }

        public DbSet<SQL_Query_Logger.Models.Query> Query { get; set; } = default!;
    }
}
