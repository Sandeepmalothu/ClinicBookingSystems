using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem.Core.Interfacess.IRepository;
using ClinicBookingSystem.Core.Models;
using ClinicBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Infrastructure.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
            => await _context.Doctors.ToListAsync();

        public async Task<Doctor?> GetByIdAsync(int id)
            => await _context.Doctors.FindAsync(id);

        public async Task AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Doctor doctor)
        {
            var existing = await _context.Doctors.FindAsync(id);
            if (existing == null) return false;

            existing.Name = doctor.Name;
            existing.Specialization = doctor.Specialization;
            existing.Email = doctor.Email;
            // Add other fields as needed

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

