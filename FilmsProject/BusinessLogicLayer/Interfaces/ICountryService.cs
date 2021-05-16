using FilmsProject.BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.BusinessLogicLayer.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO> GetCountryByIdAsync(int id);
        Task<int> CreateCountryAsync(CountryDTO countryDTO);
        Task UpdateCountryAsync(CountryDTO countryDTO);
        Task DeleteCountryAsync(int id);
        bool CountryNameIsUnique(string countryName);
    }
}
