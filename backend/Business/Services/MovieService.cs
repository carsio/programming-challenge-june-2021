using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;
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
        public async Task<List<MovieDto>> GetMoviesByYearAndGender(int year, int genderId)
        {
            var movies = await _movieRepository.GetMoviesByYearAndGender(year, genderId);
            return movies.Select(m => new MovieDto(m)).ToList();
        }
    }
}