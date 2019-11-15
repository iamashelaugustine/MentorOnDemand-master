using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email_id { get; set; }

        [Required]
        public string Pass_word { get; set; }
    }
}
