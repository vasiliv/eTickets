﻿using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        //private readonly AppDbContext _context;
        //public CinemasController(AppDbContext context)
        //{
        //    _context = context;
        //}
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Cinemas.ToListAsync());
            return View(await _service.GetAllAsync());
        }
    }
}
