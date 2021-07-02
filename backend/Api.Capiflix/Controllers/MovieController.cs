using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;
using BusinessApi.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Capiflix.Controllers
{
    [Route("api/movies")]
    public class MovieController: ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetAllMovies() => await _movieService.GetAllMovies();
    }
}