using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PreçoBaixo.DataBase;

namespace PreçoBaixoTest.Model;

public class DbFixture : IDisposable
{
    public Context Context {get; set;}
    public SqliteConnection Connection {get; set;}

    public DbFixture()
    {
        Connection  = new SqliteConnection("Datasource=:memory:");
        Connection.Open();
        
        var options = new DbContextOptionsBuilder<Context>()
            .UseSqlite(Connection)
            .Options;
        
        Context = new Context(options);
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Dispose();
        Connection.Dispose();
    }

    public void Limpar()
    {
        Context.Usuarios.RemoveRange(Context.Usuarios); 
        Context.SaveChanges();  
    }
}