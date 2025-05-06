using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem.Core.Interfacess.IRepository;
using ClinicBookingSystem.Core.Models;
using ClinicBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Infrastructure.Interfaces.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicContext _context;

        public AppointmentRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
            => await _context.Appointments.ToListAsync();

        public async Task<Appointment?> GetByIdAsync(int id)
            => await _context.Appointments.FindAsync(id);

        public async Task AddAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Appointments.FindAsync(id);
            if (entity == null) return false;
            _context.Appointments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId)
            => await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();

        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId)
            => await _context.Appointments
                .Where(a => a.PatientId == patientId)
                .ToListAsync();

        public async Task<bool> IsSlotAvailableAsync(int doctorId, DateTime start, int durationInMinutes)
        {
            var end = start.AddMinutes(durationInMinutes);
            return !await _context.Appointments.AnyAsync(a =>
                a.DoctorId == doctorId &&
                ((start >= a.StartTime && start < a.EndTime) ||
                 (end > a.StartTime && end <= a.EndTime) ||
                 (start <= a.StartTime && end >= a.EndTime))
            );
        }
    }
}
