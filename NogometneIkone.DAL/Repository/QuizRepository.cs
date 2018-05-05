using NogometneIkone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NogometneIkone.DAL.Repository.IRepository;

namespace NogometneIkone.DAL.Repository
{
    public class QuizRepository : RepositoryBase<Quiz>, IRepositoryBase<Quiz>
    {
        public QuizRepository(NIManagerDbContext context) : base(context) { }

        public List<Quiz> GetList ()
        {
            return this.DbContext.Quizzes
                .ToList();
        }

        public List<Quiz> GetListWithQuestions()
        {
            return this.DbContext.Quizzes
                .Include(quiz => quiz.Questions)
                .ToList();
        }

        public List<Quiz> GetListWithQuestionsAndAnswers()
        {
            return this.DbContext.Quizzes
                .Include(quiz => quiz.Questions)
                .ThenInclude(question => question.Answers)
                .ToList();
        }
    }
}
