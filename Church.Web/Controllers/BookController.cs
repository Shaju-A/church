using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Church.Web.Controllers
{
    public class BookController : Controller
    {
        //[Route("")]
        //[Route("books/{id?}")]
        public ActionResult View(int? id)
        {
            ViewBag.Id = id;
            var books = GetBookList();
            ViewBag.BookList = id > 0 ? books.Where(i => i.Id == id) : books ;
            return View();
        }

        List<Books> GetBookList()
        {
            var books = new List<Books> {
            new Books { Id = 1, Name = "Tamil"},
            new Books { Id = 2, Name = "English"},
            new Books { Id = 3, Name = "Maths" },
            new Books { Id = 4, Name = "Science" },
            new Books { Id = 5, Name = "Social" }
    };

            return books;
        }
    }

    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}