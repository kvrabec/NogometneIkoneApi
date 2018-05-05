using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL.Repository.IRepository;
using NogometneIkone.Model;

namespace NogometneIkone.Web.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseAPIController<TEntity> : Controller where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public BaseAPIController(IRepositoryBase<TEntity> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _repository.GetList().Take(20);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = _repository.Find(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]TEntity value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(value, autoSave: true);

            return CreatedAtAction("Get", new { id = value.ID }, value);
        }
        [HttpPut("{id}")]
        public virtual IActionResult Put(int id, [FromBody]TEntity value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _repository.Find(id);

            if (entity == null)
                return NotFound();

            entity = value;
            entity.ID = id;

            _repository.Update(entity, autoSave: true);

            return CreatedAtAction("Get", new { id = entity.ID }, entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _repository.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            _repository.Delete(id, autoSave: true);

            return Ok(entity);
        }
    }
}