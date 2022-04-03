﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public List<SickLeave> SickLeaves { get; set; }
    }
}
