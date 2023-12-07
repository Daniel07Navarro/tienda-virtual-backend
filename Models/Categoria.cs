namespace BackendTiendaVirtual.Models;

public class Categoria
{
    
    public int? Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public bool Estado { get; set; } = true;
}
