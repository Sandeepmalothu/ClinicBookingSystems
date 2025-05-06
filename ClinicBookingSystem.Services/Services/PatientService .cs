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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
            => await _repo.GetAllAsync();

        public async Task<Patient?> GetPatientByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task AddPatientAsync(Patient patient)
            => await _repo.AddAsync(patient);

        public async Task<bool> UpdatePatientAsync(int id, Patient patient)
            => await _repo.UpdateAsync(id, patient);

        public async Task<bool> DeletePatientAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}
