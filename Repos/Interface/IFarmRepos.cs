using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IFarmRepos
    {
        public Task<List<Farm>> GetAll();
        public Task<Farm> Create(Farm data);
        public Task<Farm> Update(Farm data);
        public Task<bool> Delete(Farm data);

        public Task<Farm> GetById(int id);
    }
}
