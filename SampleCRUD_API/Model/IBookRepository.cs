using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCRUD_API.Model
{
    public interface IBookRepository
    {
        Task<Book> GetBy(int Id);
        Task<IEnumerable<Book>> GetList();
        Task<Book> CreateBook(Book model);
        Task<Book> UpdateBook(int id,Book model);
        void DeleteBook(int Id);
    }
}
