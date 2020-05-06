using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class PoWithFullInfoDto:PoHeaderInfoDto
    {
        public IEnumerable<PoDetailInfoWithItemDto> Items { get; set; }
    }
}
