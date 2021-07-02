using System.Collections;
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
        /// Get movies by filters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetMoviesByFilters(
            [FromQuery] int? year,
            [FromQuery] int? gender,
            [FromQuery] int topK = 10
            )
        {
            return await _movieService.GetMoviesByFilters(year, gender, topK);
        } 
    }
}