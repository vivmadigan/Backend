using Business.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Contexts;

namespace Business.Repos
{
    public interface IBaseRepo<TEntity, TModel> where TEntity : class
    {
        Task AddAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(Expression<Func<TEntity, bool>> where);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TModel?> GetAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TModel>> GetAllAsync(
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? sortBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Returns projected results using a selector, allowing you to fetch only the fields you need.
        /// Supports filtering, sorting, and including navigation properties.
        /// </summary>
        Task<IEnumerable<TSelect>> GetAllAsync<TSelect>(
            Expression<Func<TEntity, TSelect>> selector,
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? sortBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[] includes);
    }

    public abstract class BaseRepo <TEntity, TModel> : IBaseRepo<TEntity, TModel> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMappingFactory<TEntity, TModel> _mappingFactory;

        protected BaseRepo(AppDbContext context, IMappingFactory<TEntity, TModel> mappingFactory)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mappingFactory = mappingFactory;

        }
        public virtual async Task AddAsync(TModel model)
        {
            var entity = _mappingFactory.MapToEntity(model);
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TModel model)
        { 
            var entity = _mappingFactory.MapToEntity(model);
             _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(where);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual async Task<TModel?> GetAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            var entity = await query.FirstOrDefaultAsync(where);
            return entity is null ? default : _mappingFactory.MapToModel(entity);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync(
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? sortBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
                query = query.Where(where);

            foreach (var include in includes)
                query = query.Include(include);

            if (sortBy != null)
                query = orderByDescending
                    ? query.OrderByDescending(sortBy)
                    : query.OrderBy(sortBy);

            var entities = await query.ToListAsync();
            return entities.Select(_mappingFactory.MapToModel);
        }
        /// <summary>
        /// Returns projected results using a selector, allowing you to fetch only the fields you need.
        /// Supports filtering, sorting, and including navigation properties.
        /// </summary>
        public virtual async Task<IEnumerable<TSelect>> GetAllAsync<TSelect>(
            Expression<Func<TEntity, TSelect>> selector,
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? sortBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[] includes)
        {
            // Start query from DbSet
            IQueryable<TEntity> query = _dbSet;

            // Apply optional filter
            if (where != null)
                query = query.Where(where);

            // Include navigation properties
            foreach (var include in includes)
                query = query.Include(include);

            // Apply optional sorting
            if (sortBy != null)
                query = orderByDescending
                    ? query.OrderByDescending(sortBy)
                    : query.OrderBy(sortBy);

            // Project only the fields defined by selector
            return await query.Select(selector).ToListAsync();
        }
    }
}
