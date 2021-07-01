using Domain.Entity;

namespace BusinessApi.Dto
{
    public class GenderDto
    {
        public GenderDto(Gender gender)
        {
            Id = gender.Id;
            Name = gender.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}