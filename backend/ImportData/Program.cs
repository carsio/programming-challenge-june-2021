using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Deedle;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ImportData
{
    class Program
    {
        public static Context Context = new Context();

        async static Task Main(string[] args)
        {
            Context.Genres.RemoveRange(Context.Genres);
            Context.Movies.RemoveRange(Context.Movies);
            Context.MovieGenders.RemoveRange(Context.MovieGenders);

            var movie = Frame.ReadCsv(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.csv"))
                .IndexRows<int>("movieId");

            var year = movie.GetColumn<string>("title").Select(ParseYear);

            var splitedGenres = movie.GetColumn<string>("genres")
                .Select(pair => pair.Value.Split('|'));

            var genres = splitedGenres.Values.SelectMany(s => s).Distinct();

            await InsertGenres(genres);

            var rattings = Frame.ReadCsv(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ratings.csv"));

            rattings.DropColumn("userId");
            rattings.DropColumn("timestamp");

            var rating = rattings.GroupRowsBy<int>("movieId").GetColumn<double>("rating");

            var groupedRattings = rating.GroupBy(pair => pair.Key.Item1);
            var averages = groupedRattings.Select(pair => pair.Value.Mean());
            var averagesRounded = averages.Select(pair => Math.Round(pair.Value * 2, MidpointRounding.AwayFromZero) / 2);
            var final = movie.Join("rating", averagesRounded).Join("year", year);

            await InsertMovies(final);
        }
        
        private static int? ParseYear(KeyValuePair<int, string> pair)
        {
            var regex = @"\((\d+)\)";
            var m = Regex.Match(pair.Value, regex, RegexOptions.IgnoreCase).Value;
            var sNumber = Regex.Match(m, @"\d+", RegexOptions.IgnoreCase).Value;
            int? number = sNumber != "" ? Convert.ToInt32(sNumber) : null;
            return number;
        }

        private static async Task InsertMovies(Frame<int, string> final)
        {
            var result = final.Rows;
            
            var finalMoviesTasks = result.Select(series =>
            {
                var value = series.Value;
                return new Movie()
                {
                    Id = series.Key,
                    Title = value.GetAs<string>("title"),
                    Year = value.TryGetAs<int>("year").HasValue ? value.GetAs<int>("year") : null,
                    Rating = value.TryGetAs<float>("rating").HasValue ? value.GetAs<float>("rating") : null,
                    MovieGenders = GetGenders(value.GetAs<string>("genres")).Result
                };
            });

            await Context.AddRangeAsync(finalMoviesTasks.Values);
            await Context.SaveChangesAsync();
        }

        public static async Task<IList<MovieGender>> GetGenders(string genres)
        {
            var splited = genres.Split('|');
            var gens = await Context.Genres.Where(g => splited.Contains(g.Name)).ToListAsync();
            return gens.Select(g => new MovieGender() {GenderId = g.Id}).ToList();
        }

        public async static Task InsertGenres(IEnumerable<string> genres)
        {
            var genresEntities = genres.Select(g => new Gender() { Name = g });
            await Context.AddRangeAsync(genresEntities);
            await Context.SaveChangesAsync();
        }
    }
}