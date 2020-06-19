using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public float SellingPrice { get; set; }
        public float PurchasingPrice { get; set; }

        //Navigation Properties
        public Unit Unit { get; set; }
        public Inventory Inventory { get; set; }
        public GoodReceivedNote GoodReceivedNote { get; set; }


    }
}
