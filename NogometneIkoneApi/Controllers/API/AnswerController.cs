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
    [Route("api/Answer")]
    public class AnswerController : BaseAPIController<Answer>
    {
        private AnswerRepository _repository { get; }
        public AnswerController(AnswerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllDTO")]
        public IEnumerable<AnswerDTO> GetAnswerDtos()
        {
            var answersDTO = new List<AnswerDTO>();
            var answers = _repository.GetList().Take(20);
            Mapper.Initialize(map => map.CreateMap<Answer, AnswerDTO>());
            foreach (var answer in answers)
            {
                answersDTO.Add(Mapper.Map<AnswerDTO>(answer));
            }

            return answersDTO;
        }

        [HttpGet("GetAnswerDTO/{id:int}")]
        public AnswerDTO GetAnswerDTO(int id)
        {
            var answer = _repository.Find(id);
            Mapper.Initialize(map => map.CreateMap<Answer, AnswerDTO>());

            return Mapper.Map<AnswerDTO>(answer);
        }
    }
}