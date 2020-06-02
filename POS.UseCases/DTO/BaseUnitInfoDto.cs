using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class BaseUnitInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
    }
}
