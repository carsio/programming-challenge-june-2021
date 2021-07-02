using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using BusinessApi.Dto;
using Domain.Entity;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Capiflix.Controllers
{
    [Route("api/genres")]
    public class GenderController: ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<IEnumerable<GenderDto>> GetAll() => await _genderService.GetAll();
    }
}