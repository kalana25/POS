﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Code { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("ItemCateogry")]
        [Required]
        public int CategoryId { get; set; }

        public int ReOrderLevel { get; set; }

        public string Barcode { get; set; }

        public bool Active { get; set; }

        public ItemCategory ItemCateogry { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<PurchaseUnit> PurchaseUnits { get; set; }
        public ICollection<OrderDetail> OrderedItems { get; set; }
    }
}
