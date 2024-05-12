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
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;

        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            var solFeedback = await Get(key);
            if (solFeedback != null)
            {
                _context.Entry<SolutionFeedback>(solFeedback).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return solFeedback;
        }

        public async Task<SolutionFeedback> Get(int key)
        {
            var solFeedback = _context.SolutionFeedback.SingleOrDefault(e => e.FeedbackId == key);
            return solFeedback;
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.SolutionFeedback.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            if (await Get(entity.FeedbackId) != null)
            {
                _context.Entry<SolutionFeedback>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
