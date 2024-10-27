using BOs.Models;
using Microsoft.EntityFrameworkCore;
using Repos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class TripRepos : ITripRepos
    {
        private readonly KoiFarmManagementContext _context;

        public TripRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Trip> Create(Trip data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Trip data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Trip>> GetAll()
        {
            var data = await _context.Trips.ToListAsync();
            return data;
        }

        public async Task<Trip> GetById(int id)
        {
            var data = await _context.Trips.SingleOrDefaultAsync(x => x.TripId.Equals(id));
            return data;
        }

        public async Task<Trip> Update(Trip data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
