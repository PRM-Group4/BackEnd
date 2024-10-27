using BOs.Models;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IReportService
    {
        public Task<List<ReportRequest>> GetAll();
        public Task<ReportRequest> Create(ReportRequest data);
        Task<bool> Update(int id, ReportRequest data);
        Task<bool> Delete(int id);
        Task<Report> GetById(int id);
    }
}
