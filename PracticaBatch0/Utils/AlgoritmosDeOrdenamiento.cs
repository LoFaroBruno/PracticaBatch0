using PracticaBNA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaBNA.Utils
{
    internal class AlgoritmosDeOrdenamiento
    {
        public enum AlgoritmoDeOrdenamiento { Bubblesort, Delegate, LinQ }
        
        internal static AlgoritmoDeOrdenamiento BuscarAlgoritmoDeOrdenamiento()
        {
            string algoritmoDeOrdenamiento = System.Configuration.ConfigurationManager.AppSettings["AlgoritmoDeOrdenamiento"];
            if (int.TryParse(algoritmoDeOrdenamiento, out _))
                throw new ArgumentException("El parametro de impresion no puede ser numerico.");
            AlgoritmoDeOrdenamiento algoritmoValido = (AlgoritmoDeOrdenamiento)System.Enum.Parse(typeof(AlgoritmoDeOrdenamiento), algoritmoDeOrdenamiento);
            Console.WriteLine(algoritmoValido);
            return algoritmoValido;
        }
        
        public static List<Registro> Ordenar(List<Registro> registros)
        {
            AlgoritmoDeOrdenamiento algoritmo = BuscarAlgoritmoDeOrdenamiento();
            if (!System.Enum.IsDefined(typeof(AlgoritmoDeOrdenamiento), algoritmo))
                throw new Exception("No existe el algoritmo de ordenamiento especificado.");
            
            switch (algoritmo)
            {
                case AlgoritmoDeOrdenamiento.Bubblesort:
                    return OrdenarPorBubbleSort(registros);
                case AlgoritmoDeOrdenamiento.Delegate:
                    return OrdenarPorDelegate(registros);
                case AlgoritmoDeOrdenamiento.LinQ:
                    return OrdenarPorLinq(registros);
                default:
                    return OrdenarPorLinq(registros);
            }
        }

        private static List<Registro> OrdenarPorDelegate(List<Registro> registros)
        {
            registros.Sort(
                delegate (Registro registro1, Registro registro2)
                {
                    return registro2.fecha.CompareTo(registro1.fecha);
                });
            return registros;
        }

        private static List<Registro> OrdenarPorBubbleSort(List<Registro> registros)
        {
            Registro temporal;
            for (int i = 0; i <= registros.Count - 2; i++)
            {
                for (int j = 0; j <= registros.Count - 2; j++)
                {
                    if (registros[j].fecha < registros[j + 1].fecha)
                    {
                        temporal = registros[j + 1];
                        registros[j + 1] = registros[j];
                        registros[j] = temporal;
                    }
                }
            }

            return registros;
        }


        private static List<Registro> OrdenarPorLinq(List<Registro> registros)//no funciona
        {
            try
            {
                return registros.OrderByDescending(x => x.fecha).ToList();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException("No hay registros insertados para ordenar",e);
            }
        }
    }
}
