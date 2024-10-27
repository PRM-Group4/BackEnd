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
    public class ReportRepos : IReportRepos
    {
        private readonly KoiFarmManagementContext _context;

        public ReportRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Report> Create(Report data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Report data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Report>> GetAll()
        {
            var data = await _context.Reports.ToListAsync();
            return data;
        }

        public async Task<Report> GetById(int id)
        {
            var data = await _context.Reports.SingleOrDefaultAsync(x => x.ReportId.Equals(id));
            return data;
        }

        public async Task<Report> Update(Report data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
