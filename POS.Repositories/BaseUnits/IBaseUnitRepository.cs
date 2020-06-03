using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;
namespace POS.Repositories.BaseUnits
{
    [AutoDIService]
    public interface IBaseUnitRepository:IRepository<BaseUnit>
    {
        Task<BaseUnit> GetBaseUnitWithPurchaseUnits(int id);
    }
}
