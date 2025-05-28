global using Xunit;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Projeto001.Infraestrutura.Data;


public class DatabaseFixture : IDisposable
{
    private string _connectionString = ""; //Coloque sua connection string aqui
    private Projeto001Context _context;
    private IDbContextTransaction _transaction;

    public Projeto001Context CreateContext()
    {
        var options = new DbContextOptionsBuilder<Projeto001Context>()
            .UseSqlServer(_connectionString)
            .Options;
        _context = new Projeto001Context(options);
        _context.Database.EnsureCreated();
        _transaction = _context.Database.BeginTransaction();
        return _context;
    }

    public void Dispose()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        _context.Dispose();
    }
}