using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCRUD_API.Model
{
    public interface IAuthorRepository
    {
         Task<Author> GetBy(int Id);
        Task<IEnumerable<Author>> GetList();
        Task<Author>CreateAuthor(Author model);
       Task<Author> UpdateAuthor(int id,Author newEntity);
       void DeleteAuthor(int Id);
    }
}
