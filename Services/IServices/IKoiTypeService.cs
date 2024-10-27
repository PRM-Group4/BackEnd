using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IKoiTypeService
    {
        public Task<List<KoiTypeRequest>> GetAll();
        public Task<KoiTypeRequest> Create(KoiTypeRequest data);
        Task<bool> Update(int id, KoiTypeRequest data);
        Task<bool> Delete(int id);
        Task<KoiType> GetById(int id);
    }
}
