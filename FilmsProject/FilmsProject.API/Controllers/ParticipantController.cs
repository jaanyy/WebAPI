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
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService participantService;

        public ParticipantController(IParticipantService participantService)
        {
            this.participantService = participantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParticipantsAsync()
        {
            var result = await participantService.GetAllParticipantsAsync();

            return result.Count == 0 ? NotFound() : Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantByIdAsync(int id)
        {
            var result = await participantService.GetParticipantByIdAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipantAsync(ParticipantDTO participantDTO)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var id = await participantService.CreateParticipantAsync(participantDTO);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateParticipantAsync(ParticipantDTO participantDTO)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            await participantService.UpdateParticipantAsync(participantDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantAsync(int id)
        {
            await participantService.DeleteParticipantAsync(id);

            return Ok();
        }
    }
}
