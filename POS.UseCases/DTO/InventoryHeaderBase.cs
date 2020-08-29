using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class InventoryHeaderBase
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int BaseUnitId { get; set; }
        public int ReOrderLevel { get; set; }
    }
}
