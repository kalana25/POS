using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.UseCases.DTO
{
    public class InventoryHeaderBase
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int BaseUnitId { get; set; }
        public int ReOrderLevel { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPricePerBaseUnit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasingPricePerBaseUnit { get; set; }
    }
}
