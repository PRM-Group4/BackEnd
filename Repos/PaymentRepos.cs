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
    public class PaymentRepos : IPaymentRepos
    {
        private readonly KoiFarmManagementContext _context;

        public PaymentRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Payment> Create(Payment data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Payment data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Payment>> GetAll()
        {
            var data = await _context.Payments.ToListAsync();
            return data;
        }

        public async Task<Payment> GetById(int id)
        {
            var data = await _context.Payments.SingleOrDefaultAsync(x => x.PaymentId.Equals(id));
            return data;
        }

        public async Task<Payment> Update(Payment data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
