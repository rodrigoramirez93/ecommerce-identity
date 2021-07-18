using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Domain
{
    public class Repository<T> : IRepository<T>
        where T : Entity, IAuditable
    {
        internal DatabaseContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> Create(T entity)
        {
            await _context.AddAsync(entity);
            return entity.Id;
        }

        public async Task<T> ReadAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> UpdateAsync(string entityName, T entity)
        {
            var entityToUpdate = await _context.Set<T>().FindAsync(entity.Id);
            entityToUpdate.MustExist(entityName);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            return entity;
        }

        public async Task DeleteAsync(string entityName, int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Id == id);
            entity.MustExist(entityName, id);
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
