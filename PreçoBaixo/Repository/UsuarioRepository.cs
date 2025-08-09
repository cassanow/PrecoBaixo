using System.Collections;
using Microsoft.EntityFrameworkCore;
using PreçoBaixo.DataBase;
using PreçoBaixo.Models;
using PreçoBaixo.Repository.Interface;

namespace PreçoBaixo.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly Context _context;

    public UsuarioRepository(Context context)
    {
        _context = context;
    }
    
    public async Task <IList<Usuarios>> Listar()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuarios> ObterPorId(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Usuarios> ObterPorEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> UsuarioExiste(int id)
    {
        return await _context.Usuarios.AnyAsync(x => x.Id == id);
    }

    public async Task AddUsuario(Usuarios usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task EditUsuario(Usuarios usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuario(Usuarios usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}