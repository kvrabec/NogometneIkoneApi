using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL.Repository;
using NogometneIkone.Model;
using NogometneIkone.Model.DTO;

namespace NogometneIkone.Web.Controllers.API
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class QuestionController : BaseAPIController<Question>
    {
        private QuestionRepository _repository { get; }

        public QuestionController(QuestionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        #region Model
        [HttpGet("GetAllWithAnswers")]
        public IEnumerable<Question> GetQuestionsWithAnswers() => _repository.ListWithAnswers.Take(20);

        #endregion

        #region DTO

        [HttpGet("GetWithAnswersDTO/{id:int}")]
        public QuestionDTO GetQuestionWithAnswerDTO(int id)
        {
            var question = _repository.FindWithAnswers(id);
            Mapper.Initialize(map => map.CreateMap<Question, QuestionDTO>());
            return Mapper.Map<QuestionDTO>(question);
        }

        #endregion

    }
}