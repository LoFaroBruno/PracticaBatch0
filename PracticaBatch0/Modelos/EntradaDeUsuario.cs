using System;

namespace PracticaBNA.Modelos
{
    public class EntradaDeUsuario
    {
        public string ObtenerLinea()
        {
            string entrada;
            do
            {
                Console.WriteLine("Ingrese los datos: ");
                entrada = Console.ReadLine();
            }
            while (entrada.Length != 0 && entrada.Length != 25);
            if (entrada.Length == 0)
                return null;
            return entrada;
        }
    }

}