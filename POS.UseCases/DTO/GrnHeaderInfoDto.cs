using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnHeaderInfoDto
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int UserId { get; set; }
        public int Comment { get; set; }
    }
}
