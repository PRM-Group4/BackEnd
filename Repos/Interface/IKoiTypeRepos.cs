using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IKoiTypeRepos
    {
        public Task<List<KoiType>> GetAll();
        public Task<KoiType> Create(KoiType data);
        public Task<KoiType> Update(KoiType data);
        public Task<bool> Delete(KoiType data);

        public Task<KoiType> GetById(int id);
    }
}
