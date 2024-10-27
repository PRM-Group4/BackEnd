using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IOrderService
    {
        public Task<List<OrderRequest>> GetAll();
        public Task<OrderRequest> Create(OrderRequest data);
        Task<bool> Update(int id, OrderRequest data);
        Task<bool> Delete(int id);
        Task<Order> GetById(int id);
    }
}
