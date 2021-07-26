using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count_Pages  { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int? DepartmentId { get; set; }
        public int PublishYear { get; set; }
        // Parent book in Fluent api need to add
        public int? BookId { get; set; }
        public float Price { get; set; }
        public float Public_Price { get; set; }
        //Navigation
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Department Department { get; set; }
        public virtual Book Parent_Book { get; set; }
    }
}
