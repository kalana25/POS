using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class PurchaseOrderUpdateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Code { get; set; }

        public int UserId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public List<PurchaseOrderUpdateDetail> Items { get; set; }
        public List<int> DeleteItemIds { get; set; }

    }

    public class PurchaseOrderUpdateDetail
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
    }
}
