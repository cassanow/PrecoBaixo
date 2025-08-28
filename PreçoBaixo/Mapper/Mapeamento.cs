using PreçoBaixo.DTO;
using PreçoBaixo.Models;

namespace PreçoBaixo.Helper;

public class Mapeamento
{
    public static Usuarios LoginToUser(LoginDTO dto)
    {
        return new Usuarios
        {
            Email = dto.Email,
            Senha = dto.Senha
        };
    }

    public static LoginDTO UsuarioToDTO(Usuarios usuarios)
    {
        return new LoginDTO
        {
            Email = usuarios.Email,
            Senha = usuarios.Senha
        };
    }
}