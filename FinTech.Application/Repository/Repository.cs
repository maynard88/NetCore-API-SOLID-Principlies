using FinTech.Core.Entities;
using FinTech.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinTech.Application.Repository
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {

        protected FinTechDbContext _context { get; set; }

        public Repository(FinTechDbContext finTechDbContext)
        {
            this._context = finTechDbContext;
        }

        // get all
        public async Task<IQueryable<TEntity>> GetAll()
        {
            await Task.CompletedTask;
            return this._context.Set<TEntity>().AsNoTracking();
            
        }
    
        // get all with filter
        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            await Task.CompletedTask;

            return this._context.Set<TEntity>()
                    .Where(expression).AsNoTracking();
        }

        // create
        public async Task CreateAsync(TEntity T)
        {
           await this._context.Set<TEntity>().AddAsync(T);
        }

        // update
        public async Task UpdateAsync(TEntity T)
        {
            await Task.CompletedTask;

            this._context.Set<TEntity>().Update(T);
        }

        // delete
        public async Task DeleteAsync(TPrimaryKey id)
        {
            
            this._context.Remove(
                (await this.GetAll(t => t.Id.Equals(id))).FirstOrDefault()
                );

            await Task.CompletedTask;
        }
        
    }
}
