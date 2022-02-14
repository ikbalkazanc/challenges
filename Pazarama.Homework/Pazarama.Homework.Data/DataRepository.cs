using Pazarama.Homework.Data.Repositories;

namespace Pazarama.Homework.Data;

public class DataRepository
{
    private DatabaseContext _context;
    public DataRepository(DatabaseContext context)
    {
        _context = context;
        _bookRepository = new Lazy<BookRepository>(() => new BookRepository(_context));
        
    }
    private Lazy<BookRepository> _bookRepository;
    public BookRepository BookRepository => _bookRepository.Value;
}