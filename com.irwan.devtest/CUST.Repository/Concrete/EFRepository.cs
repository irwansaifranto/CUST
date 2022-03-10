using CUST.Model;
using CUST.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CUST.Repository.Concrete
{
    public class EFRepository<T> : IAsyncRepository<T> where T : class
    {
        protected ApplicationDbContext Context;

        public EFRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<T> GetById(object id) => await Context.Set<T>().FindAsync(id);

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => await Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll() => await Context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate) => await Context.Set<T>().Where(predicate).ToListAsync();

        public async Task<int> CountAll() => await Context.Set<T>().CountAsync();

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate) => await Context.Set<T>().CountAsync(predicate);
    }
}
