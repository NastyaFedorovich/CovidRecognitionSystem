﻿using CovidRecognitionSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class PatientDatabaseContext : DbContext
    {
        public PatientDatabaseContext() : base()
        {
           
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
    }
}
