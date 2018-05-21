using NogometneIkone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NogometneIkone.DAL.Repository.IRepository;

namespace NogometneIkone.DAL.Repository
{
    public class QuestionRepository : RepositoryBase<Question>, IRepositoryBase<Question>
    {
        public QuestionRepository(NIManagerDbContext context) : base(context) { }

        public IEnumerable<Question> GetList()
        {
            return DbContext.Questions
.ToList();
        }

        public IEnumerable<Question> ListWithAnswers => DbContext.Questions
                .Include(q => q.Answers)
                .ToList();

        public IEnumerable<Question> FindWithAnswers(int id) => DbContext.Questions
                .Include(q => q.Answers)
                .ToList();
    }
}
