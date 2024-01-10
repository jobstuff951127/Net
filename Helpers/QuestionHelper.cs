using Microsoft.AspNetCore.Http;
using Net.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Net.Services
{
    public class QuestionHelper
    {
        public List<Question> ParseQuestionsFromFile(IFormFile file)
        {
            var questions = new List<Question>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');

                    if (parts.Length < 2)
                    {
                        // Skip lines without enough parts (e.g., incomplete data)
                        continue;
                    }

                    var questionText = parts[0].Trim();
                    var answerData = parts.Skip(1).Select(part => part.Trim()).ToArray();


                    var question = new Question
                    {
                        Content = questionText,
                        Answers = ParseAnswers(answerData),
                    };

                    questions.Add(question);
                }
            }

            return questions;
        }

        private List<Answer> ParseAnswers(string[] answerData)
        {
            var answers = new List<Answer>();

            for (int i = 0; i < answerData.Length; i += 2)
            {
                if (i + 1 < answerData.Length)
                {
                    var answerText = answerData[i];
                    var isCorrect = bool.TryParse(answerData[i + 1], out var result) && result;

                    var answer = new Answer
                    {
                        Content = answerText,
                        IsCorrect = isCorrect
                    };

                    answers.Add(answer);
                }
            }

            return answers;
        }
    }
}

