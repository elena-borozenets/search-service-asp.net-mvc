using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService.Data.Entities;

namespace SearchService.Config
{
    public class RecordDbContext: DbContext
    {
        public RecordDbContext() : base()
        {
            var a = Database.Connection.ConnectionString;
        }

        public DbSet<Record> Records { get; set; }
    }
}
