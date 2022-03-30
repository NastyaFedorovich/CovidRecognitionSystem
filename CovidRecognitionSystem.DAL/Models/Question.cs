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
        public Dictionary<string, int[]> AnsverPercentsPair { get; }
        public Question(string title, Dictionary<string, int[]> ansverPersentsPair)
        {
            Title = title;
            AnsverPercentsPair = ansverPersentsPair;
        }
    }
}
