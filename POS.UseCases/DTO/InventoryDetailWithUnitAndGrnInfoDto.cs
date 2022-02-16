using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.UseCases.DTO
{
    public class InventoryDetailWithUnitAndGrnInfoDto
    {
        public int Id { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime StockInDate { get; set; }
        public int Quantity { get; set; }
        public int OpenBalanceQuantity { get; set; }
        public bool IsBaseUnit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasingPrice { get; set; }

        public UnitInfoDto Unit { get; set; }
        public GrnHeaderInfoDto GoodReceivedNote { get; set; }
    }
}
