using PracticaBNA.Modelos;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticaBNA.Utils
{
    public abstract class Utilidades
    {
        public enum FormatoDeImpresion { ShortFormat, LongFormat }

        internal static List<Registro> ObtenerRegistros(string rutaDeArchivo)
        {
            int linea=0;
            string entrada;
            IEntrada entradaDeArchivo = new EntradaDeArchivo(rutaDeArchivo);
            List<Registro> registros = new List<Registro>();

            while ((entrada = entradaDeArchivo.ObtenerLinea()) != null)
            {
                if(entrada.Length==25)
                registros.Add(new Registro(entrada, linea));
                linea++;
            }

            return registros;
        }

        internal static (string rutaDeArchivo, FormatoDeImpresion formatoDeImpresion)  ProcesarParametros(string[] parametros)
        {
            (string rutaDeArchivo, FormatoDeImpresion formatoDeImpresion) parametrosValido = (null, FormatoDeImpresion.LongFormat);

            if (parametros.Length < 1 || parametros.Length > 2)
                throw new ArgumentException("Se requieren dos parametros.");

            else
            {
                if (parametros.Length > 1)
                {
                    try
                    {
                        parametrosValido.formatoDeImpresion = BuscarFormatoDeImpresion(parametros[1]);
                    }
                    catch 
                    {
                        throw new ArgumentException($"{parametros[1]} Es un formato de impresión invalido.");
                    }
                }
                if (!File.Exists(parametros[0]))
                    throw new ArgumentException($"El Archivo \"{parametros[0]}\" no existe.");
                parametrosValido.rutaDeArchivo = parametros[0];
            }

            return parametrosValido;
        }

        internal static FormatoDeImpresion BuscarFormatoDeImpresion(string formato)
        {
            if (int.TryParse(formato,out _))
                throw new ArgumentException("El parametro de impresion no puede ser numerico.");
            FormatoDeImpresion formatoValido = (FormatoDeImpresion)System.Enum.Parse(typeof(FormatoDeImpresion), formato);
            Console.WriteLine(formatoValido);
            return formatoValido;
        }

        internal static void ImprimirRegistros(List<Registro> registros, FormatoDeImpresion formato)
        {
            foreach (Registro registro in registros)
            {
                registro.Imprimir(formato);
            }
        }
    }
}