using System.ComponentModel.DataAnnotations;

namespace PreçoBaixo.Models;

public class Lojas
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    
    [Required]
    public string URL { get; set; }
    
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}