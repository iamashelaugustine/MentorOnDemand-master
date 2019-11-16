using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string user_name { get; set; }
        [Required]
        public string email_id { get; set; }
        [Required]
        public string pass_word { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        public int Role { get; set; }
        public string status { get; set; }
    }
}
