using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;
using POS.Core.General;
using System.Net.Mime;

namespace POS.Repositories.Discounts
{
    public class DiscountRepository:Repository<Discount>,IDiscountRepository
    {
        public DiscountRepository(DataBaseContext context):base(context)
        {

        }



        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }

        public override async Task<ResponseData<Discount>> GetPagination(IRequestData requestData)
        {
            int count = await DatabaseContext.Discounts.CountAsync();
            IEnumerable<Discount> items = await DatabaseContext.Discounts
                .Include(d=>d.Item)
                .Skip((requestData.Page - 1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<Discount>(requestData.Page, requestData.PageSize, count, items);
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountWithItem()
        {
            return await DatabaseContext.Discounts.Include(d => d.Item).ToListAsync();
        }

        public async Task<Discount> GetDiscountWithItem(int id)
        {
            return await DatabaseContext.Discounts.Include(d => d.Item).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetLastDiscountId()
        {
            return await DatabaseContext.Discounts.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
