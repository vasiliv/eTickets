using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    //the "new()" constraint specifies that the type argument must have a public parameterless
    //constructor. This means that when you use this interface, the type argument must be a class that
    //implements the "IEntityBase" interface and also has a public parameterless constructor.
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }      

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query,(current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            //This creates a representation of the entity within the context, which allows the context
            //to track the entity and the changes made to it.
            EntityEntry entityEntry = _context.Entry<T>(entity);
            //This tells the context that the entity has been modified and should be updated in the
            //database when the context is saved.
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
