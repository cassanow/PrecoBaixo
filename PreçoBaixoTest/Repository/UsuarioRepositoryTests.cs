using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PreçoBaixo.DataBase;
using PreçoBaixo.Models;
using PreçoBaixo.Repository;

namespace PreçoBaixoTest.Repository;

public class UsuarioRepositoryTests 
{
    private DbContextOptions<Context> CriarOptions(SqliteConnection connection)
    {
        return  new DbContextOptionsBuilder<Context>()
            .UseSqlite(connection)
            .Options;           
    }
    
    [Fact]
    public void DeveRetornarUsuarios()
    {
        var connection = new SqliteConnection("DataSource=:memory:");   
        connection.Open();  
        
        var options = CriarOptions(connection); 
        var context = new Context(options);
        context.Database.EnsureCreated();

        var repository = new UsuarioRepository(context);
        var usuario = new Usuarios
            { Nome = "Arthur", Email = "arthur@gmail.com", Senha = "123456", DataCadastro = DateTime.Now };
        repository.AddUsuario(usuario);
        
        var usuarios =  context.Usuarios.ToList();
        Assert.NotNull(usuarios);
        Assert.NotEmpty(usuarios);
        Assert.Single(usuarios);
        Assert.Equal("Arthur", usuarios[0].Nome);
    }
}