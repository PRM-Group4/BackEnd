using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ITripService
    {
        public Task<List<TripRequestDTO>> GetAll();
        public Task<TripRequestDTO> Create(TripRequestDTO data);
        Task<bool> Update(int id, TripRequestDTO data);
        Task<bool> Delete(int id);
        Task<Trip> GetById(int id);
    }
}
