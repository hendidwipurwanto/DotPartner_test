using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCRUD_API.Model
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDBContext _context;
        public BookRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Book> CreateBook(Book model)
        {
            var result = await _context.Books.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public void DeleteBook(int Id)
        {
            var entity =  _context.Books.Find(Id);
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Book> GetBy(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }

        public async Task<IEnumerable<Book>> GetList()
        {
            return await _context.Books.Include(x => x.Author).ToListAsync();
        }

        public async Task<Book> UpdateBook(int id,Book newEntity)
        {
            var oldEntity = await _context.Books.FindAsync(id);
            oldEntity.Title = newEntity.Title;
            
            await _context.SaveChangesAsync();

            return newEntity;
        }
    }
}
