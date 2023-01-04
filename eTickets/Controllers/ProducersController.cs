using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        //private readonly AppDbContext _context;
        //public ProducersController(AppDbContext context)
        //{
        //    _context= context;
        //}
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Producers.ToListAsync());
            return View(await _service.GetAllAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }
    }
}
