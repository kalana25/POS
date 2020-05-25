using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(10)]
        public string ContactNo { get; set; }

        [MaxLength(10)]
        public string Telephone { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        public bool BlackList { get; set; }

        public bool Active { get; set; }


        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }
    }
}
