using FilmsProject.BusinessLogicLayer.DTOs;
using FilmsProject.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var result = await countryService.GetAllCountriesAsync();

            return result.Count == 0 ? NotFound() : Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryByIdAsync(int id)
        {
            var result = await countryService.GetCountryByIdAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountryAsync(CountryDTO countryDTO)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var id = await countryService.CreateCountryAsync(countryDTO);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountryAsync(CountryDTO countryDTO)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            await countryService.UpdateCountryAsync(countryDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            await countryService.DeleteCountryAsync(id);

            return Ok();
        }
    }
}
