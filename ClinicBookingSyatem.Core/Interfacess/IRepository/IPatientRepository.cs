using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem.Core.Models;

namespace ClinicBookingSystem.Core.Interfacess.IRepository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task AddAsync(Patient patient);
        Task<bool> UpdateAsync(int id, Patient patient);
        Task<bool> DeleteAsync(int id);
    }
}
