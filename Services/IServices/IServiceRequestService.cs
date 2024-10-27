using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IServiceRequestService
    {
        public Task<List<ServiceRequestDTO>> GetAll();
        public Task<ServiceRequestDTO> Create(ServiceRequestDTO data);
        Task<bool> Update(int id, ServiceRequestDTO data);
        Task<bool> Delete(int id);
        Task<ServiceRequest> GetById(int id);
    }
}
