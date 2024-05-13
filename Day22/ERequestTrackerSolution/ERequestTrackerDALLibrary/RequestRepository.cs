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
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            try
            {
                _context.Requests.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
            catch(OperationCanceledException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            } 
            catch(Exception e) {
                await Console.Out.WriteLineAsync(e.Message);
            }
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
            return _context.Requests.Include(r=>r.RequestSolutions).SingleOrDefault(r => r.RequestNumber == key);
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.Include(r=>r.RequestSolutions).ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            if (await Get(entity.RequestNumber) != null)
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
