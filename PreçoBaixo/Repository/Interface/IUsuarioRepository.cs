using PreçoBaixo.Models;

namespace PreçoBaixo.Repository.Interface;

public interface IUsuarioRepository
{
    Task <IList<Usuarios>> Listar();
    
    Task<Usuarios> ObterPorId(int id);
    
    Task<Usuarios> ObterPorEmail(string email);
    
    Task <bool> UsuarioExiste(int id);
    
    Task AddUsuario(Usuarios usuario);
    
    Task EditUsuario(Usuarios usuario);
    
    Task DeleteUsuario(Usuarios usuario);
    
}