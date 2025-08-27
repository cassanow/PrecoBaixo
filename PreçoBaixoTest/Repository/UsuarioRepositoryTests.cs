using Microsoft.EntityFrameworkCore;
using PreçoBaixo.Models;
using PreçoBaixo.Repository;
using PreçoBaixo.Repository.Interface;
using PreçoBaixoTest.Model;

namespace PreçoBaixoTest.Repository;

public class UsuarioRepositoryTests : IClassFixture<DbFixture>
{
    
    private readonly DbFixture _context;
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioRepositoryTests(DbFixture context)
    {
        _context = context;
        _context.Limpar();
        _usuarioRepository = new UsuarioRepository(_context.Context);
    }

    private Usuarios CriarUsuario()
    {
        return new Usuarios
        {
            Id = 1,
            Nome = "Arthur",
            Email = "arthur@gmail.com",
            Senha = "123456",
            DataCadastro = DateTime.Now,
        };
    }
    
    [Fact]
    public async Task DeveRetornarUsuarios()
    {
        var usuario = CriarUsuario();
        await _usuarioRepository.AddUsuario(usuario);
        
        var usuarios =  await _context.Context.Usuarios.ToListAsync();
        Assert.NotNull(usuarios);
        Assert.NotEmpty(usuarios);
        Assert.Equal(usuario.Nome, usuarios[0].Nome);
    }
    
    [Fact]
    public async Task DeveAdicionarUsuario()
    {
        var usuario =  CriarUsuario();
        
        await _usuarioRepository.AddUsuario(usuario);
        
        Assert.NotNull(usuario);
        Assert.Equal("Arthur", usuario.Nome);
        Assert.Equal("arthur@gmail.com", usuario.Email); 
        Assert.Equal("123456", usuario.Senha);
    }

    [Fact]
    public async Task  DeveBuscarPorId()
    {
        var usuario = CriarUsuario();
        await _usuarioRepository.AddUsuario(usuario);

        var resultado = await _usuarioRepository.ObterPorId(usuario.Id);
        Assert.NotNull(resultado);
        Assert.Equal(usuario.Email, resultado.Email);
    }
    
    [Fact]
    public async Task DeveBuscarPorEmail()
    {
        var usuario = CriarUsuario();
        await _usuarioRepository.AddUsuario(usuario);
        
        var resultado = await _usuarioRepository.ObterPorEmail(usuario.Email);
        Assert.NotNull(resultado);
        Assert.Equal(usuario.Email, resultado.Email);
    }

    [Fact]
    public async Task DeveRemoverUsuario()
    {
        var usuario = CriarUsuario();
        await _usuarioRepository.AddUsuario(usuario);
        
        var resultado = await _usuarioRepository.ObterPorId(usuario.Id);
        await _usuarioRepository.DeleteUsuario(resultado);
        
        var usuarioRemovido = await  _usuarioRepository.ObterPorId(usuario.Id);
        Assert.Null(usuarioRemovido);
    }
}