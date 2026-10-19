using Microsoft.AspNetCore.Mvc;
using Books.Models;
using Books.Interfaces;

namespace Books.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService bookService;

    public BooksController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpGet]
    public ActionResult<List<Book>> GetAll() => bookService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = bookService.Get(id);

        if (book == null)
            return NotFound();

        return book;
    }

    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        bookService.Add(book);
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();

        var existingBook = bookService.Get(id);
        if (existingBook is null)
            return NotFound();

        bookService.Update(id, book);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = bookService.Get(id);
        if (book is null)
            return NotFound();

        bookService.Delete(id);

        return Ok(bookService.Count);
    }
}
