using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
    }
}
