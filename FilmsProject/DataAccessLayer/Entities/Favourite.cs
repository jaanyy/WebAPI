using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Entities
{
    public class Favourite
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Film Film { get; set; }
        public int FilmId { get; set; }
    }
}
