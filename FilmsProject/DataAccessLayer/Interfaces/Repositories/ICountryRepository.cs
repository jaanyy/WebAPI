using FilmsProject.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Interfaces.Repositories
{
    public interface ICountryRepository: IGenericRepository<Country, int>
    {
        bool CountryNameIsUnique(string countryName);
    }
}
