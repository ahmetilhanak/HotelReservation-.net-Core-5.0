﻿using System;

namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class ApprovedBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string SpecialRequests { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}