using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IPaymentRepos
    {
        public Task<List<Payment>> GetAll();
        public Task<Payment> Create(Payment data);
        public Task<Payment> Update(Payment data);
        public Task<bool> Delete(Payment data);

        public Task<Payment> GetById(int id);
    }
}
