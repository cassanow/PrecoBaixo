using Microsoft.EntityFrameworkCore;
using PreçoBaixo.Models;

namespace PreçoBaixo.DataBase;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base (options) {}
    
    public DbSet<Usuarios> Usuarios { get; set; }
    
}