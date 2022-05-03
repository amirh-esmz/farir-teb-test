
using Domain.Repositories.Base;

namespace Application.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : class 
    {
        protected readonly DataBaseContext dbContext;

        public GenericRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;

            DbSet = dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> DbSet { get; private set; }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>>? condition = null)
        {
            var query = DbSet.AsQueryable();

            if (condition != null)
                query = DbSet.Where(condition);

            return query.LongCountAsync();
        }

        public virtual void Add(TEntity entity)
        {
            var task = AddAsync(entity);
            task.Wait();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            DeleteAsync(entity).Wait();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return dbContext.SaveChangesAsync();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? condition = null, params string[] includes)
        {
            var task = GetAllAsync(condition, includes);
            task.Wait();

            return task.Result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? condition = null, params string[] includes)
        {
            var query = DbSet.AsQueryable();

            if (condition != null)
                query = DbSet.Where(condition);

            foreach (var item in includes)
                query = query.Include(item);

            return await query.ToListAsync();
        }

        public virtual TEntity? GetOne(Expression<Func<TEntity, bool>>? condition = null, params string[] includes)
        {
            var task = GetOneAsync(condition, includes);
            task.Wait();

            return task.Result;
        }

        public virtual Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? condition = null, params string[] includes)
        {
            var query = DbSet.AsQueryable();

            if (condition != null)
                query = DbSet.Where(condition);

            foreach (var item in includes)
                query = query.Include(item);

            return query.FirstOrDefaultAsync();
        }

        public virtual void Update(TEntity entity)
        {
            var task = UpdateAsync(entity);
            task.Wait();
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }
    }

}
