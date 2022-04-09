using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }

        [Column("DoctorPassword")]
        public string Password { get; set; }
    }
}
