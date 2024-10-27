using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IFarmService
    {
        public Task<List<FarmRequest>> GetAll();
        public Task<FarmRequest> Create(FarmRequest data);
        Task<bool> Update(int id, FarmRequest data);
        Task<bool> Delete(int id);
        Task<Farm> GetById(int id);
    }
}
