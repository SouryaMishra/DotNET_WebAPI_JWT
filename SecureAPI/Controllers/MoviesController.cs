using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecureAPI.Models;
using SecureAPI.Repo;

namespace SecureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IGenericCrudRepo<Movie> movieRepo;
        private readonly IGenericCrudRepo<Genre> genreRepo;
        private readonly IMapper mapper;

        //repo and mapper dependency injection into constructor
        public MoviesController(IGenericCrudRepo<Movie> movieRepo, IGenericCrudRepo<Genre> genreRepo, IMapper mapper)
        {
            this.movieRepo = movieRepo;
            this.genreRepo = genreRepo;
            this.mapper = mapper;
        }
    }
}