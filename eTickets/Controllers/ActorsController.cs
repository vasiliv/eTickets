using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        //private readonly AppDbContext _context;
        //public ActorsController(AppDbContext context)
        //{
        //    _context= context;
        //}
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            //return View(_context.Actors.ToList());
            return View(await _service.GetAll());
        }
    }
}
