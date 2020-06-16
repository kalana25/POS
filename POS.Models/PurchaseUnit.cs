using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class PurchaseUnit:Unit
    {
        public string Comment { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("BaseUnit")]
        public int BaseUnitId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public BaseUnit BaseUnit { get; set; }
        public Item Item { get; set; }


    }
}
