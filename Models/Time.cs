using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Time
    {
        [Required]
        public string LocalTime { get; set; }
        [Required]
        public string TimeZone { get; set; }
    }
}
