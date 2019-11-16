using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentCategoryId { get; set; }
        public int? Level { get; set; }
    }
}
