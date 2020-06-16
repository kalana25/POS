using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class BaseUnit:Unit
    {
        public string Description { get; set; }
        public ICollection<PurchaseUnit> PurchaseUnits { get; set; }

    }
}
