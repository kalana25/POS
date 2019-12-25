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
        public string Code { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [ForeignKey("ItemCateogry")]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string Barcode { get; set; }

        public bool Active { get; set; }

        public ItemCategory ItemCateogry { get; set; }
    }
}
