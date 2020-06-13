using POS.UseCases.DTO.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class PoDetailInfoWithItemDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public decimal UnitPrice { get; set; }

        public ItemInfoDto Item { get; set; }
    }
}
