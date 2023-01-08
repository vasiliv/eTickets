using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context= context;
        }
        public async Task<Movie> GetMOvieById(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies)
                //because no direct access to actors
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return await movieDetails;
        }
    }
}
