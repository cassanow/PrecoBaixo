using Microsoft.EntityFrameworkCore;

namespace PreçoBaixo.DataBase;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base (options) {}
    
}