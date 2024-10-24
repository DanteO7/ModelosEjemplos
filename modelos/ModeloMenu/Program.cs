public static class Gestor
{
    public static readonly string Archivo;

    public static void Agregar()
    {

    }

    public static void Eliminar()
    {

    }

    public static void Modificar()
    {

    }

    public static void Mostrar()
    {

    }

    public static void GuardarDatos<T>(T entidad, bool append) where T : class
    {
        using StreamWriter writer = new StreamWriter(Archivo, append);
        writer.WriteLine(entidad);
    }

    public static void GuardarDatos<T>(Dictionary<int, T> entidades, bool append) where T : class
    {
        using StreamWriter writer = new StreamWriter(Archivo, append);
        foreach (var entidad in entidades.Values)
        {
            writer.WriteLine(entidad);
        }
    }

    public static List<string> ConvertirArchivoEnLista(string archivo)
    {
        List<string> lineas = new();
        if (File.Exists(archivo))
        {
            foreach (var linea in File.ReadAllLines(archivo))
            {
                lineas.Add(linea);
            }
        }
        return lineas;
    }

    public static void CargarDatos(string archivo, string separador)
    {
        try
        {
            List<string> lineas = ConvertirArchivoEnLista(archivo);

            if (lineas.Count <= 0)
            {
                return;
            }

            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(separador);

                ///// desde aca es personalizado dependiendo del ejercicio ///////////
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar datos desde el archivo {archivo}: {ex.Message}");
        }
    }
}


public static class Menu
{
    static List<Action> Acciones = new List<Action>
        {
            Agregar,
            Eliminar,
            Modificar,
            Mostrar
        };

    public static void MostrarMenu()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n----- Menú -----\n" +
                "1. Agregar Producto\n" +
                "2. Eliminar Producto\n" +
                "3. Modificar Producto\n" +
                "4. Mostrar Productos\n" +
                "5. Salir\n");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
            {
                if (indice == Acciones.Count + 1)
                {
                    Console.WriteLine("Saliendo...");
                    salir = true;
                }
                else
                {
                    Acciones[indice - 1].Invoke();
                }
            }
        }
    }

    public static void Agregar()
    {

    }

    public static void Eliminar()
    {

    }

    public static void Modificar()
    {

    }

    public static void Mostrar()
    {

    }
}