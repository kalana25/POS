using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.UseCases.DTO
{
    public class InventoryItemDto
    {
        public int ItemId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int ReOrderLevel { get; set; }

    }
}
