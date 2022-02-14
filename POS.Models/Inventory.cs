using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POS.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Unit")]
        public int BaseUnitId { get; set; }
        public int ReOrderLevel { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPricePerBaseUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasingPricePerBaseUnit { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }

        //Navigation Properties
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public ICollection<InventoryDetail> Details { get; set; }


    }
}
