using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public enum Disease //enum перечисление
    {
        [Display(Name = "ОРВИ")]
        ORVI = 0,

        [Display(Name = "Грипп")]
        Grippe = 1,

        [Display(Name = "Covid-19")]
        Covid = 2,

        Nothing
    }
}
