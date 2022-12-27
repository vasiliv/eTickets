﻿using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            return View(_context.Actors.ToList());
        }
    }
}
