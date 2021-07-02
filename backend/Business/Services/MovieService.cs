using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;
using BusinessApi.Services;
using Domain.Entity;
using Domain.Repositories.Interfaces;

namespace Business.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async  Task<IEnumerable<MovieDto>> GetMoviesByFilters(int? year, int? gender, int topK = 10)
        {
            var movies = await _movieRepository.GetMoviesByYearAndGender(year, gender);
            return ParseMovieToDto(movies.OrderByDescending(m=>m.Rating).Take(topK));
        }

        private IEnumerable<MovieDto> ParseMovieToDto(IEnumerable<Movie> movies) => movies.Select(m => new MovieDto(m));
    }
}