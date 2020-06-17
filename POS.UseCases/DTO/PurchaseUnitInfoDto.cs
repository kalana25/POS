using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class PurchaseUnitInfoDto:UnitInfoDto
    {
        public string Comment { get; set; }
        public string BaseUnitName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
