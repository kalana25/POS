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

        public ItemInfoDto Item { get; set; }
    }
}
