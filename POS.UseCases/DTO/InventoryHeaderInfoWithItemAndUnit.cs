using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class InventoryHeaderInfoWithItemAndUnit:InventoryHeaderBase
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }

        public ItemInfoDto Item { get; set; }
        public UnitInfoDto Unit { get; set; }
    }
}
