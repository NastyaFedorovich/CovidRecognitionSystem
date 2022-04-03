using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class SickLeave
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public PatientStatus Status { get; set; }

        public List<Diagnosis> Diagnoses { get; set; }
    }
}
