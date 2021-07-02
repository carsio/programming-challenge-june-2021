using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessApi.Dto;
using Domain.Entity;
using Domain.Repositories.Interfaces;

namespace Business.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderDto>> GetAll();
    }
}