using FinTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace FinTech.Application.Repository
{    
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {      

        Task<IQueryable<TEntity>> GetAll();

        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression);

        Task CreateAsync(TEntity T);

        Task UpdateAsync(TEntity T);

        Task DeleteAsync(TPrimaryKey id);
  
        
    }
}
