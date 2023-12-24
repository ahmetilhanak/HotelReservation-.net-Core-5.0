using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Service icon link required!!!")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Service title required!!!")]
        [StringLength(100, ErrorMessage = "Only max 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Service description required!!!")]
        [StringLength(500, ErrorMessage = "Only max 500 characters")]
        public string Desciption { get; set; }
    }
}
