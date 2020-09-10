using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SecureAPI.Dtos.GenreDtos;
using SecureAPI.Dtos.MovieDtos;
using SecureAPI.Models;
using SecureAPI.Repo;

namespace SecureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenericCrudRepo<Genre> genreRepo;
        private readonly IGenericCrudRepo<Movie> movieRepo;
        private readonly IMapper mapper;

        //repo and mapper dependency injection into constructor
        public GenresController(IGenericCrudRepo<Genre> genreRepo, IGenericCrudRepo<Movie> movieRepo, IMapper mapper)
        {
            this.genreRepo = genreRepo;
            this.movieRepo = movieRepo;
            this.mapper = mapper;
        }

        //api/Genres/
        [HttpGet]
        public ActionResult<IEnumerable<GenreReadDto>> GetAllGenres()
        {
            var genres = this.genreRepo.GetAll();
            return Ok(this.mapper.Map<IEnumerable<GenreReadDto>>(genres));
        }

        //api/Genres/id/Movies

        [HttpGet("{genreId}/movies")]
        public ActionResult<IEnumerable<MovieReadDto>> GetAllMoviesByGenreId(int genreId)
        {

            var foundGenreModel = this.genreRepo.GetById(genreId);
            if (foundGenreModel == null)
                return NotFound(new { Message = "No genre found with given id", Method = "GetAllMoviesByGenreId in GenresController", HTTPMethod = "GET" });
            else
            {
                var movies = this.movieRepo.GetAllMoviesByGenreId(genreId);
                return Ok(this.mapper.Map<IEnumerable<MovieReadDto>>(movies));
            }

        }

        //api/Genres/id/Movies

        [HttpGet("{genreId}/movies/{movieId}")]
        public ActionResult<MovieReadDto> GetMovieByGenreIdAndMovieId(int genreId, int movieId)
        {
            var foundGenreModel = this.genreRepo.GetById(genreId);
            if (foundGenreModel == null)
                return NotFound(new { Message = "No genre found with given genre id", Method = "GetAllMoviesByGenreId in GenresController", HTTPMethod = "GET" });
            else
            {
                var foundMovieModel = this.movieRepo.GetMovieByGenreIdAndMovieId(genreId, movieId);
                if (foundMovieModel == null)
                    return NotFound(new { Message = "No movie found with given genre id and movie id", Method = "GetAllMoviesByGenreId in GenresController", HTTPMethod = "GET" });

                return Ok(this.mapper.Map<MovieReadDto>(foundMovieModel));
            }
        }

        //api/Genres/id
        [HttpGet("{id}", Name = "GetGenreById")]
        public ActionResult<GenreReadDto> GetGenreById(int id)
        {
            var foundGenreModel = this.genreRepo.GetById(id);
            if (foundGenreModel == null)
                return NotFound(new { Message = "No genre found with given id", Method = "GetGenreById in GenresController", HTTPMethod = "GET" });
            else
                return Ok(this.mapper.Map<GenreReadDto>(foundGenreModel));

        }


        [HttpPost]
        public ActionResult<GenreReadDto> CreateGenre(GenreCreateDto genreCreateDto)
        {
            var genreModel = this.mapper.Map<Genre>(genreCreateDto);
            var createdGenreModel = this.genreRepo.Create(genreModel);
            if (createdGenreModel == null)
            {
                return StatusCode(500);

            }
            else
            {
                var genreReadDto = this.mapper.Map<GenreReadDto>(createdGenreModel);
                return CreatedAtRoute(nameof(GetGenreById), new { id = genreReadDto.Id }, genreReadDto);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<GenreReadDto> UpdateGenre(int id, GenreUpdateDto genreUpdateDto)
        {
            var foundGenreModel = this.genreRepo.GetById(id);
            if (foundGenreModel == null)
                return NotFound(new { Message = "No genre found with given id", Action = "UpdateGenre in GenresController", HTTPMethod = "PUT" });
            else
            {
                this.mapper.Map(genreUpdateDto, foundGenreModel);

                if (!this.genreRepo.SaveChanges())
                    return StatusCode(500);

                return NoContent();
            }
        }

        //api/Genres/id
        [HttpPatch("{id}")]
        public ActionResult PartialGenreUpdate(int id, JsonPatchDocument<GenreUpdateDto> patchDocument)
        {
            var foundGenreModel = this.genreRepo.GetById(id);
            if (foundGenreModel == null)
                return NotFound(new { Message = "No genre found with given id", Action = "PartialGenreUpdate in GenresController", HTTPMethod = "PATCH" });
            else
            {
                var genreUpdateDto = this.mapper.Map<GenreUpdateDto>(foundGenreModel);
                patchDocument.ApplyTo(genreUpdateDto, ModelState);  //ModelState for validation

                if (!TryValidateModel(genreUpdateDto))
                {
                    return ValidationProblem(ModelState);
                }

                this.mapper.Map(genreUpdateDto, foundGenreModel);

                if (!this.genreRepo.SaveChanges())
                    return StatusCode(500);

                return NoContent();
            }


        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGenre(int id)
        {
            var foundGenreModel = this.genreRepo.GetById(id);
            if (foundGenreModel == null)
                return NotFound(new { Message = "No genre found with given id", Action = "DeleteGenre in GenresController", HTTPMethod = "DELETE" });
            else
            {
                this.genreRepo.Delete(foundGenreModel);

                if (!this.genreRepo.SaveChanges())
                    return StatusCode(500);

                return NoContent();
            }

        }
    }
}