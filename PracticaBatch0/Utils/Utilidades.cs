using PracticaBNA.Modelos;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticaBNA.Utils
{
    public abstract class Utilidades
    {
        internal static Registro ObtenerRegistro()
        {
            EntradaDeUsuario Entrada = new EntradaDeUsuario();
            return new Registro(Entrada.ObtenerLinea());
        }

        public enum FormatoDeImpresion { ShortFormat, LongFormat }

        internal static string ProcesarParametros(string[] parametros)
        {
            string validArg = "LongFormat";

            if (parametros.Length > 1)
                throw new ArgumentException("1 argument admited.");

            else
            {
                if (parametros.Length == 1)
                {
                    if (!EsFormatoDeImpresionValido(parametros[0]))
                        throw new ArgumentException("Invalid specified format.");
                    validArg = parametros[0];
                }
            }

            return validArg;
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
    }

}