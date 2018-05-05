using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL.Repository;
using NogometneIkone.DAL.Repository.IRepository;
using NogometneIkone.Model;

namespace NogometneIkone.Web.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Quiz")]
    public class QuizController : BaseAPIController<Quiz>
    {
        private readonly QuizRepository _repository;
        public QuizController(QuizRepository repository) : base(repository)
        {
            _repository = repository;
        }


        [HttpGet("GetWIthQuestions")]
        public IEnumerable<Quiz> GetQuizesWithQuestions()
        {
            return _repository.GetListWithQuestions().Take(20);
        }

        [HttpGet("GetWIthQuestionsAndAnswers")]
        public IEnumerable<Quiz> GetQuizesWithQuestionsAndAnswers()
        {
            return _repository.GetListWithQuestionsAndAnswers().Take(20);
        }
    }
}