using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCRUD_API.Model
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDBContext _context;
        public AuthorRepository(AppDBContext context)
        {
           _context = context;
        }
        public async Task<Author> CreateAuthor(Author model)
        {
             await _context.Authors.AddAsync(model);
            await  _context.SaveChangesAsync();

            return model;
        }

        public void DeleteAuthor(int Id)
        {
            var entity = _context.Authors.Find(Id);
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Author> GetBy(int Id)
        {
            return await _context.Authors.FindAsync(Id);
        }

       public async Task<IEnumerable<Author>> GetList()
        {
            return await _context.Authors.Include(x=>x.Books).ToListAsync();
        }

       public async Task<Author> UpdateAuthor(int id,Author newEntity)
        {
            var oldEntity = await _context.Authors.FindAsync(id);
            oldEntity.FullName = newEntity.FullName;
            await _context.SaveChangesAsync();

            return newEntity;
        }
    }
}
