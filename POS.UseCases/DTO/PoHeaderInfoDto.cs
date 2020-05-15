﻿using System;
using System.Collections.Generic;
using System.Text;
using POS.Models.Enums;

namespace POS.UseCases.DTO
{
    public class PoHeaderInfoDto
    {
        public int Id { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public PoStatus Status { get; set; }

        public DateTime Date { get; set; }

        public string Code { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }
    }
}
