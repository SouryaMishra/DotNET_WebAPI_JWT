using AutoMapper;
using SecureAPI.Models;
using SecureAPI.Dtos.MovieDtos;

namespace SecureAPI.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            //Mapping from Source to Destination
            CreateMap<Movie, MovieReadDto>(); //GET
            CreateMap<MovieCreateDto, Movie>(); //POST
            CreateMap<MovieUpdateDto, Movie>(); //PUT
            CreateMap<Movie, MovieUpdateDto>(); //PATCH
        }
    }
}