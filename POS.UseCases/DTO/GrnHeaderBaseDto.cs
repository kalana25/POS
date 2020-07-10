using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnHeaderBaseDto
    {
        public string Code { get; set; }
        public DateTime GrnDate { get; set; }
        public string Comment { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
