using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessApi.Dto;

namespace BusinessApi.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesByYearAndGender(int year, int genderId);
        Task<IEnumerable<MovieDto>> GetAllMovies();
    }
}