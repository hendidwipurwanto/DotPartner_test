using Microsoft.AspNetCore.Mvc;
using SampleCRUD_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace SampleCRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
         public async Task<IEnumerable<Author>> Get()
        {
            return await _repository.GetList();

           
        }
        // GET api/<AuthorController>/5
        [HttpGet("{id}")]

        public async Task<Author> GetBy(int id)
        {
            return await _repository.GetBy(id);
        }

        //POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult<Author>> Create(Author model)
        {
            if (ModelState.IsValid) 
            {
              var result = await _repository.CreateAuthor(model);
                return result;
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }

       // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> Put(int id, Author model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.UpdateAuthor(id,model);
                return result;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteAuthor(id);
        }
    }
}
