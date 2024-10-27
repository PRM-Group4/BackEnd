using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IRoleService
    {
        public Task<List<RoleRequest>> GetAll();
        public Task<RoleRequest> Create(RoleRequest data);
        Task<bool> Update(int id, RoleRequest data);
        Task<bool> Delete(int id);
        Task<Role> GetById(int id);
    }
}
