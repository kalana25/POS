﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class GoodReceivedNoteItem
    {
        public int Id { get; set; }

        [ForeignKey("GoodReceivedNote")]
        public int GoodReceivedNoteId { get; set; }

        [ForeignKey("PurchaseOrderDetail")]
        public int? PurchaseOrderDetailId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }

        public bool IsBaseUnit { get; set; }

        public DateTime? ExpireDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasingPrice { get; set; }

        public int ItemId { get; set; }



        public Unit Unit { get; set; }

        public GoodReceivedNote GoodReceivedNote { get; set; }

        public PurchaseOrderDetail PurchaseOrderDetail { get; set; }
    }
}
