using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly AppDbContext _context;
        //public MoviesController(AppDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Movies.Include(m => m.Cinema).OrderBy(m => m.Name).ToListAsync());
            //we use overloaded version of GetAllAsync of EntityBaseRepository
            return View(await _service.GetAllAsync(m => m.Cinema));
        }
    }
}
