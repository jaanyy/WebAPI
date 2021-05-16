using FilmsProject.DataAccessLayer.Context;
using FilmsProject.DataAccessLayer.Entities;
using FilmsProject.DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Repositories
{
    public class ParticipantRepository:SQLGenericRepository<Participant, int>, IParticipantRepository
    {
        public ParticipantRepository(FilmsProjectDbContext _context) : base(_context)
        {

        }
    }
}
