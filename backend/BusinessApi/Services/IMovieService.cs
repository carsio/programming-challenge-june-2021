using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessApi.Dto;

namespace Business.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesByYearAndGender(int year, int genderId);
        Task<IEnumerable<MovieDto>> GetAllMovies();
    }
}