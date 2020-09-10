using AutoMapper;
using SecureAPI.Models;
using SecureAPI.Dtos.GenreDtos;

namespace SecureAPI.Profiles
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            //Mapping from Source to Destination
            CreateMap<Genre, GenreReadDto>(); //GET
            CreateMap<GenreCreateDto, Genre>(); //POST
            CreateMap<GenreUpdateDto, Genre>(); //PUT
            CreateMap<Genre, GenreUpdateDto>(); //PATCH
        }
    }
}