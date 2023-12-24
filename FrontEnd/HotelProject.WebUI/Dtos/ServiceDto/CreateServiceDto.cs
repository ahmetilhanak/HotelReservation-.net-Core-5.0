using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Service icon link required!!!")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Service title required!!!")]
        [StringLength(100,ErrorMessage ="Only max 100 characters")]
        public string Title { get; set; }
        public string Desciption { get; set; }
    }
}
