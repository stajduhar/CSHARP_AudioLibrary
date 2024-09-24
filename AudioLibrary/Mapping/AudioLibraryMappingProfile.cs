using AutoMapper;
using AudioLibrary.Models;
using AudioLibrary.Models.DTO;

namespace AudioLibrary.Mapping
{
    public class AudioLibraryMappingProfile:Profile
    {
        public AudioLibraryMappingProfile()
        {

            CreateMap<Genre, GenreDTORead>();
            CreateMap<GenreDTOInsertUpdate, Genre>();

        }
    }
}
