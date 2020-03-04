using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class GoodReceivedNoteSaveDto
    {
        public int PurchaseOrderId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(250)]
        public int Comment { get; set; }

        [Required]
        public List<GoodReceivedNoteSaveDetail> Items { get; set; }
    }

    public class GoodReceivedNoteSaveDetail
    {
        public int GoodReceivedNoteId { get; set; }
        public int PurchaseOrderDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
