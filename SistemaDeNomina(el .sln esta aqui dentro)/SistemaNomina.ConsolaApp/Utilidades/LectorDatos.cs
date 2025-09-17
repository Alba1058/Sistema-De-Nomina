using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.ConsolaApp.Utilidades
{
    public class LectorDatos
    {
        public static string LeerTexto(string mensaje)
        {
            string valor;
            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("El texto no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(valor));

            return valor;
        }

        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                {
                    return valor;
                }
                Console.WriteLine("Entrada inválida. Ingrese un número entero mayor que 0.");
            }
        }

        public static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out valor) && valor > 0)
                {
                    return valor;
                }
                Console.WriteLine("Entrada inválida. Ingrese un número decimal mayor que 0.");
            }
        }
    }
}
