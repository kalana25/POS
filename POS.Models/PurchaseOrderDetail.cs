using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }

        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("Item")]
        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public bool IsBaseUnit { get; set; }


        public Unit Unit { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public Item Item { get; set; }
        public ICollection<GoodReceivedNoteItem> GoodReceivedNoteItems { get; set; }

    }
}
