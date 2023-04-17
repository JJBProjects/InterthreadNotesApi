using AutoMapper;

namespace InterthreadNotesApi.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Entities.Note, Models.NoteDto>();
            CreateMap<Models.NoteForCreationDto, Entities.Note>();
        }
    }
}
