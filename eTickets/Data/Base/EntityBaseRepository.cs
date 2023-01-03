using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public async Task AddAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
