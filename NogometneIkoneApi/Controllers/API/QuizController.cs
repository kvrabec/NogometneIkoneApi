using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL.Repository;
using NogometneIkone.Model;
using NogometneIkone.Model.DTO;

namespace NogometneIkone.Web.Controllers.API
{
    [Produces("application/json")]
    //[ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class QuizController : BaseAPIController<Quiz>
    {
        private readonly QuizRepository _repository;

        public QuizController(QuizRepository repository) : base(repository)
        {
            _repository = repository;
        }

        #region Model

        [HttpGet("GetWithQuestionsAndAnswers/{id:int}")]
        public Quiz GetQuizWithQuestionsAndAnswers(int id)
        {
            return _repository.FindWithQuestionsAndAnswers(id);
        }

        [HttpGet("GetAllWithQuestions")]
        public IEnumerable<Quiz> GetQuizesWithQuestions()
        {
            return _repository.GetListWithQuestions().Take(20);
        }

        [HttpGet("GetAllWithQuestionsAndAnswers")]
        public IEnumerable<Quiz> GetQuizesWithQuestionsAndAnswers()
        {
            return _repository.GetListWithQuestionsAndAnswers().Take(20);
        }

        #endregion

        #region DTO

        //[HttpGet("GetAllDTO")]
        //public IEnumerable<QuizDTO> GetAllDtO()
        //{
        //    var quizzes = _repository.GetList();
        //    var quizzesDto = new List<QuizDTO>();

        //    Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>());

        //    foreach (var quiz in quizzes) quizzesDto.Add(Mapper.Map<QuizDTO>(quiz));
        //    return quizzesDto;
        //}

        //[HttpGet("GetAllWithQuestionsDTO")]
        //public IEnumerable<QuizDTO> GetQuizesWithQuestionsDto()
        //{
        //    var quizzes = _repository.GetListWithQuestions();
        //    var quizzesDto = new List<QuizDTO>();
        //    Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>()
        //        .ForMember(quizDto => quizDto.QuestionIDs, options => options.MapFrom(quiz => quiz.Questions)));
        //    foreach (var quiz in quizzes) quizzesDto.Add(Mapper.Map<QuizDTO>(quiz));
        //    return quizzesDto;
        //}

        //[HttpGet("GetAllWithQuestionsAndAnswersDTO")]
        //public IEnumerable<QuizDTO> GetQuizesWithQuestionsAndAnswersDto()
        //{
        //    var quizzes = _repository.GetListWithQuestionsAndAnswers();
        //    var quizzesDto = new List<QuizDTO>();
        //    Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>()
        //        .ForMember(quizDto => quizDto.QuestionIDs, options => options.MapFrom(quiz => quiz.Questions)));
        //    foreach (var quiz in quizzes) quizzesDto.Add(Mapper.Map<QuizDTO>(quiz));
        //    return quizzesDto;
        //}

        [HttpGet("GetDTO/{id:int}")]
        public QuizDTO GetQuiz(int id)
        {
            var quiz = _repository.Find(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>());

            return Mapper.Map<QuizDTO>(quiz);
        }

        [HttpGet("GetWithQuestionsAndAnswersDTO/{id:int}")]
        public QuizDTO GetQuizWithQuestionsAndAnswersDto(int id)
        {
            var quiz = _repository.FindWithQuestionsAndAnswers(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>());

            return Mapper.Map<QuizDTO>(quiz);
        }

        #endregion
    }
}