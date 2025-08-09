using System.ComponentModel.DataAnnotations;

namespace PreçoBaixo.Models;

public class Usuarios
{
    [Key]
    public int Id { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string Nome { get; set; }    
    
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Senha { get; set; }   
    
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
}