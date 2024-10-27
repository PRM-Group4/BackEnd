using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICRUDUserService
    {
        public Task<List<UserRequest>> GetAll();
        public Task<UserRequest> Create(UserRequest data);
        Task<bool> Update(int id, UserRequest data);
        Task<bool> Delete(int id);
        Task<User> GetById(int id);
    }
}
