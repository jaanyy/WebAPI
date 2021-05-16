using FilmsProject.DataAccessLayer.Context;
using FilmsProject.DataAccessLayer.Entities;
using FilmsProject.DataAccessLayer.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Repositories
{
    public class CountryRepository : SQLGenericRepository<Country, int>, ICountryRepository
    {
        public CountryRepository(FilmsProjectDbContext _context) : base(_context)
        {
            
        }

        public bool CountryNameIsUnique(string countryName)
        {
            return !_dbSet.Any(c => c.Name == countryName);
        }
    }
}
