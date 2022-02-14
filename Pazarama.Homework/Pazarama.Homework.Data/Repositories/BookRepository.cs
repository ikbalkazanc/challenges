using Microsoft.EntityFrameworkCore;
using Pazarama.Homework.Core.Contracts;
using Pazarama.Homework.Core.Entity;

namespace Pazarama.Homework.Data.Repositories;

public class BookRepository : IBookRepository
{
    private DatabaseContext _context;

    public BookRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Book> Find(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<List<Book>> Get(int? categoryId)
    {
        List<Book> books = default;
        if (categoryId != null)
        {
            books = await _context.Books.Include(x => x.Categories)
                .Where(y => y.Categories.Any(x => x.Id == categoryId)).ToListAsync();
        }
        else
        {
            books = await _context.Books.Include(x => x.Categories)
                .ToListAsync();
        }

        return books;
    }

    public async Task<Book> Insert(Book book)
    {
        if (book.Id == 0)
        {
            Random random = new Random();
            book.Id = random.Next();
        }

        await _context.Books.AddAsync(book);
        var result = await _context.SaveChangesAsync();
        return result > 0 ? book : null;
    }

    public async Task Update(Book book)
    {
        book.ImageUrl = book.ImageUrl;
        book.Description = book.Description;
        book.Title = book.Title;
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Book book)
    {
        _context.Remove(book);
        await _context.SaveChangesAsync();
    }
}