using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class ItemInfoDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int ReOrderLevel { get; set; }

        public string Barcode { get; set; }

        public bool Active { get; set; }

    }
}
