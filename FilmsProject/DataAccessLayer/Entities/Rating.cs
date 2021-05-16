using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Entities
{
    public class Rating
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public double Rate { get; set; }
    }
}
