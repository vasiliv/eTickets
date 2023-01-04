using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    //public class ActorsService : IActorsService
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        //private readonly AppDbContext _context;
        //public ActorsService(AppDbContext context)
        //{
        //    _context= context;
        //}
        public ActorsService(AppDbContext context) : base(context) { }
        //implemented in generic repository
        //public async Task AddAsync(Actor actor)
        //{
        //    await _context.Actors.AddAsync(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        //    _context.Actors.Remove(actor);
        //    await _context.SaveChangesAsync();
        //}        
        //public async Task<IEnumerable<Actor>> GetAllAsync()
        //{
        //    return await _context.Actors.ToListAsync();
        //}

        //public async Task<Actor> GetByIdAsync(int id)
        //{
        //    return (await _context.Actors.FirstOrDefaultAsync(a => a.Id == id));
        //}

        //public async Task UpdateAsync(int id, Actor newActor)
        //{
        //    _context.Update(newActor);
        //    await _context.SaveChangesAsync();            
        //}
    }
}
