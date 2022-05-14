using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Diagnosis
    {
        public int Id { get; set; } //свойства, чтобы определять какую-то характеристику

        public int SickLeaveId { get; set; }
        public SickLeave SickLeave { get; set; }

        public Disease ComputerDiagnosis { get; set; }

        public Disease DoctorDiagnosis { get; set; }

        [Column("DiagnosisDate")] //атрибут которая задает название поля в таблице соответствующие свойству
        public DateTime Date { get; set; }
    }
}
