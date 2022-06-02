using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModel;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }


        [HttpGet("get-all-books")]
        public IActionResult GetBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }


        [HttpGet("get-book/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        
        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]BookVM book)
        {
            var UpdatedBook = _booksService.UpdateBookById(id, book);
            return Ok(UpdatedBook);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }


    }
}
