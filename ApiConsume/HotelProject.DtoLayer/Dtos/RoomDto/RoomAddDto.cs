using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage = "Add room number, please.")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Add price info,please.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Add title info,please.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Add bed count info,please.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Add bath count info,please.")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
