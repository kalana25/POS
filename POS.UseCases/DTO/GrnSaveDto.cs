using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class GrnSaveDto: GrnHeaderBaseDto
    {
        [Required]
        public int PurchaseOrderId { get; set; }
        [Required]
        public List<GrnSaveDetail> Items { get; set; }
    }

    public class GrnSaveDetail
    {
        public int PurchaseOrderDetailId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal SellingPrice { get; set; }
        public bool IsBaseUnit { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}