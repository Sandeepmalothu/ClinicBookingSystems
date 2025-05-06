using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }  // Optional if you calculate from duration

        public int DurationInMinutes { get; set; }  // ✅ Add this

        public string? Notes { get; set; }
    }
}
