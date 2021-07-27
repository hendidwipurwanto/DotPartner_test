using Microsoft.AspNetCore.Mvc;
using SampleCRUD_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SampleCRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetList()
        {
            return await _repository.GetList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> GetBy(int id)
        {
            return await _repository.GetBy(id);
        }

        // POST api/<BookController>
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.CreateBook(model);
                return result;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, Book model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.UpdateBook(id, model);
                return result;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteBook(id);
        }
    }
}
