using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class DiscountSaveDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Rate { get; set; }
        public int ItemId { get; set; }
    }
}
