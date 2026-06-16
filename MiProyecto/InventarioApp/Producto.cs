namespace InventarioApp;

public class Producto
{
    // Propiedades auto-implementadas
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Precio { get; set; } // Usamos decimal para precisión monetaria
    public int Cantidad { get; set; }

    // Constructor para inicializar el producto
    public Producto(int id, string nombre, string categoria, decimal precio, int cantidad)
    {
        Id = id;
        Nombre = nombre;
        Categoria = categoria;
        Precio = precio;
        Cantidad = cantidad;
    }

    // Sobrescribimos ToString para que se imprima bonito en la consola
    public override string ToString()
    {
        return $"[{Id}] {Nombre,-20} | {Categoria,-12} | ${Precio,8:F2} | Stock: {Cantidad}";
    }
}