using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IPaymentService
    {
        public Task<List<PaymentRequest>> GetAll();
        public Task<PaymentRequest> Create(PaymentRequest data);
        Task<bool> Update(int id, PaymentRequest data);
        Task<bool> Delete(int id);
        Task<Payment> GetById(int id);
    }
}
