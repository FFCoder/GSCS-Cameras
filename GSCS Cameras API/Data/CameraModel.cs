using System.ComponentModel.DataAnnotations;

namespace GSCS_Cameras_API.Data
{
    public class CameraModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="A Name is Required.")]
        [MaxLength(128)]
        public string Name { get; set; }
        public string DefaultUsername { get; set; }
        public string DefaultPassword { get; set; }
        [Required(ErrorMessage="This system requires a way to access a static image of the camera. IE /cgi-bin/camera")]
        public string StaticImageURL { get; set; }
        public string OpenLensURL { get; set; }
        public string CloseLensURL { get; set; }
    }
}