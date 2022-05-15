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
    public static class Service
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

        public static Disease GetDiseaseFromStr(string strDisease)
        {
            switch (strDisease)
            {
                case "Грипп":
                    return Disease.Grippe;
                case "ОРВИ":
                    return Disease.ORVI;
                case "Covid-19":
                    return Disease.Covid;
            }

            if (!Enum.TryParse(strDisease, out Disease disease))
            {
                throw new Exception("Such disease is not exist");
            }
            return disease;
        }

        public static PatientStatus GetPatientStatusFromStr(string strStatus)
        {
            switch (strStatus)
            {
                case "Здоров":
                    return PatientStatus.Healthy;
                case "Болен":
                    return PatientStatus.Ill;
                case "Мёртв":
                    return PatientStatus.Dead;
            }

            if (!Enum.TryParse(strStatus, out PatientStatus status))
            {
                throw new Exception("Such patient status is not exist");
            }
            return status;
        }
    }
}
