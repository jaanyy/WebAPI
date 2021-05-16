using FilmsProject.BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.BusinessLogicLayer.Interfaces
{
    public interface IParticipantService
    {
        Task<List<ParticipantDTO>> GetAllParticipantsAsync();
        Task<ParticipantDTO> GetParticipantByIdAsync(int id);
        Task<int> CreateParticipantAsync(ParticipantDTO participantDTO);
        Task UpdateParticipantAsync(ParticipantDTO participantDTO);
        Task DeleteParticipantAsync(int id);
    }
}
