using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IServiceRequestRepos
    {
        public Task<List<ServiceRequest>> GetAll();
        public Task<ServiceRequest> Create(ServiceRequest data);
        public Task<ServiceRequest> Update(ServiceRequest data);
        public Task<bool> Delete(ServiceRequest data);

        public Task<ServiceRequest> GetById(int id);
    }
}
