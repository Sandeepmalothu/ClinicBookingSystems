using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem.Core.Interfacess.IRepository;
using ClinicBookingSystem.Core.Interfacess.IServices;
using ClinicBookingSystem.Core.Models;

namespace ClinicBookingSystem.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
            => await _repo.GetAllAsync();

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<bool> BookAppointmentAsync(Appointment appointment)
        {
            var available = await _repo.IsSlotAvailableAsync(
                appointment.DoctorId,
                appointment.StartTime,
                appointment.DurationInMinutes
            );

            if (!available) return false;

            await _repo.AddAsync(appointment);
            return true;
        }

        public async Task<bool> CancelAppointmentAsync(int id)
            => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAsync(int doctorId)
            => await _repo.GetByDoctorIdAsync(doctorId);

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId)
            => await _repo.GetByPatientIdAsync(patientId);

        public async Task<bool> IsSlotAvailableAsync(int doctorId, DateTime start, int duration)
            => await _repo.IsSlotAvailableAsync(doctorId, start, duration);
    }
}
