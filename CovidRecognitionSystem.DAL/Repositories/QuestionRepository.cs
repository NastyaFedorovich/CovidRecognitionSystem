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
        public int CovidBalls { get; private set; } = 0;
        public int GrippeBalls { get; private set; } = 0;
        public int OrviBalls { get; private set; } = 0;

        public void SetBalls(int qIndex, string key)
        {
            if (qIndex == 0)
            {
                CovidBalls = 0;
                GrippeBalls = 0;
                OrviBalls = 0;
            }

            CovidBalls += Questions[qIndex].AnsverPercentsPair[key][0];
            GrippeBalls += Questions[qIndex].AnsverPercentsPair[key][1];
            OrviBalls += Questions[qIndex].AnsverPercentsPair[key][2];
        }

        public List<Question> Questions { get; } = new List<Question>
        {
            new Question(
                "1. Какой ваш возраст?",
                new Dictionary<string, int[]>
                {
                    { "до 12 лет", new int[]{60, 10, 70} },
                    { "12-18 лет", new int[]{70, 20, 10} },
                    { "18-35 лет", new int[]{50, 50, 10} },
                    { "35-55 лет", new int[]{40, 10, 70} },
                    { "55+ лет", new int[]{10, 10, 70} }
                }),

            new Question(
                "2. Есть ли у вас: бронхиальная астма, сахарный диабет, артериальная гипертензия, сердечно-сосудистые заболевания?",
                new Dictionary<string, int[]>
                {
                    { "Да", new int[]{ 5, 5, 80 } },
                    { "Нет", new int[]{0, 0, 0} }
                }),

            new Question(
                "3. Как долго вы чувствуете недомогание?",
                new Dictionary<string, int[]>
                {
                    { "2-7 дней", new int[]{ 25, 25, 50 } },
                    { "7-10 дней", new int[]{ 25, 50, 25 } },
                    { "7-14 дней", new int[]{ 25, 25, 50 } }
                }),

            new Question(
                "4. Чувствуете ли вы улучшение самочувствия?",
                new Dictionary<string, int[]>
                {
                    { "Да", new int[]{10, 10, 10} }, // подставила рандомные данные
                    { "Нет", new int[]{10, 10, 10} }
                }),

            new Question(
                "5. Были ли в местах массового скопления людей? Бывали ли вы в зарубежных странах? Контактировали ли вы с зараженными?",
                new Dictionary<string, int[]>
                {
                    { "Да", new int[]{ 20, 10, 70 } },
                    { "Нет", new int[]{ 10, 10, 10 } }
                }),

            new Question(
                "6. Давно ли?",
                new Dictionary<string, int[]>
                {
                    { "1-3 дня", new int[]{ 10, 10, 10 } },
                    { "5 дней", new int[]{ 20, 10, 30 } },
                    { "7-14 дней", new int[]{ 20, 10, 80 } }
                }),

            new Question(
                "7. Наблюдалась ли у вас температура?",
                new Dictionary<string, int[]>
                {
                    { "До 37", new int[]{ 0, 0, 0 } },
                    { "В первый день болезни 38+", new int[]{ 20, 50, 10 } },
                    { "37-37.3 в течении длительного времени до 2 недель", new int[]{ 20, 10, 90 } },
                    { "Иногда скачки", new int[]{ 50, 50, 10 } },
                    { "1-5 дней 37-37.3, а затем 38 и выше", new int[]{ 20, 10, 90 } },
                    { "Не наблюдается", new int[]{ 85, 10, 20 } }
                }),

            new Question(
                "8. Есть ли у вас кашель?",
                new Dictionary<string, int[]>
                {
                    { "Да, продуктивный с мокротой", new int[]{ 90, 10, 10 } },
                    { "Да, сухой", new int[]{ 20, 90, 70 } },
                    { "Да, сухой, но непродуктивный кашель", new int[]{ 20, 70, 90 } },
                    { "Нет", new int[]{ 80, 10, 10 } }
                }),

            new Question(
                "9. Обильные слизистые выделения?",
                new Dictionary<string, int[]>
                {
                    { "Да", new int[]{ 90, 10, 10 } },
                    { "Да, но в небольшом количестве", new int[]{ 90, 70, 10 } },
                    { "Нет", new int[]{ 10, 50, 50 } }
                }),

            new Question(
                "10. Есть ли у вас что-то из перечисленного: диарея, сыпь на коже(крапивница), потеря обоняния, " +
                "изменение вкуса, одышка или трудности с дыханием, конъюнктевит, бессоница?",
                new Dictionary<string, int[]>
                {
                    { "Да", new int[]{ 20, 10, 90 } },
                    { "Нет", new int[]{ 30, 30, 30 } }
                }),

            new Question(
                "11. Есть ли у вас головная боль?",
                new Dictionary<string, int[]>
                {
                    { "Да", new int[]{ 20, 10, 90 } },
                    { "Да, с сильными приступами", new int[]{ 20, 10, 90 } },
                    { "Нет", new int[]{ 30, 30, 30 } }
                })
        };
    }
}
