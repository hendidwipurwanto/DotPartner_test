using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCRUD_API.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string FullName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
