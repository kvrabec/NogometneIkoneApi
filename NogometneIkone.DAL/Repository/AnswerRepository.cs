using NogometneIkone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NogometneIkone.DAL.Repository.IRepository;

namespace NogometneIkone.DAL.Repository
{
    public class AnswerRepository : RepositoryBase<Answer>, IRepositoryBase<Answer>
    {
        public AnswerRepository(NIManagerDbContext context) : base(context) { }

        public IEnumerable<Answer> GetList()
        {
            return DbContext.Answers.ToList();
        }
    }
}
