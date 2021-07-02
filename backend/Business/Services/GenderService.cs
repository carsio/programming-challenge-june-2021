using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;
using Domain.Entity;
using Domain.Repositories.Interfaces;

namespace Business.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public async Task<IEnumerable<GenderDto>> GetAll()
        {
            var genres = await _genderRepository.GetAll();
            return ParseGenresToDto(genres.OrderBy(g=>g.Name));
        }

        private IEnumerable<GenderDto> ParseGenresToDto(IEnumerable<Gender> genres) =>
            genres.Select(g => new GenderDto(g));
    }
}