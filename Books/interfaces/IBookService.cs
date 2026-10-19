using Books.Models;

namespace Books.Interfaces;

public interface IBookService
{
    List<Book> GetAll();

    Book? Get(int id);

    void Add(Book book);

    void Delete(int id);

    void Update(int id, Book book);

    int Count { get; }
}
