using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IQuotationRepos
    {
        public Task<List<Quotation>> GetAll();
        public Task<Quotation> Create(Quotation data);
        public Task<Quotation> Update(Quotation data);
        public Task<bool> Delete(Quotation data);

        public Task<Quotation> GetById(int id);
    }
}
