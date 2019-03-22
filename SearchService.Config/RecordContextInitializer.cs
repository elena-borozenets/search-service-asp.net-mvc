using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService.Data.Entities;

namespace SearchService.Config
{

    public class RecordContextInitializer : DropCreateDatabaseAlways<RecordDbContext>
    //public class RecordContextInitializer : DropCreateDatabaseIfModelChanges<RecordDbContext>
    {
        protected override void Seed(RecordDbContext db)
        {

            db.Records.Add(new Record()
            {
                Id=0,
                Snippet = "SerchText",
                RequestNumber=new Guid()
            });
            db.Records.Add(new Record()
            {
                Id = 1,
                Snippet = "AnotherSerchText",
                RequestNumber = new Guid()
            });
            db.SaveChanges();
        }
    }
}
