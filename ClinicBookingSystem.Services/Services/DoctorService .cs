using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem.Core.Interfacess.IRepository;
using ClinicBookingSystem.Core.Interfacess.IServices;
using ClinicBookingSystem.Core.Models;

namespace ClinicBookingSystem.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _repository.AddAsync(doctor);
        }

        public async Task<bool> UpdateDoctorAsync(int id, Doctor doctor)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            // Optionally map fields from input to existing entity
            doctor.Id = id; // Ensure ID consistency
            return await _repository.UpdateAsync(id, doctor);
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
