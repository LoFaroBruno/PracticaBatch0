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
    }

}