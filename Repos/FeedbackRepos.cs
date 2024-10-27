using BOs.Models;
using Microsoft.EntityFrameworkCore;
using Repos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class FeedbackRepos : IFeedbackRepos
    {
        private readonly KoiFarmManagementContext _context;

        public FeedbackRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<Feedback> Create(Feedback data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Feedback data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Feedback>> GetAll()
        {
            var data = await _context.Feedbacks.ToListAsync();
            return data;
        }

        public async Task<Feedback> GetById(int id)
        {
            var data = await _context.Feedbacks.SingleOrDefaultAsync(x => x.FeedbackId.Equals(id));
            return data;
        }

        public async Task<Feedback> Update(Feedback data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
