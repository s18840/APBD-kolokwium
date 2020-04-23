using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_kolokwium.DTOs
{
    public class PrescriptionRequest
    {
        [Required]public DateTime Date { get; set; }
        [Required]public DateTime DueTime { get; set; }
        [Required]public int IdPatient { get; set; }
        [Required]public int IdDoctor { get; set; }
    }
}
