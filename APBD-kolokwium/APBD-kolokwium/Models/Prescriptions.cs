using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_kolokwium.Models
{
    public class Prescriptions
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueTime { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

    }
}
