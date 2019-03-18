using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService.Config;
using SearchService.Data.Entities;
using SearchService.Infrastructure.IRepositories;

namespace SearchService.Infrastructure.Repositories
{
    public class RecordRepository: IRecordRepository
    {
        public IEnumerable<Record> Get()
        {
            using (var db = new RecordDbContext())
            {
                var records = (from record in db.Records select record);
                return records.ToList();
            }
        }

        public void Save(IEnumerable<Record> recordList)
        {
            using (var db = new RecordDbContext())
            {
                db.Records.AddRange(recordList);
                db.SaveChanges();
            }
        }

        public void Save(Record record)
        {
            using (var db = new RecordDbContext())
            {
                db.Records.Add(record);
                db.SaveChanges();
            }
        }
    }
}
