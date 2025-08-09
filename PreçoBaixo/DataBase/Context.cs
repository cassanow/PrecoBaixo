using Microsoft.EntityFrameworkCore;
using PreçoBaixo.Models;

namespace PreçoBaixo.DataBase;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base (options) {}
    
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Lojas> Lojas { get; set; }
    public DbSet<Ofertas> Ofertas { get; set; }
    public DbSet<Produtos> Produtos { get; set; }
    
}