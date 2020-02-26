using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int GrnId { get; set; }
        public int Quantity { get; set; }
        public int Date { get; set; }
        public float SellingPrice { get; set; }

    }
}
