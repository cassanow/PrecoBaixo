using System.ComponentModel.DataAnnotations;

namespace PreçoBaixo.Models;

public class Usuarios
{
    [Key]
    public int Id { get; set; } 
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(50, ErrorMessage = "O nome não deve ter mais de 50 caracteres")]
    public string Nome { get; set; }    
    
    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres")]
    public string Senha { get; set; }   
    
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
}