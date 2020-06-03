using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class PurchaseUnitFullInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Symbol { get; set; }
        public int BaseUnitId { get; set; }
        public int Quantity { get; set; }
    }
}
