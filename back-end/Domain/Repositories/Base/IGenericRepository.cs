using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? condition = null, params string[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? condition = null, params string[] includes);

        TEntity? GetOne(Expression<Func<TEntity, bool>>? condition = null, params string[] includes);
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? condition = null, params string[] includes);

        void Add(TEntity model);
        Task AddAsync(TEntity model);

        void Update(TEntity model);
        Task UpdateAsync(TEntity model);

        void Delete(TEntity model);
        Task DeleteAsync(TEntity model);

        Task<long> CountAsync(Expression<Func<TEntity, bool>>? condition = null);
    }

}
