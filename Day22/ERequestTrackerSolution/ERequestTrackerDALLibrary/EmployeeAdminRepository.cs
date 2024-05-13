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
    public class EmployeeAdminRepository : EmployeeRepository
    {
        public EmployeeAdminRepository(RequestTrackerContext context) : base(context)
        {
        }

        public async override Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.Include(e => e.RequestsRaised).Include(e=>e.SolutionsProvided)
                .Include(e=>e.RequestsClosed).Include(e=>e.FeedbacksGiven).ToListAsync();
        }
        public async override Task<Employee> Get(int key)
        {
            var employee = _context.Employees.Include(e => e.RequestsRaised).Include(e => e.SolutionsProvided)
                .Include(e => e.RequestsClosed).Include(e => e.FeedbacksGiven).SingleOrDefault(e => e.Id == key);
            return employee;
        }
    }
}
