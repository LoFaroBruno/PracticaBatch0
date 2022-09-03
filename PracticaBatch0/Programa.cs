using PracticaBNA.Modelos;
using PracticaBNA.Utils;

namespace PracticaBNA
{
    class Programa
    {
        static void Main(string[] args)
        {
            string formatoDeImpresion;

            formatoDeImpresion = Utilidades.ProcesarParametros(args);

            List<Registro> registros = Utilidades.ObtenerRegistros();

            Utilidades.ImprimirRegistros(AlgoritmosDeOrdenamiento.Ordenar(registros), formatoDeImpresion);
            Console.ReadKey();
        }
    }
}