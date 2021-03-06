﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.UseCases.DTO
{
    public class DiscountInfoDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Rate { get; set; }
        public string ItemName { get; set; }
    }
}
