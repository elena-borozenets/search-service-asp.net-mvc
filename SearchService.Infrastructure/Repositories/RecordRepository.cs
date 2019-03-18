using System;
using System.Collections.Generic;
using System.Linq;
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

        public Guid Save(IEnumerable<Record> recordList)
        {
            using (var db = new RecordDbContext())
            {
                var requestNumber=new Guid();
                recordList.Select(r => r.RequestNumber = requestNumber);
                db.Records.AddRange(recordList);
                db.SaveChanges();
                return requestNumber;
            }
        }

        public Guid Save(Record record)
        {
            using (var db = new RecordDbContext())
            {
                var requestNumber = new Guid();
                record.RequestNumber = requestNumber;
                db.Records.Add(record);
                db.SaveChanges();
                return requestNumber;
            }
        }

        public IEnumerable<Record> GetRecordsByRequestNumber(Guid requestNumber)
        {
            using (var db = new RecordDbContext())
            {
                var records = (from record in db.Records where record.RequestNumber==requestNumber select record);
                return records.ToList();
            }
        }
    }
}
