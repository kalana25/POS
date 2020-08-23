using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnWithFullInfoDto:GrnHeaderBaseDto
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public PoHeaderInfoDto PurchaseOrder { get; set; }

        public List<GrnItemFullInfoDto> Items { get; set; }
    }
}
