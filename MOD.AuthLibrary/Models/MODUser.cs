using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.AuthLibrary.Models
{
    public class MODUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Status { get; set; }
    }
}
