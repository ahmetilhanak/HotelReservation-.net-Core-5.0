using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeToApproved(Booking booking)
        {
            var context = new Context();
            //var values = context.Bookings.Find(booking.BookingID);
            booking.Status = "Confirmed";
            context.Update(booking);
            context.SaveChanges();
        }

        public void BookingStatusChangeToCancel(Booking booking)
        {
            var context = new Context();
            //var values = context.Bookings.Find(booking.BookingID);
            booking.Status = "Cancelled";
            context.Update(booking);
            context.SaveChanges();
        }

        public void BookingStatusChangeToHold(Booking booking)
        {
            var context = new Context();
            //var values = context.Bookings.Find(booking.BookingID);
            booking.Status = "On Hold";
            context.Update(booking);
            context.SaveChanges();
        }

        public int GetBookingCount()
        {

            var context = new Context();
            var value = context.Bookings.Count();

            return value;
        }

        public List<Booking> Last6Bookings()
        {
            var context = new Context();
            var value = context.Bookings.OrderByDescending(z => z.BookingID).Take(6).ToList();

            return value;
        }
    }


}
