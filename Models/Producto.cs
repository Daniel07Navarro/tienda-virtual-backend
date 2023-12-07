namespace BackendTiendaVirtual.Models;

public class Producto
{

    public int? Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
    public int Stock { get; set; }
    public string Imagen { get; set; } = null!;
    public Categoria Categoria { get; set; } = null!;
    public bool Estado { get; set; } = true;
}
