﻿using System;
using System.Collections.Generic;
using System.Text;
using POS.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int? ReferenceId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [Required]
        public PoStatus Status { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string CreatedByName { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PurchaseOrderDetail> Items { get; set; }
        public ICollection<GoodReceivedNote> Grns { get; set; }
    }
}
