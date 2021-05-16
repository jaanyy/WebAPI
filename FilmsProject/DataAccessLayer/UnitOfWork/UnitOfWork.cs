using FilmsProject.DataAccessLayer.Context;
using FilmsProject.DataAccessLayer.Interfaces.Repositories;
using FilmsProject.DataAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly FilmsProjectDbContext context;
        public ICountryRepository CountryRepository { get; }
        public IParticipantRepository ParticipantRepository { get; }

        public UnitOfWork(FilmsProjectDbContext context, ICountryRepository countryRepository, IParticipantRepository participantRepository)
        {
            this.context = context;
            CountryRepository = countryRepository;
            ParticipantRepository = participantRepository;
        }

        //Dispose Pattern
        private bool disposed = false;

        public Task<int> Complete()
        {
            return context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
