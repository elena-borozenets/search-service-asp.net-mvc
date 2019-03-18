using SearchService.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SearchService.Facade.IFacades;

namespace SearchService.Facade.Facades
{
    using RecordDBO = SearchService.Data.Entities.Record;
    using RecordModel = SearchService.Models.Record;

    public class RecordFacade : IRecordFacade
    {
        private readonly IRecordRepository _recordRepository;

        public RecordFacade(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public void SaveRecords(IEnumerable<RecordModel> recordList)
        {
            var list = Mapper.Map<IEnumerable<RecordModel>, IEnumerable<RecordDBO>>(recordList);
            _recordRepository.Save(list);
        }

        public IEnumerable<RecordModel> GetRecordBySearchString(string searchString)
        {
            var allRecords = _recordRepository.Get();
            var result = allRecords.Where(r => r.Text.Contains(searchString));
            var mappedResult = Mapper.Map<IEnumerable<RecordDBO>, IEnumerable<RecordModel>>(result);
            return mappedResult;
        }
    }
}
