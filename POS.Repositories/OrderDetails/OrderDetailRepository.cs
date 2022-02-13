using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Core.General;
using POS.Models;
using POS.Models.Enums;

namespace POS.Repositories.OrderDetails
{
    public class OrderDetailRepository:Repository<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(DataBaseContext context):base(context)
        {

        }
    }
}
