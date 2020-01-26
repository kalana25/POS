using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Code { get; set; }

        public int UserId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public ICollection<PurchaseOrderDetail> Items { get; set; }
    }
}
