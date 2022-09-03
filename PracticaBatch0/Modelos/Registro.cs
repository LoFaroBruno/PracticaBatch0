using PracticaBNA.Utils;

namespace PracticaBNA.Modelos
{
    internal class Registro
    {
        private string fechaString;
        public DateTime fecha;
        private double temperatura;
        private double humedad;
        private string codigo;
        private byte estado;
        int linea;

        public Registro(string entrada, int linea)
        {
            fechaString = entrada.Substring(0, 14);
            fecha = DateTime.ParseExact(fechaString, "yyyyMMddHHmmss", null);
            temperatura = double.Parse(entrada.Substring(14, 3)) / 10;
            if (temperatura < 0)
                throw new FormatException($"Temperatura no puede ser negativa. linea nro: {linea}.");
            humedad = double.Parse(entrada.Substring(17, 3)) / 10;
            if (humedad < 0)
                throw new FormatException($"humedad no puede ser negativa. linea nro: {linea}.");
            codigo = entrada.Substring(20, 4);
            estado = byte.Parse(entrada.Substring(24));
            if (estado > 1 || estado < 0)
                throw new FormatException($"estado debe ser 0 o 1. linea nro: {linea}.");
            this.linea = linea;
        }

        public void Imprimir(Utilidades.FormatoDeImpresion formatoDeImpresion)
        {
            string output = "";
            if (String.Equals(formatoDeImpresion, Utilidades.FormatoDeImpresion.ShortFormat))
                output += "\nFecha del registro: " + fecha.ToString("yyyy/MM/dd", null) +
                "\nHora del registro: " + fecha.ToString("HH'Hs':mm'Min':ss'Seg'", null);
            else
                output += "\nFecha/Hora registro: " + fecha.ToString("yyyy/MM/dd HH:mm:ss", null);
            Console.Write(output +
                        "\nTemperatura: " + temperatura + "°" +
                        "\nHumedad: " + humedad + "%" +
                        "\nCodigo: " + codigo +
                        "\nActivo: ");
            Console.Write(estado == 1 ? "SI" : "NO");
            Console.Write("\n*********************");
        }
    }
}