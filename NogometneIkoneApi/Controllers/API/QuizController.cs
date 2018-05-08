using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL.Repository;
using NogometneIkone.DAL.Repository.IRepository;
using NogometneIkone.Model;
using NogometneIkone.Model.DTO;

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

        [HttpGet("GetQuizDTO/{id:int}")]
        public QuizDTO GetQuiz(int id)
        {
            var quiz =  _repository.Find(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>());
            
            return Mapper.Map<QuizDTO>(quiz);
        }

        [HttpGet("GetAllWIthQuestions")]
        public IEnumerable<Quiz> GetQuizesWithQuestions()
        {
            return _repository.GetListWithQuestions().Take(20);
        }

        [HttpGet("GetAllWIthQuestionsAndAnswers")]
        public IEnumerable<Quiz> GetQuizesWithQuestionsAndAnswers()
        {
            return _repository.GetListWithQuestionsAndAnswers().Take(20);
        }



        [HttpGet("GetAllDTOs")]
        public IEnumerable<QuizDTO> GetAllDTOs()
        {
            var quizzes = _repository.GetList();
            var quizzesDTO = new List<QuizDTO>();

            Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>());

            foreach (var quiz in quizzes)
            {
                quizzesDTO.Add(Mapper.Map<QuizDTO>(quiz));
            }
            return quizzesDTO;
        }

        [HttpGet("GetAllWIthQuestionsDTO")]
        public IEnumerable<QuizDTO> GetQuizesWithQuestionsDTO()
        {
            var quizzes = _repository.GetListWithQuestions();
            var quizzesDTO = new List<QuizDTO>();
            Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>()
                   .ForMember(quizDTO => quizDTO.QuestionIDs, options => options.MapFrom(quiz => quiz.Questions)));
            foreach (var quiz in quizzes)
            {
                quizzesDTO.Add(Mapper.Map<QuizDTO>(quiz));
            }
            return quizzesDTO;
        }

        [HttpGet("GetAllWIthQuestionsAndAnswersDTO")]
        public IEnumerable<QuizDTO> GetQuizesWithQuestionsAndAnswersDTO()
        {
            var quizzes = _repository.GetListWithQuestionsAndAnswers();
            var quizzesDTO = new List<QuizDTO>();
            Mapper.Initialize(cfg => cfg.CreateMap<Quiz, QuizDTO>()
                .ForMember(quizDTO => quizDTO.QuestionIDs, options => options.MapFrom(quiz => quiz.Questions)));
            foreach (var quiz in quizzes)
            {
                quizzesDTO.Add(Mapper.Map<QuizDTO>(quiz));
            }
            return quizzesDTO;
        }
    }
}