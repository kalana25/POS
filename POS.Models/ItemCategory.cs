using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Code { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int ParentCategoryId { get; set; }

        public int? Level { get; set; }

        public bool Active { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
