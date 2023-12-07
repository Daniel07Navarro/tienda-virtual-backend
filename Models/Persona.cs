namespace BackendTiendaVirtual.Models;

public class Persona
{
    
    public int? Id { get; set; }
    public string Nombres { get; set; } = null!;
    public int Edad { get; set; }
    public string Correo { get; set; } = null!;
    public String Dni { get; set; } = null!;
    public bool Estado { get; set; } = true;
}
