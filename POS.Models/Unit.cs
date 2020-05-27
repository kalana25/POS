using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Symbol { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
