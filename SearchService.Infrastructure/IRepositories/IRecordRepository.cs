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
        Guid Save(IEnumerable<Record> recordList);
        Guid Save(Record record);
        IEnumerable<Record> GetRecordsByRequestNumber(Guid requestNumber);
    }
}
