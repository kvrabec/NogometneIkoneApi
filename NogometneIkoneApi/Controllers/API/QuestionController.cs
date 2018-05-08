using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL.Repository;
using NogometneIkone.Model;

namespace NogometneIkone.Web.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Question")]
    public class QuestionController : BaseAPIController<Question>
    {
        private QuestionRepository _repository { get; }

        public QuestionController(QuestionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("GetWithAnswers")]
        public IEnumerable<Question> GetQuestionsWithAnswers()
        {
            return _repository.GetListWithAnswers().Take(20);
        }
    }
}