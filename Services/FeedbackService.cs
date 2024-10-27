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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepos _feedbackRepos;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepos feedbackRepos, IMapper mapper)
        {
            _feedbackRepos = feedbackRepos;
            _mapper = mapper;
        }

        public async Task<FeedbackRequest> Create(FeedbackRequest data)
        {
            try
            {
                var map = _mapper.Map<Feedback>(data);
                var dataCreate = await _feedbackRepos.Create(map);
                var resutl = _mapper.Map<FeedbackRequest>(dataCreate);
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
                var data = await _feedbackRepos.GetById(id);
                if (data == null)
                {
                    throw new Exception($"Data {id} does not exist");
                }

                await _feedbackRepos.Delete(data);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FeedbackRequest>> GetAll()
        {
            try
            {

                var data = await _feedbackRepos.GetAll();
                var map = _mapper.Map<List<FeedbackRequest>>(data);
                return map;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Feedback> GetById(int id)
        {
            var data = await _feedbackRepos.GetById(id);
            return data;
        }


        public async Task<bool> Update(int id, FeedbackRequest data)
        {
            try
            {
                var cate = await _feedbackRepos.GetById(id);
                if (data == null)
                {
                    return false;
                }

                _mapper.Map(data, cate);
                await _feedbackRepos.Update(cate);
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

