using FilmsProject.DataAccessLayer.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Entities
{
    public class Film: IEntity<int>
    {
        public int Id { get; set; }
        public string NameOriginal { get; set; }
        public string NameUkrainian { get; set; }
        public int ReleaseYear { get; set; }
        public int LengthInMinutes { get; set; }
        public string Description { get; set; }

        public int ProducerId { get; set; }
        public Participant Producer { get; set; }

        public ICollection<Participant> Actors { get; set; }
        
        public ICollection<Genre> Genres { get; set; }
        
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
}
