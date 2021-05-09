using System.ComponentModel.DataAnnotations;

namespace GSCS_Cameras_API.Data
{
    public class Camera
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="You must input a name for a camera.")]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public CameraModel Model { get; set; }
        [Required]
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}