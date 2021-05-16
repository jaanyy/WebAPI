using AutoMapper;
using FilmsProject.BusinessLogicLayer.DTOs;
using FilmsProject.BusinessLogicLayer.Interfaces;
using FilmsProject.DataAccessLayer.Entities;
using FilmsProject.DataAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.BusinessLogicLayer.Services
{
    public class ParticipantService:IParticipantService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ParticipantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<int> CreateParticipantAsync(ParticipantDTO countryDTO)
        {
            var country = mapper.Map<Participant>(countryDTO);
            return await unitOfWork.ParticipantRepository.AddAsync(country);
        }

        public async Task DeleteParticipantAsync(int id)
        {
            await unitOfWork.ParticipantRepository.DeleteAsync(id);
        }

        public async Task<List<ParticipantDTO>> GetAllParticipantsAsync()
        {
            var data = await unitOfWork.ParticipantRepository.GetAllAsync();

            return mapper.Map<List<ParticipantDTO>>(data);
        }

        public async Task<ParticipantDTO> GetParticipantByIdAsync(int id)
        {
            var country = await unitOfWork.ParticipantRepository.GetAsync(id);

            return mapper.Map<ParticipantDTO>(country);
        }

        public async Task UpdateParticipantAsync(ParticipantDTO countryDTO)
        {
            var country = mapper.Map<Participant>(countryDTO);
            await unitOfWork.ParticipantRepository.UpdateAsync(country);
        }
    }
}
