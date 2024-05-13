using ERequestTrackerDALLibrary;
using ERequestTrackerModelLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var reqSolution = await Get(key);
            if (reqSolution != null)
            {
                _context.Entry<RequestSolution>(reqSolution).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return reqSolution;
        }

        public async Task<RequestSolution> Get(int key)
        {
            var reqSolution = _context.RequestSolution.Include(rs=>rs.Feedbacks).SingleOrDefault(e => e.SolutionId == key);
            return reqSolution;
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolution.Include(rs=>rs.Feedbacks).ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            if (await Get(entity.SolutionId) != null)
            {
                _context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
