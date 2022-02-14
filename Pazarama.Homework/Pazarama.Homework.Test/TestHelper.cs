using Microsoft.EntityFrameworkCore;
using Pazarama.Homework.Data;
using Pazarama.Homework.Data.Repositories;

namespace Pazarama.Homework.Test;

public class TestHelper
{
    public readonly DatabaseContext _context;
    public TestHelper()
    {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");

        var dbContextOptions = builder.Options;
        _context = new DatabaseContext(dbContextOptions);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public (DataRepository, DatabaseContext) GetInMemoryDataRepository()
    {
        return (new DataRepository(_context),_context);
    }
}