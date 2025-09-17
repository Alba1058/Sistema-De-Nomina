using SistemaNomina.Application.Servicios;
using SistemaNomina.ConsolaApp.Utilidades;
using SistemaNomina.Domain.Empleados;
using SistemaNomina.Domain.Tipos_de_empleados;
using System;

namespace SistemaNomina.ConsolaApp.Menu
{
    public class MenuPrincipal
    {
        private readonly ServicioNomina servicio;

        public MenuPrincipal(ServicioNomina servicio)
        {
            this.servicio = servicio;
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA DE NÓMINA =====");
                Console.WriteLine("1. Registrar empleado");
                Console.WriteLine("2. Mostrar todos los empleados");
                Console.WriteLine("3. Actualizar empleado");
                Console.WriteLine("4. Eliminar empleado");
                Console.WriteLine("5. Buscar empleado por NSS");
                Console.WriteLine("6. Generar reporte");
                Console.WriteLine("7. Mostrar lista de pagos");
                Console.WriteLine("8. Salir");

                opcion = LectorDatos.LeerEntero("Seleccione una opción: ");

                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        RegistrarEmpleado();
                        break;
                    case 2:
                        MostrarTodosLosEmpleados();
                        break;
                    case 3:
                        ActualizarEmpleado();
                        break;
                    case 4:
                        EliminarEmpleado();
                        break;
                    case 5:
                        BuscarEmpleado();
                        break;
                    case 6:
                        Console.WriteLine(servicio.GenerarReporte());
                        break;
                    case 7:
                        MostrarListaDePagos();
                        break;
                    case 8:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 8)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 8);
        }

        private void RegistrarEmpleado()
        {
            Console.WriteLine("Seleccione tipo de empleado:");
            Console.WriteLine("1. Asalariado");
            Console.WriteLine("2. Por horas");
            Console.WriteLine("3. Por comisión");
            Console.WriteLine("4. Asalariado por comisión");

            int tipo = LectorDatos.LeerEntero("Opción: ");

            string nombre = LectorDatos.LeerTexto("Nombre: ");
            string apellido = LectorDatos.LeerTexto("Apellido: ");
            string nss = LectorDatos.LeerTexto("Número de seguro social: ");

            Empleado nuevo = null;

            switch (tipo)
            {
                // asalariado
                case 1: 
                    decimal salarioSemanal = LectorDatos.LeerDecimal("Salario semanal: ");
                    nuevo = new EmpleadoAsalariado(nombre, apellido, nss, salarioSemanal);
                    break;

                // por horas
                case 2: 
                    decimal sueldoHora = LectorDatos.LeerDecimal("Sueldo por hora: ");
                    decimal horas = LectorDatos.LeerDecimal("Horas trabajadas: ");
                    nuevo = new EmpleadoPorHoras(nombre, apellido, nss, sueldoHora, horas);
                    break;

                // por comisión
                case 3: 
                    decimal ventas = LectorDatos.LeerDecimal("Ventas brutas: ");
                    decimal tarifaInput = LectorDatos.LeerDecimal("Tarifa comisión (porcentaje, ej. 10 para 10%): ");
                    decimal tarifa = tarifaInput / 100;
                    nuevo = new EmpleadoPorComision(nombre, apellido, nss, ventas, tarifa);
                    break;

                // asalariado por comisión
                case 4: 
                    decimal ventas2 = LectorDatos.LeerDecimal("Ventas brutas: ");
                    decimal tarifa2Input = LectorDatos.LeerDecimal("Tarifa comisión (porcentaje, ej. 10 para 10%): ");
                    decimal tarifa2 = tarifa2Input / 100;
                    decimal salarioBase = LectorDatos.LeerDecimal("Salario base: ");
                    nuevo = new EmpleadoAsalariadoPorComision(nombre, apellido, nss, ventas2, tarifa2, salarioBase);
                    break;
            }

            if (nuevo != null)
            {
                servicio.RegistrarEmpleado(nuevo);
                Console.WriteLine("Empleado registrado con éxito.");
            }
        }


        private void MostrarTodosLosEmpleados()
        {
            var empleados = servicio.ObtenerEmpleados();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("=== LISTA DE EMPLEADOS ===");
            foreach (var emp in empleados)
            {
                Console.WriteLine(emp.ToString());
                Console.WriteLine($"Pago semanal: {emp.Ingresos():N2}");
                Console.WriteLine("-------------------------\n");

            }
        }

        private void EliminarEmpleado()
        {
            string nss = LectorDatos.LeerTexto("Ingrese NSS del empleado a eliminar: ");
            bool eliminado = servicio.EliminarEmpleado(nss);
            Console.WriteLine(eliminado ? "Empleado eliminado." : "Empleado no encontrado.");
        }

        private void BuscarEmpleado()
        {
            string nss = LectorDatos.LeerTexto("Ingrese NSS del empleado a buscar: ");
            var empleado = servicio.BuscarEmpleado(nss);

            if (empleado != null)
            {
                Console.WriteLine(empleado.ToString());
                Console.WriteLine("Pago semanal: " + empleado.Ingresos().ToString("C"));
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private void ActualizarEmpleado()
        {
            string nss = LectorDatos.LeerTexto("Ingrese el NSS del empleado a actualizar: ");
            var empleado = servicio.BuscarEmpleado(nss);

            if (empleado == null)
            {
                Console.WriteLine("Empleado no encontrado.");
                return;
            }

            Console.WriteLine("Empleado encontrado: " + empleado.ToString());

            string nombre = LectorDatos.LeerTexto("Nuevo nombre: ");
            string apellido = LectorDatos.LeerTexto("Nuevo apellido: ");

            Empleado actualizado = null;

            if (empleado is EmpleadoAsalariado)
            {
                decimal salario = LectorDatos.LeerDecimal("Nuevo salario semanal: ");
                actualizado = new EmpleadoAsalariado(nombre, apellido, nss, salario);
            }
            else if (empleado is EmpleadoPorHoras)
            {
                decimal sueldoHora = LectorDatos.LeerDecimal("Nuevo sueldo por hora: ");
                decimal horas = LectorDatos.LeerDecimal("Nuevas horas trabajadas: ");
                actualizado = new EmpleadoPorHoras(nombre, apellido, nss, sueldoHora, horas);
            }
            else if (empleado is EmpleadoPorComision)
            {
                decimal ventas = LectorDatos.LeerDecimal("Nuevas ventas brutas: ");
                decimal tarifaInput = LectorDatos.LeerDecimal("Nueva tarifa de comisión (porcentaje, ej. 10 para 10%): ");
                decimal tarifa = tarifaInput / 100;
                actualizado = new EmpleadoPorComision(nombre, apellido, nss, ventas, tarifa);
            }
            else if (empleado is EmpleadoAsalariadoPorComision)
            {
                decimal ventas = LectorDatos.LeerDecimal("Nuevas ventas brutas: ");
                decimal tarifaInput = LectorDatos.LeerDecimal("Nueva tarifa de comisión (porcentaje, ej. 10 para 10%): ");
                decimal tarifa = tarifaInput / 100;
                decimal salarioBase = LectorDatos.LeerDecimal("Nuevo salario base: ");
                actualizado = new EmpleadoAsalariadoPorComision(nombre, apellido, nss, ventas, tarifa, salarioBase);
            }

            if (actualizado != null && servicio.ActualizarEmpleado(actualizado))
                Console.WriteLine("Empleado actualizado correctamente.");
            else
                Console.WriteLine("No se pudo actualizar al empleado.");
        }

        private void MostrarListaDePagos()
        {
            var empleados = servicio.ObtenerEmpleados();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("=== LISTA DE PAGOS ===");
            foreach (var emp in empleados)
            {
                Console.WriteLine($"Nombre: {emp.GetPrimerNombre()} {emp.GetApellidoPaterno()}");
                Console.WriteLine($"NSS: {emp.GetNumeroSeguroSocial()}");
                Console.WriteLine($"Pago semanal: {emp.Ingresos():N2}");
                Console.WriteLine("-------------------------");
            }
        }


    }
}
