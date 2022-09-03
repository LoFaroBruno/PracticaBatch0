using System;

namespace PracticaBNA
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
            while (entrada.Length != 25 || entrada == null);
            return entrada;
        }
    }

}