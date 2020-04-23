using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APBD_kolokwium.DTOs;
using APBD_kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_kolokwium.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getPrescriptions(int id)
        {
            try { 
            var prescList = new List<Prescriptions>();
            var prescMedList = new List<PrescriptionMedicament>();

                using (SqlConnection client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18840;Integrated Security=True"))
                using (var com = new SqlCommand())
                {
                    com.Connection = client;

                    com.Parameters.AddWithValue("IdPrescription", id);
                    com.CommandText = "Select * from Prescription where IdPrescription = @id";

                    client.Open();
                    var reader = com.ExecuteReader();

                    while (reader.Read()) {
                        var presc = new Prescriptions();
                        presc.IdPrescription = (int)reader["IdPrescription"];
                        presc.Date = DateTime.Parse(reader["Date"].ToString());
                        presc.DueTime = DateTime.Parse(reader["DueDate"].ToString());
                        presc.IdPatient = (int)reader["IdPatient"];
                        presc.IdDoctor = (int)reader["IdPatient"];
                        prescList.Add(presc);
                        //com.ExecuteNonQuery();

                    }
                    com.ExecuteNonQuery();

                    com.Parameters.AddWithValue("IdPrescription2", id);
                    com.CommandText = "Select * from Prescription_Medicament where IdPrescription = @id";

                    while (reader.Read())
                    {
                        var prescMed = new PrescriptionMedicament();
                        var medList = new List<Medicament>();

                        prescMed.IdPrescription = (int)reader["IdPrescription"];
                        prescMed.IdMedicament = (int)reader["IdMedicament"];
                        prescMed.Dose = (int)reader["Dose"];
                        prescMed.Details = reader["Details"].ToString();

                        prescMedList.Add(prescMed);

                    }
                    return Ok(prescList + " " + prescMedList);

                }
            }catch(SqlException ex)
            {
                return BadRequest("Blad");
            }
         
            
        }
        [HttpPost]
        public IActionResult addPres(PrescriptionRequest prescrptionRequest)
        {
            using (SqlConnection client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18840;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;

  
                client.Open();

                com.CommandText = "Insert Into Prescription(Date,DueDate,IdPatient,IdDoctor) values (@date, @duedate, @patient, @doctor)";


            }
    }
}