using System.ComponentModel.DataAnnotations;

namespace PreçoBaixo.Models;

public class Ofertas
{
    [Key]
    public int Id { get; set; } 
    
    public int ProdutoId { get; set; }
    
    public int LojaId { get; set; }
    
    public string Preco { get; set; }
    
    [MaxLength(500)]
    public string URL { get; set; }
    
    public DateTime DataColeta { get; set; } = DateTime.Now;
}