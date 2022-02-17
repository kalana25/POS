using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{

    public class ItemPricesWithDiscount
    {
        public IEnumerable<InventoryHeaderBase> Inventories { get; set; }

        public IEnumerable<DiscountInfoDto> AvailableDicounts { get; set; }
    }
}
