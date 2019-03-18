using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService.Data.Entities;

namespace SearchService.Infrastructure.IRepositories
{
    public interface IRecordRepository
    {
        IEnumerable<Record> Get();
        void Save(IEnumerable<Record> recordList);
        void Save(Record record);
    }
}
