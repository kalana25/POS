using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class BaseUnitFullInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }

        public IEnumerable<PurchaseUnitInfoDto> PurchaseUnits { get; set; }
    }
}
