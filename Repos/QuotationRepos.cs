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
    public class QuotationRepos : IQuotationRepos
    {
        private readonly KoiFarmManagementContext _context;

        public QuotationRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Quotation> Create(Quotation data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Quotation data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Quotation>> GetAll()
        {
            var data = await _context.Quotations.ToListAsync();
            return data;
        }

        public async Task<Quotation> GetById(int id)
        {
            var data = await _context.Quotations.SingleOrDefaultAsync(x => x.QuotationId.Equals(id));
            return data;
        }

        public async Task<Quotation> Update(Quotation data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
