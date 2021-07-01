using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Gender
    {
        [Key, Required] public int Id { get; set; }
        public string Name { get; set; }
        public IList<MovieGender> MovieGenders { get; set; }
    }
}