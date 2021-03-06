﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class PurchaseOrderSaveDto
    {
        [Required]
        public DateTime Date { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public int SupplierId { get; set; }

        [Required]
        public List<PurchaseOrderSaveDetail> Items { get; set; }
    }

    public class PurchaseOrderSaveDetail
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public bool IsBaseUnit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
