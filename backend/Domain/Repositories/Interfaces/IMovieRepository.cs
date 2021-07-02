using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repositories.Interfaces
{
    public interface IMovieRepository: IBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByYearAndGender(int year, int genderId);
        Task<IEnumerable<Movie>> GetAllWithGenres();
    }
}