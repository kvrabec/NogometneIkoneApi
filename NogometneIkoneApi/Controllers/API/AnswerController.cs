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
    public class AnswerController : BaseAPIController<Answer>
    {
        public AnswerController(AnswerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        private AnswerRepository _repository { get; }

        [HttpGet("GetAllDTO")]
        public IEnumerable<AnswerDTO> GetAnswerDtos()
        {
            var answers = _repository.GetList().Take(20);
            Mapper.Initialize(map => map.CreateMap<Answer, AnswerDTO>());
            return answers.Select(Mapper.Map<AnswerDTO>).ToList();
        }

        [HttpGet("GetAnswerDTO/{id:int}")]
        public AnswerDTO GetAnswerDto(int id)
        {
            var answer = _repository.Find(id);
            Mapper.Initialize(map => map.CreateMap<Answer, AnswerDTO>());

            return Mapper.Map<AnswerDTO>(answer);
        }
    }
}