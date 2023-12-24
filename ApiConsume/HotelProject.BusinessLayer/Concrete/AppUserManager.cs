using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager:IAppUserService
    {
        private IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public int TAppUserCount()
        {
            return _appUserDal.AppUserCount();
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            var values = _appUserDal.GetList();

            return values;
        }

        public void TInsert(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUserDal.Update(t);
        }

        public List<UserListWorkLocationDto> TUserListWithLocation()
        {
            return _appUserDal.UserListWithLocation();
        }

        public List<AppUser> TUserListWithLocations()
        {
            return _appUserDal.UserListWithLocations();
        }
    }
}
