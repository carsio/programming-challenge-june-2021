using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repositories.Interfaces
{
    public interface IMovieRepository: IBaseRepository<Movie>
    {
        Task<List<Movie>> GetMoviesByYearAndGender(int year, int genderId);
    }
}