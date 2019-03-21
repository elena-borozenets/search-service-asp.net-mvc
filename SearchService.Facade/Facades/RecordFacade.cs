using SearchService.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SearchService.Facade.IFacades;

namespace SearchService.Facade.Facades
{
    using RecordDBO = Data.Entities.Record;
    using RecordModel = Models.Record;

    public class RecordFacade : IFacades.IRecordFacade
    {
        private readonly IRecordRepository _recordRepository;

        public RecordFacade(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public Guid SaveRecords(IEnumerable<RecordModel> recordList)
        {
            var list = Mapper.Map<IEnumerable<RecordModel>, IEnumerable<RecordDBO>>(recordList);
            return _recordRepository.Save(list);
        }

        public IEnumerable<RecordModel> GetRecordBySearchString(string searchString)
        {
            var allRecords = _recordRepository.Get();
            var result = allRecords.Where(r => r.Text.Contains(searchString));
            var mappedResult = Mapper.Map<IEnumerable<RecordDBO>, IEnumerable<RecordModel>>(result);
            return mappedResult;
        }

        public IEnumerable<RecordModel> GetRecordByRequestNumber(Guid requestNumber)
        {
            var selectedRecords = _recordRepository.GetRecordsByRequestNumber(requestNumber);
            var mappedResult = Mapper.Map<IEnumerable<RecordDBO>, IEnumerable<RecordModel>>(selectedRecords);
            return mappedResult;
        }

        public IEnumerable<RecordModel> GetAll()
        {
            var selectedRecords = _recordRepository.Get();
            var mappedResult = Mapper.Map<IEnumerable<RecordDBO>, IEnumerable<RecordModel>>(selectedRecords);
            return mappedResult;
        }
    }
}
