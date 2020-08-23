using System;
using System.Collections.Generic;
using System.Text;
using POS.UseCases.DTO.Supplier;

namespace POS.UseCases.DTO
{
    public class PoWithFullInfoDto:PoHeaderInfoDto
    {
        public IEnumerable<PoDetailInfoWithItemAndUnitDto> Items { get; set; }
        public SupplierInfoDto Supplier { get; set; }
    }
}
