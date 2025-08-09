using System.ComponentModel.DataAnnotations;

namespace PreçoBaixo.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    public List<Produtos> Produtos { get; set; }
}