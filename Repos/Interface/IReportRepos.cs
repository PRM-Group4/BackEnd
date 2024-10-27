using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Interface
{
    public interface IReportRepos
    {
        public Task<List<Report>> GetAll();
        public Task<Report> Create(Report data);
        public Task<Report> Update(Report data);
        public Task<bool> Delete(Report data);

        public Task<Report> GetById(int id);
    }
}
