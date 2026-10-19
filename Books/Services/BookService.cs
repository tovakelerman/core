using Books.Models;
using Books.Interfaces;

namespace Books.Services;

public class BookService : IBookService
{
    private readonly List<Book> books;
    private int nextId = 7;

    public BookService()
    {
        books = new List<Book>
        {
            new Book { Id = 1, Title = "ספר לדוגמה 1", Author = "שם מלא 1" },
            new Book { Id = 2, Title = "ספר לדוגמה 2", Author = "שם מלא 2" },
            new Book { Id = 3, Title = "ספר לדוגמה 3", Author = "שם מלא 3" },
            new Book { Id = 4, Title = "ספר לדוגמה 4", Author = "שם מלא 4" },
            new Book { Id = 5, Title = "ספר לדוגמה 5", Author = "שם מלא 5" },
            new Book { Id = 6, Title = "ספר לדוגמה 6", Author = "שם מלא 6" }
        };
    }

    public List<Book> GetAll() => books;

    public Book? Get(int id) => books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        book.Id = nextId++;
        books.Add(book);
    }

    public void Delete(int id)
    {
        var book = Get(id);
        if (book is null)
            return;

        books.Remove(book);
    }

    public void Update(int id, Book book)
    {
        var index = books.FindIndex(b => b.Id == id);
        if (index == -1)
            return;

        books[index] = book;
    }

    public int Count => books.Count;
}
