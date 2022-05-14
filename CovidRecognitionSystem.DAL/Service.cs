using CovidRecognitionSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL
{
    public class Service
    {
        public static string GetDiseaseName(Disease disease)
        {
            Type type = disease.GetType();
            var enumItem = type.GetField(disease.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }

        public static string GetPatientStatusName(PatientStatus status)
        {
            Type type = status.GetType();
            var enumItem = type.GetField(status.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }
    }
}
