using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace InventarioApp;

public class InventarioService
{
    private List<Producto> _productos = new();
    private int _nextId = 1;

    public void Agregar(string nombre, string categoria, decimal precio, int cantidad)
    {
        var p = new Producto(_nextId++, nombre, categoria, precio, cantidad);
        _productos.Add(p);
        Console.WriteLine($"Producto agregado con ID {p.Id}.");
    }

    public void Eliminar(int id)
    {
        var p = _productos.FirstOrDefault(x => x.Id == id);
        if (p is null) { Console.WriteLine("ID no encontrado."); return; }
        _productos.Remove(p);
        Console.WriteLine("Producto eliminado.");
    }

    public void MostrarTodos()
    {
        if (_productos.Count == 0) { Console.WriteLine("Inventario vacío."); return; }
        foreach (var p in _productos) Console.WriteLine(p);
    }

    public void FiltrarPorCategoria(string categoria)
    {
        var resultado = _productos
            .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Nombre)
            .ToList();
        Console.WriteLine($"\nProductos en '{categoria}': {resultado.Count}");
        resultado.ForEach(Console.WriteLine);
    }

    public void BuscarPorNombre(string texto)
    {
        var resultado = _productos
            .Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase))
            .ToList();
        if (resultado.Count == 0) Console.WriteLine("No se encontraron productos.");
        else resultado.ForEach(Console.WriteLine);
    }

    public void OrdenarPorPrecio(bool descendente = false)
    {
        var query = descendente 
            ? _productos.OrderByDescending(p => p.Precio) 
            : _productos.OrderBy(p => p.Precio);
        
        if (!_productos.Any()) { Console.WriteLine("Inventario vacío."); return; }
        query.ToList().ForEach(Console.WriteLine);
    }

    public void MostrarResumen()
    {
        if (_productos.Count == 0) { Console.WriteLine("Inventario vacío."); return; }
        decimal valorTotal = _productos.Sum(p => p.Precio * p.Cantidad);
        decimal precioPromedio = _productos.Average(p => p.Precio);
        var masCaro = _productos.MaxBy(p => p.Precio);
        var masBarato = _productos.MinBy(p => p.Precio);
        int totalUnidades = _productos.Sum(p => p.Cantidad);
        var categorias = _productos.Select(p => p.Categoria).Distinct().OrderBy(c => c);

        Console.WriteLine("\n=== RESUMEN DEL INVENTARIO ===");
        Console.WriteLine($"Total de productos: {_productos.Count}");
        Console.WriteLine($"Total de unidades: {totalUnidades}");
        Console.WriteLine($"Valor total: ");
        Console.WriteLine($"Precio promedio: ");
        Console.WriteLine($"Más caro: {masCaro?.Nombre} ()");
        Console.WriteLine($"Más barato: {masBarato?.Nombre} ()");
        Console.WriteLine($"Categorías: {string.Join(", ", categorias)}");
    }

    public void UpdateProducto(int id, decimal? nuevoPrecio, int? nuevaCantidad)
    {
        var p = _productos.FirstOrDefault(x => x.Id == id);
        if (p is null) { Console.WriteLine("Error: Producto no encontrado."); return; }
        if (nuevoPrecio.HasValue) p.Precio = nuevoPrecio.Value;
        if (nuevaCantidad.HasValue) p.Cantidad = nuevaCantidad.Value;
        Console.WriteLine("Producto actualizado con éxito.");
    }

    public void MostrarStockBajo(int umbral)
    {
        var bajoStock = _productos.Where(p => p.Cantidad <= umbral).OrderBy(p => p.Cantidad).ToList();
        if (bajoStock.Count == 0) { Console.WriteLine($"No hay productos con stock bajo."); return; }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n--- ALERTAS DE STOCK BAJO ---");
        foreach (var p in bajoStock) Console.WriteLine(p);
        Console.ResetColor();
    }

    public void GuardarInventario(string path)
    {
        try
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_productos, opciones);
            File.WriteAllText(path, jsonString);
            Console.WriteLine("Inventario guardado exitosamente en JSON.");
        }
        catch (Exception ex) { Console.WriteLine($"Error al guardar: {ex.Message}"); }
    }

    public void CargarInventario(string path)
    {
        if (!File.Exists(path)) return;
        try
        {
            string jsonString = File.ReadAllText(path);
            var listaCargada = JsonSerializer.Deserialize<List<Producto>>(jsonString);
            if (listaCargada != null && listaCargada.Count > 0)
            {
                _productos = listaCargada;
                _nextId = _productos.Max(p => p.Id) + 1;
                Console.WriteLine($"Se cargaron {_productos.Count} productos.");
            }
        }
        catch (Exception ex) { Console.WriteLine($"Error al cargar: {ex.Message}"); }
    }
}
