using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IFeedbackService
    {
        public Task<List<FeedbackRequest>> GetAll();
        public Task<FeedbackRequest> Create(FeedbackRequest data);
        Task<bool> Update(int id, FeedbackRequest data);
        Task<bool> Delete(int id);
        Task<Feedback> GetById(int id);
    }
}
