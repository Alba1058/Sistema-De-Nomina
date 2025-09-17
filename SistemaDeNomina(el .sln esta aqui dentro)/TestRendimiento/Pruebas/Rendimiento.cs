using SistemaNomina.Application.Servicios;
using SistemaNomina.Domain.Empleados;
using SistemaNomina.Domain.Tipos_de_empleados;
using SistemaNomina.Infrastructure.Repositorios;
using System;
using System.Diagnostics;

namespace TestRendimiento.Pruebas
{
    public class Rendimiento
    {
        public static void Main()
        {
            var repositorio = new RepositorioMemoria();
            var servicioNomina = new ServicioNomina(repositorio);

            Console.WriteLine("Generando 10,000 empleados de prueba...\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i <= 10000; i++)
            {
                var emp = new EmpleadoAsalariado(
                $"Nombre{i}",
                $"Apellido{i}",
                 $"NSS{i:D5}", 
                1000.00m + i   
 );

                servicioNomina.RegistrarEmpleado(emp);
            }

            stopwatch.Stop();
            double tiempoAgregar = stopwatch.Elapsed.TotalSeconds;

            foreach (var emp in repositorio.ListarEmpleados())
            {
                Console.WriteLine(emp);
                Console.WriteLine($"Pago: {emp.Ingresos():C}\n");
            }

            Console.WriteLine("\nPresione ENTER para continuar con el cálculo de nómina...");
            Console.ReadLine();
            Console.Clear();

       
            // Medicion de tiempo de cálculo pagos
            stopwatch.Reset();
            stopwatch.Start();

            var empleados = repositorio.ListarEmpleados();
            foreach (var emp in empleados)
            {
                _ = emp.Ingresos(); 
            }

            stopwatch.Stop();
            double tiempoProcesar = stopwatch.Elapsed.TotalSeconds;

          
            Console.WriteLine($"Se agregaron {empleados.Count} empleados.");
            Console.WriteLine($"Tiempo que tardó en agregar: {tiempoAgregar} segundos");
            Console.WriteLine($"Tiempo que tardó en procesar pagos: {tiempoProcesar} segundos");

            Console.WriteLine("\nPrueba finalizada. Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
