using PracticaBNA.Modelos;
using PracticaBNA.Utils;

namespace PracticaBNA
{
    class Programa
    {
        static void Main(string[] args)
        {
            string formatoDeImpresion = Utilidades.ProcesarParametros(args);

            Registro registro = Utilidades.ObtenerRegistro();
            registro.Imprimir(formatoDeImpresion);
            Console.ReadKey();
        }
    }
}