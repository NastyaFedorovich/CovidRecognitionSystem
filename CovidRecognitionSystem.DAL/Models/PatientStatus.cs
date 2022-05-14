using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public enum PatientStatus
    {
        [Display(Name = "Здоров")]
        Healthy = 0,

        [Display(Name = "Болен")]
        Ill = 1,

        [Display(Name = "Мёртв")]
        Dead = 2,
    }
}
