using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem.Core.Models
{
    public class Patient
    {
        public int id { get; set; }

        public string name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string phonenumber { get; set; } = string.Empty;

        public DateTime dateofbirth { get; set; }

        public string? gender { get; set; }
        public int age { get; set; }
    }
}
