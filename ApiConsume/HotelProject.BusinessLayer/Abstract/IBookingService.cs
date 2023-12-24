using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        int TGetBookingCount();

        List<Booking> TLast6Bookings();

        void TBookingStatusChangeToApproved(Booking booking);

        void TBookingStatusChangeToCancel(Booking booking);

        void TBookingStatusChangeToHold(Booking booking);
    }
}
