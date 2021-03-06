﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class InventoryHeaderWithFullInfoDto:InventoryHeaderBaseDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }

        public ItemInfoDto Item { get; set; }
        public UnitInfoDto Unit { get; set; }

        public List<InventoryDetailWithUnitAndGrnInfoDto> Details { get; set; }
    }
}
