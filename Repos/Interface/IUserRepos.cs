using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IUserRepos
    {
        public Task<List<User>> GetAll();
        public Task<User> Create(User data);
        public Task<User> Update(User data);
        public Task<bool> Delete(User data);

        public Task<User> GetById(int id);
    }
}
