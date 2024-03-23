using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseAppdz2.Services;

namespace WarehouseAppdz2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService = new BookService();
        public BooksController()
        {
            _bookService = new BookService();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            await _bookService.AddBookAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _bookService.UpdateBookAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}
