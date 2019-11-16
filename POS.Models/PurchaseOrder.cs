using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
