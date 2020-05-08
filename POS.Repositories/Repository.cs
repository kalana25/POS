using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using POS.Core.General;
using Microsoft.EntityFrameworkCore;

namespace POS.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }




        public async Task<TEntity> Get(int id)
        {
            return await this.context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<ResponseData<TEntity>> GetPagination(RequestData requestData)
        {
            int count = await Count();
            IEnumerable<TEntity> items = await this.context.Set<TEntity>()
                .Skip((requestData.Page-1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<TEntity>(requestData.Page, requestData.PageSize, count, items);
        }

        public async Task<int> Count()
        {
            return await this.context.Set<TEntity>().CountAsync();
        }



        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().AddRange(entities);
        }




        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
