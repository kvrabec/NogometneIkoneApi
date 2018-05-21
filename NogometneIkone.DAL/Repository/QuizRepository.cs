using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NogometneIkone.DAL.Repository.IRepository;
using NogometneIkone.Model;

namespace NogometneIkone.DAL.Repository
{
    public class QuizRepository : RepositoryBase<Quiz>, IRepositoryBase<Quiz>
    {
        public QuizRepository(NIManagerDbContext context) : base(context)
        {
        }

        public IEnumerable<Quiz> GetList()
        {
            return DbContext.Quizzes
                .ToList();
        }

        public IEnumerable<Quiz> GetListWithQuestions()
        {
            return DbContext.Quizzes
                .Include(quiz => quiz.Questions)
                .ToList();
        }

        public IEnumerable<Quiz> GetListWithQuestionsAndAnswers()
        {
            return DbContext.Quizzes
                .Include(quiz => quiz.Questions)
                .ThenInclude(question => question.Answers)
                .ToList();
        }

        public Quiz FindWithQuestionsAndAnswers(int id)
        {
            return DbContext.Quizzes
                .Include(quiz => quiz.Questions)
                .ThenInclude(question => question.Answers)
                .FirstOrDefault(quiz => quiz.ID == id);
        }
    }
}