using System.Collections.Generic;
using Domain.Entity;

namespace BusinessApi.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<Gender> Genres { get; set; }
    }
}