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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public bool CountryNameIsUnique(string countryName)
        {
            return unitOfWork.CountryRepository.CountryNameIsUnique(countryName);
        }

        public async Task<int> CreateCountryAsync(CountryDTO countryDTO)
        {
            var country = mapper.Map<Country>(countryDTO);
            return await unitOfWork.CountryRepository.AddAsync(country);
        }

        public async Task DeleteCountryAsync(int id)
        {
            await unitOfWork.CountryRepository.DeleteAsync(id);
        }

        public async Task<List<CountryDTO>> GetAllCountriesAsync()
        {
            var data = await unitOfWork.CountryRepository.GetAllAsync();

            return mapper.Map<List<CountryDTO>>(data);
        }

        public async Task<CountryDTO> GetCountryByIdAsync(int id)
        {
            var country = await unitOfWork.CountryRepository.GetAsync(id);

            return mapper.Map<CountryDTO>(country);
        }

        public async Task UpdateCountryAsync(CountryDTO countryDTO)
        {
            var country = mapper.Map<Country>(countryDTO);
            await unitOfWork.CountryRepository.UpdateAsync(country);
        }
    }
}
