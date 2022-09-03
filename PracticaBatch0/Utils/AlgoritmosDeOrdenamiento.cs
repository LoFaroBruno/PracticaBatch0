using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaBNA.Modelos;

namespace PracticaBNA.Utils
{
    internal class AlgoritmosDeOrdenamiento
    {
        public enum AlgoritmoDeOrdenamiento { Bubblesort, Delegate, LinQ }
        internal static AlgoritmoDeOrdenamiento ObtenerAlgoritmoDeOrdenamiento()
        {
            String opcion = "LinQ";
            AlgoritmoDeOrdenamiento algoritmo;
            algoritmo = BuscarAlgoritmoDeOrdenamiento(opcion);
            return algoritmo;
        }
        internal static AlgoritmoDeOrdenamiento BuscarAlgoritmoDeOrdenamiento(string algoritmoDeOrdenamiento)
        {
            bool esValido = false;
            int i;
            AlgoritmoDeOrdenamiento[] algoritmos = (AlgoritmoDeOrdenamiento[])Enum.GetValues(typeof(AlgoritmoDeOrdenamiento));
            for (i = 0; i < algoritmos.Length && !esValido;)
            {
                if (algoritmoDeOrdenamiento.ToLower().Equals(algoritmos[i].ToString().ToLower()))
                    esValido = true;
                if (!esValido)
                    i++;
            }
            if (!esValido)
                throw new Exception("Algoritmo de ordenamiento invalido.");
            return algoritmos[i];
        }
        public static List<Registro> Ordenar(List<Registro> registros)
        {
            AlgoritmoDeOrdenamiento algoritmo = ObtenerAlgoritmoDeOrdenamiento();
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
            return registros.OrderByDescending(x => x.fecha).ToList();
        }
    }
}
