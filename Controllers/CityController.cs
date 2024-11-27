using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;

namespace refund.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
            private readonly ICity _city;
        public CityController(ICity city)
        {
            _city = city;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CityDto cityDto)
        {
            return Ok(await _city.Create(cityDto));
        }
          [AllowAnonymous]
        [HttpGet("GetAll")]
       
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _city.GetAll());
        }
          [AllowAnonymous]
         [HttpGet("GetbyId")]
        public async Task<IActionResult> GetbyId(int CityId)
        {
            return Ok(await _city.GetbyId(CityId));
        }
          [AllowAnonymous]
          [HttpGet("GetCitiesbyStateId")]
        public async Task<IActionResult> GetCitiesbyStateId(int StateId)
        {
            return Ok(await _city.GetAllCitybyId(StateId));
        }
    }
}