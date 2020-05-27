using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;
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
    }
}
