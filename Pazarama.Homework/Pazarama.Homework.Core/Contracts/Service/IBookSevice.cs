using Pazarama.Homework.Core.Entity;

namespace Pazarama.Homework.Core.Contracts.Service;

public interface IBookSevice
{
    Task<Book> GetDetails(int id);
    Task<List<Book>> GetAllBooks(int? categoryId);
    Task CreateBook(Book book);
    Task UpdateBook(int id, Book book);
    Task RemoveBook(int id);
}