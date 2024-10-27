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
    public class OrderRepos : IOrderRepos
    {
        private readonly KoiFarmManagementContext _context;

        public OrderRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Order> Create(Order data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Order data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetAll()
        {
            var data = await _context.Orders.ToListAsync();
            return data;
        }

        public async Task<Order> GetById(int id)
        {
            var data = await _context.Orders.SingleOrDefaultAsync(x => x.OrderId.Equals(id));
            return data;
        }

        public async Task<Order> Update(Order data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
