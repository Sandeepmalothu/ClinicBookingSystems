using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem.Core.Models;

namespace ClinicBookingSystem.Core.Interfacess.IRepository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        Task<bool> UpdateAsync(int id, Doctor doctor);
        Task<bool> DeleteAsync(int id);
    }
}
