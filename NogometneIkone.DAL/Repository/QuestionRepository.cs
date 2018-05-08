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

        public List<Question> GetList()
        {
            return this.DbContext.Questions
                    .ToList();
        }

        public List<Question> GetListWithAnswers()
        {
            return this.DbContext.Questions
                .Include(q => q.Answers)
                .ToList();
        }
    }
}
