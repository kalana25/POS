using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Models
{
    public class InventoryDetail
    {
        public int Id { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }

        [ForeignKey("GoodReceivedNote")]
        public int GrnId { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime StockInDate { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public bool IsBaseUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasingPrice { get; set; }

        //Navigation Properties
        public Unit Unit { get; set; }
        public Inventory Inventory { get; set; }
        public GoodReceivedNote GoodReceivedNote { get; set; }


    }
}
