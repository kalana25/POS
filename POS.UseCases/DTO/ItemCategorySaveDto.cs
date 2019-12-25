using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class ItemCategorySaveDto
    {
        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int ParentCategoryId { get; set; }

        public int? Level { get; set; }

        public bool Active { get; set; }
    }
}
