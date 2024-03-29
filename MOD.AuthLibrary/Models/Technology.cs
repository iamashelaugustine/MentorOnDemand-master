﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.AuthLibrary.Models
{
    public class Technology
    {
        public int Id { get; set; }
        [Required]
        public string TechnologyName { get; set; }       
        [Required]
        public string Commission { get; set; }
    }
}
