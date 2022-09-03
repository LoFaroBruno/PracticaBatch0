using PracticaBNA.Modelos;
using PracticaBNA.Utils;

namespace PracticaBNA
{
    class Program
    {
        static void Main(string[] args)
        {
            Registro registro = Utilidades.ObtenerRegistro();
            registro.Imprimir();
            Console.ReadKey();
        }
    }
}