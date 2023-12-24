using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public int AppUserCount()
        {
            var context = new Context();
            var value = context.Users.Count();

            return value;
        }

        //public List<AppUser> UserListWithLocation()
        //{
        //    var context = new Context();
        //    var values = context.Users.Include(z => z.WorkLocation).ToList();
        //    return values;
        //}

        public List<UserListWorkLocationDto> UserListWithLocation()
        {
            var context = new Context();
            var values = context.Users.Include(z => z.WorkLocation).Select(y => new UserListWorkLocationDto()
            {
                Name = y.Name,
                Surname = y.Surname,
                City = y.City,
                Country = y.Country,
                Gender = y.Gender,
                ImageUrl = y.ImageUrl,
                Status = y.Status,
                WorkLocationName = y.WorkLocation.WorkLocationName
            }).ToList();  
            return values;
        }

        public List<AppUser> UserListWithLocations()
        {
            var context = new Context();
            var values = context.Users.Include(z => z.WorkLocation).ToList();
            return values;
        }

    }
}
