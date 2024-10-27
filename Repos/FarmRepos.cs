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
    public class FarmRepos : IFarmRepos
    {
        private readonly KoiFarmManagementContext _context;

        public FarmRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Farm> Create(Farm data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Farm data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Farm>> GetAll()
        {
            var data = await _context.Farms.ToListAsync();
            return data;
        }

        public async Task<Farm> GetById(int id)
        {
            var data = await _context.Farms.SingleOrDefaultAsync(x => x.FarmId.Equals(id));
            return data;
        }

        public async Task<Farm> Update(Farm data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
