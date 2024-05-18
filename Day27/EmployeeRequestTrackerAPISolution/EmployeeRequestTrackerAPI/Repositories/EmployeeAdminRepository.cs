using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class EmployeeAdminRepository : EmployeeRepository
    {
        public EmployeeAdminRepository(RequestTrackerContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees.Include(e => e.RequestsRaised)
                .Include(e => e.RequestsClosed).ToListAsync();
        }
        public async override Task<Employee> Get(int key)
        {
            var employee = _context.Employees.Include(e => e.RequestsRaised)
                .Include(e => e.RequestsClosed).SingleOrDefault(e => e.Id == key);
            return employee;
        }
    }
}
