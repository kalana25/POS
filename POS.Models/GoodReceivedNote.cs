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

        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }

        [Required]
        public DateTime GrnDate { get; set; }

        public TimeSpan Time { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(250)]
        public int Comment { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string CreatedByName { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        public List<GoodReceivedNoteItem> Items { get; set; }
    }
}
