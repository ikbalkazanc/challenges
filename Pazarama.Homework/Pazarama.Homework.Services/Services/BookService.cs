using Pazarama.Homework.Core.Contracts.Service;
using Pazarama.Homework.Core.Entity;
using Pazarama.Homework.Data;

namespace Pazarama.Homework.Services.Services;

public class BookService : IBookSevice
{
    private DataRepository _repo;

    public BookService(DataRepository repo)
    {
        _repo = repo;
    }

    public async Task<Book> GetDetails(int id)
    {
        var book = await _repo.BookRepository.Find(id);
        return book;
    }

    public async Task<List<Book>> GetAllBooks(int? categoryId)
    {
        var books = await _repo.BookRepository.Get(categoryId);
        return books;
    }

    public async Task CreateBook(Book book)
    {
        await _repo.BookRepository.Insert(book);
    }

    public async Task UpdateBook(int id, Book book)
    {
        var dbBook = await _repo.BookRepository.Find(id);
        if (dbBook == null) return;
        book.Id = dbBook.Id;
        await _repo.BookRepository.Update(book);
    }

    public async Task RemoveBook(int id)
    {
        var dbBook = await _repo.BookRepository.Find(id);
        if (dbBook == null) return;
        await _repo.BookRepository.Remove(dbBook);
    }
}