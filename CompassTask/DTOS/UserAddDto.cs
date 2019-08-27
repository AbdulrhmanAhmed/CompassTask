using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompassTask.DTOS
{
    public class UserAddDto
    {
        
        [Required]
        public string  Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "You Should input Correct Format for Email")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
