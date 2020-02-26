using Microsoft.EntityFrameworkCore;
using POS.DAL;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Repositories.Suppliers
{
    public class SupplierContactRepository : Repository<SupplierContact>, ISupplierContactRepository
    {
        public SupplierContactRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
