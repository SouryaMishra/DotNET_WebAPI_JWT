using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecureAPI.Dtos.MovieDtos;
using SecureAPI.Models;
using SecureAPI.Repo;

namespace SecureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IGenericCrudRepo<Movie> movieRepo;
        private readonly IMapper mapper;

        //repo and mapper dependency injection into constructor
        public MoviesController(IGenericCrudRepo<Movie> movieRepo, IMapper mapper)
        {
            this.movieRepo = movieRepo;
            this.mapper = mapper;
        }

        //api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetAllMovies()
        {
            var movies = movieRepo.GetAll();
            return Ok(this.mapper.Map<IEnumerable<MovieReadDto>>(movies));
        }

        [HttpGet("{id}", Name = "GetMovieById")]

        public ActionResult<MovieReadDto> GetMovieById(int id)
        {
            var foundMovieModel = movieRepo.GetById(id);
            if (foundMovieModel == null)
                return NotFound();
            else
                return Ok(this.mapper.Map<MovieReadDto>(foundMovieModel));
        }

        [HttpPost]
        public ActionResult<MovieReadDto> CreateMovie(MovieCreateDto movieCreateDto)
        {
            if (movieCreateDto.GenreId <= 0)
                return BadRequest(new { Message = "GenreId was not supplied in request body" });
            var movieModel = this.mapper.Map<Movie>(movieCreateDto);
            var createdMovieModel = this.movieRepo.Create(movieModel);

            if (movieModel == null)
                return StatusCode(500);
            else
            {
                var movieReadDto = this.mapper.Map<MovieReadDto>(createdMovieModel);
                return CreatedAtRoute(nameof(GetMovieById), new { id = movieReadDto.Id }, movieReadDto);
            }
        }
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieUpdateDto movieUpdateDto)
        {
            if (movieUpdateDto.GenreId <= 0)
                return BadRequest(new { Message = "GenreId was not supplied in request body" });

            var foundMovieModel = this.movieRepo.GetById(id);
            if (foundMovieModel == null) return NotFound();
            else
            {
                this.mapper.Map(movieUpdateDto, foundMovieModel);

                if (!this.movieRepo.SaveChanges())
                    return StatusCode(500);

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var foundMovieModel = movieRepo.GetById(id);
            if (foundMovieModel == null)
                return NotFound();
            else
            {
                this.movieRepo.Delete(foundMovieModel);
                if (!this.movieRepo.SaveChanges())
                    return StatusCode(500);

                return NoContent();
            }

        }
    }
}