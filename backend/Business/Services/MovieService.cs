using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;

namespace Business.Services
{
    public class MovieService: IMovieService
    {
        public Task<List<MovieDto>> GetMoviesByYearAndGender(int year, int genderId)
        {
            throw new System.NotImplementedException();
        }
    }
}