using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;
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
        public async Task<IEnumerable<MovieDto>> GetMoviesByYearAndGender(int year, int genderId)
        {
            var movies = await _movieRepository.GetMoviesByYearAndGender(year, genderId);
            return ParseMovieToDto(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllWithGenres();
            return ParseMovieToDto(movies);
        }

        private IEnumerable<MovieDto> ParseMovieToDto(IEnumerable<Movie> movies) => movies.Select(m => new MovieDto(m));
    }
}