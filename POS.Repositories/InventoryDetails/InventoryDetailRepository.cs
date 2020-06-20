using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;
using POS.Core.General;

namespace POS.Repositories.InventoryDetails
{
    public class InventoryDetailRepository:Repository<InventoryDetail>,IInventoryDetailRepository
    {
        public InventoryDetailRepository(DataBaseContext context) : base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
