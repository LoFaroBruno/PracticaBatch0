using PracticaBNA.Modelos;
using PracticaBNA.Utils;

namespace PracticaBNA
{
    class Programa
    {
        static void Main(string[] args)
        {
            string formatoDeImpresion = Utilidades.ProcesarParametros(args);

            List<Registro> registros = Utilidades.ObtenerRegistros();
            Utilidades.ImprimirRegistros(registros, formatoDeImpresion);
            Console.ReadKey();
        }
    }
}