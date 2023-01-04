using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
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

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);        

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            //This creates a representation of the entity within the context, which allows the context
            //to track the entity and the changes made to it.
            EntityEntry entityEntry = _context.Entry<T>(entity);
            //This tells the context that the entity has been modified and should be updated in the
            //database when the context is saved.
            entityEntry.State = EntityState.Modified;
        }
    }
}
