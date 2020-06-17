using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class PurchaseUnitFullInfoWithBaseUnitDto:UnitInfoDto
    {
        public string Comment { get; set; }
        public int BaseUnitId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public BaseUnitInfoDto BaseUnit { get; set; }
    }
}
