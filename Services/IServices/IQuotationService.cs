using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IQuotationService
    {
        public Task<List<QuotationRequest>> GetAll();
        public Task<QuotationRequest> Create(QuotationRequest data);
        Task<bool> Update(int id, QuotationRequest data);
        Task<bool> Delete(int id);
        Task<Quotation> GetById(int id);
    }
}
