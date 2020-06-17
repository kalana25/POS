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
        public int UnitId { get; set; }
        public bool IsBaseUnit { get; set; }
        public decimal UnitPrice { get; set; }

        public UnitInfoDto Unit { get; set; }
        public ItemInfoDto Item { get; set; }
    }
}
