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
    public class RoleRepos : IRoleRepos
    {
        private readonly KoiFarmManagementContext _context;

        public RoleRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Role> Create(Role data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Role data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>> GetAll()
        {
            var data = await _context.Roles.ToListAsync();
            return data;
        }

        public async Task<Role> GetById(int id)
        {
            var data = await _context.Roles.SingleOrDefaultAsync(x => x.RoleId.Equals(id));
            return data;
        }

        public async Task<Role> Update(Role data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
