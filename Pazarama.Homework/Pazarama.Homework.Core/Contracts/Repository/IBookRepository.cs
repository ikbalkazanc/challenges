using Pazarama.Homework.Core.Entity;

namespace Pazarama.Homework.Core.Contracts;

public interface IBookRepository
{
    Task<Book> Find(int id);
    Task<List<Book>> Get(int? categoryId);
    Task<Book> Insert(Book book);
    Task Update(Book book);
    Task Remove(Book book);
}