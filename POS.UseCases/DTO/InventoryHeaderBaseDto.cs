﻿using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class InventoryHeaderBaseDto
    {
        public int Quantity { get; set; }
        public int BaseUnitId { get; set; }
        public int ReOrderLevel { get; set; }
    }
}
