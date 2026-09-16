using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TeamQuizApp4
{

    public class Question
    {
        public string Text { get; set; } = "";
        public string[] Choices { get; set; } = new string[4];
        public int CorrectIndex { get; set; }
    }

    public class QuestionLoader
    {
        private readonly List<Question> _questions = new List<Question>();
        private readonly Random _rand = new Random();

        private int questionRand = new Random().Next(1, 3);
        public QuestionLoader(string? path = null)
        {
            path ??= $"questions{questionRand}.csv";
            string csvPath = Path.Combine(AppContext.BaseDirectory, path);
            foreach (var line in File.ReadAllLines(csvPath))
            {
                if (line.StartsWith("question")) continue;
                var cols = line.Split(',');
                _questions.Add(new Question
                {
                    Text = cols[0],
                    Choices = new[] { cols[1], cols[2], cols[3], cols[4] },
                    CorrectIndex = int.Parse(cols[5])
                });
            }
        }

        public Question GetRandomQuestion()
        {
            int idx = _rand.Next(_questions.Count);
            return _questions[idx];
        }
    }
}

