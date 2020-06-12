using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class ItemSaveDto
    {
        [MaxLength(100)]
        [Required]
        public string Code { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int ReOrderLevel { get; set; }

        public string Barcode { get; set; }

        public bool Active { get; set; }
    }
}
