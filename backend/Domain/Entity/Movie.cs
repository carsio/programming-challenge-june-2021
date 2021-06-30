using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Movie
    {
        [Key, Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public IList<Gender> Genres { get; set; }
    }
}