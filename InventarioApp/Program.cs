using System;

var servicio = new InventarioService();

servicio.Agregar("Laptop HP 15", "Electrónica", 1299.99m, 15);
servicio.Agregar("Mouse Logitech MX3", "Electrónica", 89.99m, 40);
servicio.Agregar("Camiseta Polo", "Ropa", 24.99m, 100);
servicio.Agregar("Arroz Integral 1kg", "Alimentos", 3.49m, 200);
servicio.Agregar("Silla Ergonómica", "Muebles", 349.00m, 8);

string opcion;

do
{
    Console.WriteLine("\n=== INVENTARIO APP ===");
    Console.WriteLine("[1] Mostrar todos los productos");
    Console.WriteLine("[2] Agregar nuevo producto");
    Console.WriteLine("[3] Eliminar producto por ID");
    Console.WriteLine("[4] Filtrar por categoría");
    Console.WriteLine("[5] Buscar por nombre");
    Console.WriteLine("[6] Mostrar resumen del inventario");
    Console.WriteLine("[0] Salir");
    Console.Write("\nSeleccione una opción: ");

    opcion = Console.ReadLine() ?? "0";

    switch (opcion)
    {
        case "1":
            servicio.MostrarTodos();
            break;
        case "2":
            Console.Write("Nombre del producto: ");
            var nombre = Console.ReadLine()!;
            Console.Write("Categoría: ");
            var cat = Console.ReadLine()!;
            Console.Write("Precio: ");
            var precio = decimal.Parse(Console.ReadLine()!);
            Console.Write("Cantidad inicial: ");
            var cant = int.Parse(Console.ReadLine()!);
            servicio.Agregar(nombre, cat, precio, cant);
            break;
        case "3":
            Console.Write("ID a eliminar: ");
            servicio.Eliminar(int.Parse(Console.ReadLine()!));
            break;
        case "4":
            Console.Write("Categoría: ");
            servicio.FiltrarPorCategoria(Console.ReadLine()!);
            break;
        case "5":
            Console.Write("Texto a buscar: ");
            servicio.BuscarPorNombre(Console.ReadLine()!);
            break;
        case "6":
            servicio.MostrarResumen();
            break;
        case "0":
            Console.WriteLine("Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
} while (opcion != "0");
