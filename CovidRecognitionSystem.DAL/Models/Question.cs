using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Models
{
    public class Question
    {
        public string Title { get; }
        public Dictionary<string, Disease> AnsverPercentsPair { get; }
        public Question(string title, Dictionary<string, Disease> ansverPersentsPair)//конструктор задает значение свойств
        {
            Title = title;
            AnsverPercentsPair = ansverPersentsPair;
        }
    }
}
