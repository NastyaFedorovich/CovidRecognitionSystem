using CovidRecognitionSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL
{
    public class AppDbContext : DbContext
    {
        private string _connectionString =
        "Server=localhost;Database=CovidRecognitionSystem;Uid=root;pwd=15041975;";
        public AppDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, new MySqlServerVersion(new Version(8, 0, 28)));
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
    }
}