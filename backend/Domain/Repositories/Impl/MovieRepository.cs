using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entity;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Repositories.Impl
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        private IIncludableQueryable<MovieGender, Gender> BaseIncludes()
        {
            return Context.MovieGenders
                .Include(mg => mg.Movie)
                .Include(mg => mg.Gender);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByYearAndGender(int year, int genderId)
        {
            var mg = await BaseIncludes()
                .Where(mg => mg.Movie.Year == year && mg.GenderId == genderId)
                .ToListAsync();

            return ParseMgToMovie(mg);
        }

        public async Task<IEnumerable<Movie>> GetAllWithGenres()
        {
            var mg = await BaseIncludes().ToListAsync();
            return ParseMgToMovie(mg);
        }

        private IEnumerable<Movie> ParseMgToMovie(IEnumerable<MovieGender> mg) => mg.Select(mg => mg.Movie);
    }
}