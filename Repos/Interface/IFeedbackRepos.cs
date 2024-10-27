using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IFeedbackRepos
    {
        public Task<List<Feedback>> GetAll();
        public Task<Feedback> Create(Feedback data);
        public Task<Feedback> Update(Feedback data);
        public Task<bool> Delete(Feedback data);

        public Task<Feedback> GetById(int id);
    }
}
