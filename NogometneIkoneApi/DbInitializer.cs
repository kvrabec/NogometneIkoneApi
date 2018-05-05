using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NogometneIkone.DAL;
using NogometneIkone.Model;

namespace NogometneIkone.Web
{
    public static class DbInitializer
    {
        public static void Initialize(NIManagerDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Questions.Any())
                return;

            var quizzes = new Quiz[]
            {
                new Quiz { DateCreated = DateTime.Now, DateModified = null, Difficulty = Difficulty.Amateur, Name = "Amateur", Time = 60, TotalScore = 100}
            };

            foreach (var quiz in quizzes)
            {
                context.Quizzes.Add(quiz);
            }

            context.SaveChanges();

            var questions = new Question[]
            {
                new Question
                {
                    Difficulty = Difficulty.Normal,
                    DateModified = null,
                    DateCreated = DateTime.Now,
                    Fact = "Since 2006, Luka Modric played more than 100 games for Croatia, scoring 12 goals",
                    FactURL = "https://en.wikipedia.org/wiki/Luka_Modri%C4%87",
                    QuestionText = "When did Luka Modric play his debut for Croatia and against what team?",
                    QuestionType = QuestionType.MultipleAnswer,
                    QuizID = 1,
                    Time = 30,
                    Score = 30
                },
                new Question
                {
                    Difficulty = Difficulty.Beginner,
                    DateModified = null,
                    DateCreated = DateTime.Now,
                    Fact =
                        "Manchester scored 2 goals, being down 0:1 until 91st minute and turned around the game in additional time. Sheringham scored in 91st minute and Solskjær scored in 93rd minute",
                    FactURL = "https://en.wikipedia.org/wiki/1999_UEFA_Champions_League_Final",
                    QuestionText = "Who won Champions League in season 1998/99?",
                    QuestionType = QuestionType.SingleAnswer,
                    QuizID = 1,
                    Time = 30,
                    Score = 10
                },
                new Question
                {
                    Difficulty = Difficulty.Superstar,
                    DateModified = null,
                    DateCreated = DateTime.Now,
                    Fact =
                        "Wembley Stadium hosted finals 7 finals: 62/63, 67/68, 70/71, 77/78, 91/92, 2010/11, 2012/13",
                    FactURL = "https://en.wikipedia.org/wiki/List_of_European_Cup_and_UEFA_Champions_League_finals",
                    QuestionText = "Which stadium hosted most Champions League finals?",
                    QuestionType = QuestionType.SingleAnswer,
                    QuizID = 1,
                    Time = 30,
                    Score = 60
                }
            };

            foreach (var question in questions)
            {
                context.Questions.Add(question);
            }

            context.SaveChanges();

            var answers = new Answer[]
            {
                new Answer{AnswerText = "2006", DateCreated = DateTime.Now, IsCorretAnswer = true, QuestionID = 1},
                new Answer { AnswerText = "Argentina",  DateCreated = DateTime.Now, IsCorretAnswer = true, QuestionID = 1, },
                new Answer { AnswerText = "Real Madrid",  DateCreated = DateTime.Now,IsCorretAnswer = true, QuestionID = 2 },
                new Answer { AnswerText = "Bayern Munich", DateCreated = DateTime.Now, IsCorretAnswer = false, QuestionID = 2 },
                new Answer { AnswerText = "Manchester United", DateCreated = DateTime.Now, IsCorretAnswer = false, QuestionID = 2 },
                new Answer { AnswerText = "Milan", DateCreated = DateTime.Now, IsCorretAnswer = false, QuestionID = 2 },
                new Answer { AnswerText = "San Siro", DateCreated = DateTime.Now, IsCorretAnswer = false,QuestionID = 3  },
                new Answer { AnswerText = "Santiago Bernabéu",  DateCreated = DateTime.Now, IsCorretAnswer = false, QuestionID = 3 },
                new Answer { AnswerText = "Stadio Olimpico", DateCreated = DateTime.Now, IsCorretAnswer = false, QuestionID = 3 },
                new Answer { AnswerText = "Wembley",  DateCreated = DateTime.Now, IsCorretAnswer = true, QuestionID = 3 }
            };

            foreach (var answer in answers)
            {
                context.Answers.Add(answer);
            }

            context.SaveChanges();

        }
    }
}
