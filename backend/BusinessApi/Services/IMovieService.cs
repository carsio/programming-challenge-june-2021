using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessApi.Dto;

namespace Business.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetMoviesByYearAndGender(int year, int genderId);
    }
}