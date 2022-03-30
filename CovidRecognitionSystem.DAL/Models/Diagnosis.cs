using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }

        public int SickLeaveId { get; set; }

        public string ComputerDiagnosis { get; set; }

        public string DoctorDiagnosis { get; set; }

        public DateTime Date { get; set; }
    }
}
