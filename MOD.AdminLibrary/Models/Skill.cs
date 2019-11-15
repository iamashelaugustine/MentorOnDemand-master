using MOD.AdminLibrary.Models;
using MOD.AuthLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.AdminLibrary.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Required]
        public MODUser AdminUser { get; set; } 
    }
}
