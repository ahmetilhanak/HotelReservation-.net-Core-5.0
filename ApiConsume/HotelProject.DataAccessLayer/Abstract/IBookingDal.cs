using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        int GetBookingCount();

        List<Booking> Last6Bookings();

        void BookingStatusChangeToApproved(Booking booking);

        void BookingStatusChangeToCancel(Booking booking);

        void BookingStatusChangeToHold(Booking booking);


    }
}
