using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Rate { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Item { get; set; }

    }
}
