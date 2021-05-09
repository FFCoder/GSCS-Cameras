using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSCS_Cameras_API.Data
{
    public class School
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="School Name is Required")]
        public string Name { get; set; }
    }
}
