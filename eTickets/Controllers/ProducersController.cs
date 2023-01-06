using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //Producer class contains also Id. we do not want it to bind
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]
        //id comes from request url
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await _service.UpdateAsync(id,producer);
                return RedirectToAction(nameof(Index));
            }
            //otherwise return same view
            return View(producer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]
        //We can not have 2 methods with same name and same argument
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
