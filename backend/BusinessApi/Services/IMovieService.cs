using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessApi.Dto;

namespace BusinessApi.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesByFilters(int? year, int? gender, int topK = 10);
    }
}