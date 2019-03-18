using System.Data.Entity;
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
