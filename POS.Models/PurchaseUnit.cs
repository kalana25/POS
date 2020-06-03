using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class PurchaseUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        public string Symbol { get; set; }

        [ForeignKey("BaseUnit")]
        public int BaseUnitId { get; set; }
        public int Quantity { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public BaseUnit BaseUnit { get; set; }


    }
}
