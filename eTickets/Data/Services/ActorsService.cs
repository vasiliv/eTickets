﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context= context;
        }
        public async Task Add(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            return await _context.Actors.ToListAsync();
        }

        public Actor GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new System.NotImplementedException();
        }
    }
}
