using PracticaBNA.Modelos;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticaBNA.Utils
{
    public abstract class Utilidades
    {
        internal static List<Registro> ObtenerRegistros()
        {
            string linea;
            EntradaDeUsuario entradaDeUsuario = new EntradaDeUsuario();
            List<Registro> registros = new List<Registro>();

            while ((linea = entradaDeUsuario.ObtenerLinea()) != null)
                registros.Add(new Registro(linea));

            return registros;
        }

        public enum FormatoDeImpresion { ShortFormat, LongFormat }

        internal static string ProcesarParametros(string[] parametros)
        {
            string parametroValido = "LongFormat";

            if (parametros.Length > 1)
                throw new ArgumentException("1 argument admited.");

            else
            {
                if (parametros.Length == 1)
                {
                    if (!EsFormatoDeImpresionValido(parametros[0]))
                        throw new ArgumentException("Invalid specified format.");
                    parametroValido = parametros[0];
                }
            }

            return parametroValido;
        }

        internal static bool EsFormatoDeImpresionValido(string format)
        {
            bool isValid = false;
            string[] names = Enum.GetNames(typeof(FormatoDeImpresion));
            for (int i = 0; i < names.Length; i++)
            {
                if (format.ToLower().Equals(names[i].ToLower()))
                    isValid = true;
            }
            return isValid;
        }

        internal static void ImprimirRegistros(List<Registro> registros, string formato)
        {
            foreach (Registro registro in registros)
            {
                registro.Imprimir(formato);
            }
        }
    }

}