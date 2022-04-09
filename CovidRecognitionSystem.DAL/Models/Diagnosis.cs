﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }

        public int SickLeaveId { get; set; }
        public SickLeave SickLeave { get; set; }

        public string ComputerDiagnosis { get; set; }

        public string DoctorDiagnosis { get; set; }

        [Column("DiagnosisDate")]
        public DateTime Date { get; set; }
    }
}
