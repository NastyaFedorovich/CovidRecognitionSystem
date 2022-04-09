using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        [Column("PatientName")]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public List<SickLeave> SickLeaves { get; set; }
    }
}
