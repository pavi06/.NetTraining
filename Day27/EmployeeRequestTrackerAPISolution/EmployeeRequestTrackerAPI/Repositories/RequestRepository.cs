using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Entry<Request>(request).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<Request> Get(int key)
        {
            return _context.Requests.SingleOrDefault(r => r.RequestId == key);
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            if (await Get(entity.RequestId) != null)
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
