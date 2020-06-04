using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class PurchaseUnitInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Symbol { get; set; }
        public string BaseUnitName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
