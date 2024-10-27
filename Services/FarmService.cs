using AutoMapper;
using BOs.Models;
using Repos.Interface;
using Services.IServices;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepos _farmRepos;
        private readonly IMapper _mapper;

        public FarmService(IFarmRepos farmRepos, IMapper mapper)
        {
            _farmRepos = farmRepos;
            _mapper = mapper;
        }

        public async Task<FarmRequest> Create(FarmRequest data)
        {
            try
            {
                var map = _mapper.Map<Farm>(data);
                var dataCreate = await _farmRepos.Create(map);
                var resutl = _mapper.Map<FarmRequest>(dataCreate);
                return resutl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var data = await _farmRepos.GetById(id);
                if (data == null)
                {
                    throw new Exception($"Data {id} does not exist");
                }

                await _farmRepos.Delete(data);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FarmRequest>> GetAll()
        {
            try
            {

                var data = await _farmRepos.GetAll();
                var map = _mapper.Map<List<FarmRequest>>(data);
                return map;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Farm> GetById(int id)
        {
            var data = await _farmRepos.GetById(id);
            return data;
        }


        public async Task<bool> Update(int id, FarmRequest data)
        {
            try
            {
                var cate = await _farmRepos.GetById(id);
                if (data == null)
                {
                    return false;
                }

                _mapper.Map(data, cate);
                await _farmRepos.Update(cate);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Fail to update info {ex.Message}");
                return false;
            }
        }

    }
}
