using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count_Pages { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int? DepartmentId { get; set; }
        public int PublishYear { get; set; }
        // Parent book in Fluent api need to add
        public int? BookId { get; set; }
        public float Price { get; set; }
        public float Public_Price { get; set; }
        //Navigation
        public AuthorDTO Author { get; set; }
        public GenreDTO Genre { get; set; }
        public DepartmentDTO Department { get; set; }
        public BookDTO Parent_Book { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Author: {Author.Name}, Genre: {Genre.Name}";
        }
    }
}
