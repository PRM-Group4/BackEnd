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
    public class UserRepos : IUserRepos
    {
        private readonly KoiFarmManagementContext _context;

        public UserRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(User data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }

        public async Task<User> GetById(int id)
        {
            var data = await _context.Users.SingleOrDefaultAsync(x => x.UserId.Equals(id));
            return data;
        }

        public async Task<User> Update(User data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}