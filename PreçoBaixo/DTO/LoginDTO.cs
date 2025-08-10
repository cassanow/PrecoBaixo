using System.ComponentModel.DataAnnotations;

namespace PreçoBaixo.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; }
}