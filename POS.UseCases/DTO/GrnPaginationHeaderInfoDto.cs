﻿using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnPaginationHeaderInfoDto :GrnHeaderBaseDto
    {
        public int Id { get; set; }
        public string PurchaseOrderCode { get; set; }
        public DateTime Time { get; set; }
        public string CreatedByName { get; set; }

    }
}
