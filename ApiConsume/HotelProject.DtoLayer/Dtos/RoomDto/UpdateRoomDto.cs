using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Add room number, please.")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Add room cover image, please.")]
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Add price info,please.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Add title info,please.")]
        [StringLength(100, ErrorMessage ="Enter max 100 characters, please.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Add bed count info,please.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Add bath count info,please.")]
        public string BathCount { get; set; } 
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Add a description, please.")]
        public string Description { get; set; }
    }
}
