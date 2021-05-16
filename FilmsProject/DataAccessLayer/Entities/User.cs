using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
}
