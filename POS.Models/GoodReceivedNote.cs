using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class GoodReceivedNote
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }

        [Required]
        public DateTime GrnDate { get; set; }

        public DateTime Time { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string CreatedByName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        public ICollection<GoodReceivedNoteItem> Items { get; set; }
    }
}
