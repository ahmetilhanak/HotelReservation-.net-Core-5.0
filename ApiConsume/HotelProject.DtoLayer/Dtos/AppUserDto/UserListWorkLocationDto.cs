using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.AppUserDto
{
    public class UserListWorkLocationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        public string WorkLocationName { get; set; }
    }
}
