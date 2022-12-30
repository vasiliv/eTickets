using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
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
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        //Actor class contains also Id. we do not want it to bind
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
