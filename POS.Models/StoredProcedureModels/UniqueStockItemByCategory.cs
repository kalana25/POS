using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace POS.Models.StoredProcedureModels
{
    [NotMapped]
    public class UniqueStockItemByCategory
    {
        [Key]
        public int ItemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }

    }
}
