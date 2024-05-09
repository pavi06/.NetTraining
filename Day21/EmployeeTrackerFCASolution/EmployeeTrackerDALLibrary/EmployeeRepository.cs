using EmployeeTrackerModelLibrary;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            //automatically look for the entity type and add into it
            //_context.Employees.Add(entity); instead of
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employee> Get(int key)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == key);
            return employee;
        }

        public async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await Get(entity.Id);
            if (employee != null)
            {
                //instead of using the update method , we can set the state of the object.
                //_context.Employees.Update(employee);
                _context.Entry<Employee>(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return employee;
        }
    }
}
