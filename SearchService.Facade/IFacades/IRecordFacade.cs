using System;
using System.Collections.Generic;
using SearchService.Models;

namespace SearchService.Facade.IFacades
{
    public interface IRecordFacade
    {
        Guid SaveRecords(IEnumerable<Record> recordList);
        IEnumerable<Record> GetRecordBySearchString(string searchString);
        IEnumerable<Record> GetRecordByRequestNumber(Guid requestNumber);
        IEnumerable<Record> GetAll();

    }
}
