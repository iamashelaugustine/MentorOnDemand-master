using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.AuthLibrary.Models
{
    public class Training
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TechnologyId { get; set; }
        [Required]
        public string TechnologyName { get; set; }
        [Required]
        public int CourseFee { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

    }
}
