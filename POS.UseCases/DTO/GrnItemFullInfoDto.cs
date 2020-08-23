using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnItemFullInfoDto:GrnItemBaseDto
    {
        public int Id { get; set; }
        public PoDetailInfoWithItemDto PurchaseOrderDetail { get; set; }
        public UnitInfoDto Unit { get; set; }
    }
}
