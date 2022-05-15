using CovidRecognitionSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class QuestionRepository
    {
        private const double CovidAddPercent = 7.69; // индексы расположения баллов в списке
        private const double GrippeAddPercent = 14.28;
        private const double OrviAddPersent = 11.11;

        private double _covidPercent = 0; 
        private double _grippePercent = 0;
        private double _orviPercent = 0;

        /// <summary>
        /// Set Balls
        /// </summary>
        /// <param name="qIndex"></param>
        /// <param name="key"></param>
        public void SetBalls(int qIndex, string key)
        {
            if (qIndex == 0)
            {
                _covidPercent = 0;
                _grippePercent = 0;
                _orviPercent = 0;
            }

            switch (Questions[qIndex].AnsverPercentsPair[key])
            {
                case Disease.Covid:
                    _covidPercent += CovidAddPercent;
                    break;
                case Disease.Grippe:
                    _grippePercent += GrippeAddPercent;
                    break;
                case Disease.ORVI:
                    _orviPercent += OrviAddPersent;
                    break;
            }
        }

        public double GetCovidChance() => Math.Round(_covidPercent, 2); //получение результата в процентах
        public double GetGrippeChance() => Math.Round(_grippePercent, 2);
        public double GetOrviChance() => Math.Round(_orviPercent, 2);
        public Disease GetDiagnosis()
        {
            double maxPercent =  new List<double> { _covidPercent, _grippePercent, _orviPercent}.Max();

            if (maxPercent == _covidPercent)
                return Disease.Covid;
            else if (maxPercent == _grippePercent)
                return Disease.Grippe;
            else
                return Disease.ORVI;
        }

        public List<Question> Questions { get; } = new List<Question>
        {
            new Question(
                "1. Какой ваш возраст?",
                new Dictionary<string, Disease>
                {
                    { "до 12 лет", Disease.Covid },
                    { "12-18 лет", Disease.ORVI },
                    { "18-35 лет", Disease.Grippe },
                    { "35-55 лет", Disease.Covid },
                    { "55+ лет", Disease.Covid }
                }),

            new Question(
                "2. Есть ли у вас: бронхиальная астма, сахарный диабет, артериальная гипертензия, сердечно-сосудистые заболевания?",
                new Dictionary<string, Disease>
                {
                    { "Да", Disease.Covid },
                    { "Нет", Disease.Nothing }
                }),

            new Question(
                "3. Как долго вы чувствуете недомогание?",
                new Dictionary<string, Disease>
                {
                    { "2-7 дней", Disease.ORVI },
                    { "7-10 дней", Disease.Grippe },
                    { "7-14 дней", Disease.Covid }
                }),

            new Question(
                "4. Чувствуете ли вы улучшение самочувствия?",
                new Dictionary<string, Disease>
                {
                    { "Да", Disease.ORVI }, // подставила рандомные данные
                    { "Нет", Disease.Nothing }
                }),

            new Question(
                "5. Были ли в местах массового скопления людей? Бывали ли вы в зарубежных странах? Контактировали ли вы с зараженными?",
                new Dictionary<string, Disease>
                {
                    { "Да", Disease.Covid },
                    { "Нет", Disease.Nothing}
                }),

            new Question(
                "6. Давно ли?",
                new Dictionary<string, Disease>
                {
                    { "1-3 дня", Disease.ORVI },
                    { "5 дней", Disease.Nothing },
                    { "7-14 дней", Disease.Covid }
                }),

            new Question(
                "7. Наблюдалась ли у вас температура?",
                new Dictionary<string, Disease>
                {
                    { "До 37", Disease.ORVI },
                    { "В первый день болезни 38+", Disease.Grippe },
                    { "37-37.3 в течении длительного времени до 2 недель", Disease.Covid },
                    { "Иногда скачки", Disease.Covid },
                    { "1-5 дней 37-37.3, а затем 38 и выше", Disease.Grippe },
                    { "Не наблюдается", Disease.ORVI }
                }),

            new Question(
                "8. Есть ли у вас кашель?",
                new Dictionary<string, Disease>
                {
                    { "Да, продуктивный с мокротой", Disease.ORVI },
                    { "Да, сухой", Disease.Grippe },
                    { "Да, сухой, но непродуктивный кашель", Disease.Covid },
                    { "Нет", Disease.Nothing }
                }),

            new Question(
                "9. Обильные слизистые выделения?",
                new Dictionary<string, Disease>
                {
                    { "Да", Disease.ORVI },
                    { "Да, но в небольшом количестве", Disease.Grippe },
                    { "Нет", Disease.Covid }
                }),

            new Question(
                "10. Есть ли у вас что-то из перечисленного: диарея, сыпь на коже(крапивница), потеря обоняния, " +
                "изменение вкуса, одышка или трудности с дыханием, конъюнктевит, бессоница?",
                new Dictionary<string, Disease>
                {
                    { "Да", Disease.Covid },
                    { "Нет", Disease.Nothing }
                }),

            new Question(
                "11. Есть ли у вас головная боль?",
                new Dictionary<string, Disease>
                {
                    { "Да", Disease.Grippe },
                    { "Да, с сильными приступами", Disease.Covid },
                    { "Нет", Disease.ORVI }
                })
        };
    }
}
