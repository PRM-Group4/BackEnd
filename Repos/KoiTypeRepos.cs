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
    public class KoiTypeRepos : IKoiTypeRepos
    {
        private readonly KoiFarmManagementContext _context;

        public KoiTypeRepos(KoiFarmManagementContext context)
        {
            _context = context;
        }
        public async Task<KoiType> Create(KoiType data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(KoiType data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<KoiType>> GetAll()
        {
            var data = await _context.KoiTypes.ToListAsync();
            return data;
        }

        public async Task<KoiType> GetById(int id)
        {
            var data = await _context.KoiTypes.SingleOrDefaultAsync(x => x.KoiTypeId.Equals(id));
            return data;
        }

        public async Task<KoiType> Update(KoiType data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
