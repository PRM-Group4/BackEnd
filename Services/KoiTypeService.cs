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
    public class KoiTypeService : IKoiTypeService
    {
        private readonly IKoiTypeRepos _koiTypeRepos;
        private readonly IMapper _mapper;

        public KoiTypeService(IKoiTypeRepos koiTypeRepos, IMapper mapper)
        {
            _koiTypeRepos = koiTypeRepos;
            _mapper = mapper;
        }

        public async Task<KoiTypeRequest> Create(KoiTypeRequest data)
        {
            try
            {
                var map = _mapper.Map<KoiType>(data);
                var dataCreate = await _koiTypeRepos.Create(map);
                var resutl = _mapper.Map<KoiTypeRequest>(dataCreate);
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
                var data = await _koiTypeRepos.GetById(id);
                if (data == null)
                {
                    throw new Exception($"Data {id} does not exist");
                }

                await _koiTypeRepos.Delete(data);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<KoiTypeRequest>> GetAll()
        {
            try
            {

                var data = await _koiTypeRepos.GetAll();
                var map = _mapper.Map<List<KoiTypeRequest>>(data);
                return map;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<KoiType> GetById(int id)
        {
            var data = await _koiTypeRepos.GetById(id);
            return data;
        }


        public async Task<bool> Update(int id, KoiTypeRequest data)
        {
            try
            {
                var cate = await _koiTypeRepos.GetById(id);
                if (data == null)
                {
                    return false;
                }

                _mapper.Map(data, cate);
                await _koiTypeRepos.Update(cate);
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

