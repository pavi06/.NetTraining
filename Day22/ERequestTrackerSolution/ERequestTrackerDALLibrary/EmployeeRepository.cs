﻿using ERequestTrackerModelLibrary;
using Microsoft.EntityFrameworkCore;

namespace ERequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Entry<Employee>(employee).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public virtual async Task<Employee> Get(int key)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == key);
            return employee;
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.Include(e => e.Role).ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            if (await Get(entity.Id) != null)
            {
                _context.Entry<Employee>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}