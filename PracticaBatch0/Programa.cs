using PracticaBNA.Modelos;
using PracticaBNA.Utils;

namespace PracticaBNA
{
    class Programa
    {
        static void Main(string[] args)
        {
            (string rutaDeArchivo, Utilidades.FormatoDeImpresion formatoDeImpresion) opciones;

            try
            {
                opciones = Utilidades.ProcesarParametros(args);

                List<Registro> registros = Utilidades.ObtenerRegistros(opciones.rutaDeArchivo);

                Utilidades.ImprimirRegistros(AlgoritmosDeOrdenamiento.Ordenar(registros), opciones.formatoDeImpresion);
                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace, ex?.InnerException);
            }
        }
    }
}