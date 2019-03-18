using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace SearchService.Facade
{
    using RecordDBO = SearchService.Data.Entities.Record;
    using RecordModel = SearchService.Models.Record;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecordModel, RecordDBO>();
            CreateMap<RecordDBO, RecordModel>();
        }
    }
}
