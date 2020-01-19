using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class PurchaseOrderSaveDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Code { get; set; }

        public int UserId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public List<PurchaseOrderSaveDetail> Items { get; set; }
    }

    public class PurchaseOrderSaveDetail
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
    }
}
