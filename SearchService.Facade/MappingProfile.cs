using AutoMapper;


namespace SearchService.Facade
{
    using RecordDBO = Data.Entities.Record;
    using RecordModel = Models.Record;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecordModel, RecordDBO>();
            CreateMap<RecordDBO, RecordModel>();
        }
    }
}
