using FilmsProject.DataAccessLayer.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Entities
{
    public class Participant: IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public bool IsActor { get; set; }
        public bool IsProducer { get; set; }

        public ICollection<Film> FilmsAsActor { get; set; }

        public ICollection<Film> ProducedFilms { get; set; }
        
    }
}
