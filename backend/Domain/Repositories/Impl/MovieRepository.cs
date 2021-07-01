using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entity;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Impl
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<List<Movie>> GetMoviesByYearAndGender(int year, int genderId)
        {
            var mg = await Context
                .MovieGenders
                .Include(mg=>mg.Movie)
                .Include(mg=>mg.Gender)
                .Where(mg => mg.Movie.Year == year && mg.GenderId == genderId)
                .ToListAsync();

            return mg.Select(mg => mg.Movie).ToList();
        }
    }
}