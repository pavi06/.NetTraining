using ClinicTrackerAPI.Contexts;
using ClinicTrackerAPI.Exceptions;
using ClinicTrackerAPI.Interfaces;
using ClinicTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicTrackerAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        protected readonly ClinicTrackerContext _context;

        public DoctorRepository(ClinicTrackerContext context) { 
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await Get(key);
            if (doctor != null)
            {
                _context.Remove(doctor);
                _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorAvailableException();
        }

        public Task<Doctor> Get(int key)
        {
            var doctor = _context.Doctors.FirstOrDefaultAsync(e => e.Id == key);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await Get(item.Id);
            if (doctor != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorAvailableException();
        }
    }
}
