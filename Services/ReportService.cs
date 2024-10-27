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
    public class ReportService : IReportService

    {
        private readonly IReportRepos _repos;
        private readonly IMapper _mapper;

        public ReportService(IReportRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<ReportRequest> Create(ReportRequest data)
        {
            try
            {
                var map = _mapper.Map<Report>(data);
                var dataCreate = await _repos.Create(map);
                var resutl = _mapper.Map<ReportRequest>(dataCreate);
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
                var data = await _repos.GetById(id);
                if (data == null)
                {
                    throw new Exception($"Data {id} does not exist");
                }

                await _repos.Delete(data);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ReportRequest>> GetAll()
        {
            try
            {

                var data = await _repos.GetAll();
                var map = _mapper.Map<List<ReportRequest>>(data);
                return map;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Report> GetById(int id)
        {
            var data = await _repos.GetById(id);
            return data;
        }


        public async Task<bool> Update(int id, ReportRequest data)
        {
            try
            {
                var cate = await _repos.GetById(id);
                if (data == null)
                {
                    return false;
                }

                _mapper.Map(data, cate);
                await _repos.Update(cate);
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
