using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnItemBaseDto
    {
        public int Quantity { get; set; }
        public bool IsBaseUnit { get; set; }
        public DateTime? ExpireDate { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasingPrice { get; set; }
        public int ItemId { get; set; }
    }
}
