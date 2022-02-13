using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using System.Linq;
using POS.Core.DI;

namespace POS.Repositories.OrderDetails
{
    [AutoDIService]
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
    }
}
