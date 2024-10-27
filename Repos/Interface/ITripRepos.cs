using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface ITripRepos
    {
        public Task<List<Trip>> GetAll();
        public Task<Trip> Create(Trip data);
        public Task<Trip> Update(Trip data);
        public Task<bool> Delete(Trip data);

        public Task<Trip> GetById(int id);
    }
}
