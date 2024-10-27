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
    public class ServiceRequestRepos : IServiceRequestRepos
    {
        private readonly KoiFarmManagementContext _context;

        public ServiceRequestRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<ServiceRequest> Create(ServiceRequest data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(ServiceRequest data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ServiceRequest>> GetAll()
        {
            var data = await _context.ServiceRequests.ToListAsync();
            return data;
        }

        public async Task<ServiceRequest> GetById(int id)
        {
            var data = await _context.ServiceRequests.SingleOrDefaultAsync(x => x.ServiceRequestId.Equals(id));
            return data;
        }

        public async Task<ServiceRequest> Update(ServiceRequest data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
