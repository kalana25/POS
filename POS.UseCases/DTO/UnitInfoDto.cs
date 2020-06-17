using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public abstract class UnitInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
