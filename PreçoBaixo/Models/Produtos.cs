using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreçoBaixo.Models;

public class Produtos
{
    [Key]
    public int Id { get; set; }
    
    [Required]  
    [MaxLength(50)]
    public string Nome { get; set; }
    
    [Required]
    [MaxLength(1000)]
    public string Descricao { get; set; }   
    
    public int CategoriaId { get; set; }
    
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}