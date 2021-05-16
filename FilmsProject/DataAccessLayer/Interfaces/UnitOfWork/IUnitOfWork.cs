using FilmsProject.DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get; }
        IParticipantRepository ParticipantRepository { get; }

        Task<int> Complete();
    }
}
