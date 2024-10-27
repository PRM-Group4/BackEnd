using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IOrderRepos
    {
        public Task<List<Order>> GetAll();
        public Task<Order> Create(Order data);
        public Task<Order> Update(Order data);
        public Task<bool> Delete(Order data);

        public Task<Order> GetById(int id);
    }
}
