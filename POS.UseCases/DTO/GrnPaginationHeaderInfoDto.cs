using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnPaginationHeaderInfoDto:GrnHeaderBaseDto
    {
        public int PurchaseOrderCode { get; set; }
        public string CreatedByName { get; set; }
    }
}
