using eTickets.Data.Base;
using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        //replaced by generic repository - IEntityBaseRepository<Actor>
        //public interface IActorsService {
        //Task<IEnumerable<Actor>> GetAllAsync();
        //Task<Actor> GetByIdAsync(int id);
        //Task AddAsync(Actor actor);
        //Task<Actor> UpdateAsync(int id, Actor newActor);
        //Task DeleteAsync(int id);
        //}
    }
}
