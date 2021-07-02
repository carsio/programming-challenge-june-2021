using System.Collections.Generic;
using System.Linq;
using Domain.Entity;

namespace BusinessApi.Dto
{
    public class MovieDto
    {
        public MovieDto(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Year = movie.Year;
            Rating = movie.Rating;
            Genres = movie.MovieGenders.Select(mg => new GenderDto(mg.Gender)).ToList();
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public float? Rating { get; set; }
        public List<GenderDto> Genres { get; set; }
    }
}