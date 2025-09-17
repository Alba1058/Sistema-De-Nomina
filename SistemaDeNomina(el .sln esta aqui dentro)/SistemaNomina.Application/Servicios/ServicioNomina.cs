using System;
using System.Collections.Generic;
using SistemaNomina.Domain.Empleados;
using SistemaNomina.Domain.Interfaces;

namespace SistemaNomina.Application.Servicios
{
    public class ServicioNomina
    {
        private readonly IRepositorioEmpleado repositorio;

        public ServicioNomina(IRepositorioEmpleado repositorio)
        {
            this.repositorio = repositorio;
        }

        public void RegistrarEmpleado(Empleado empleado)
        {
            repositorio.AgregarEmpleado(empleado);
        }

        public bool EliminarEmpleado(string nss)
        {
            var emp = repositorio.BuscarPorNSS(nss);
            if (emp != null)
            {
                repositorio.EliminarEmpleado(nss);
                return true;
            }
            return false;
        }

        public Empleado BuscarEmpleado(string nss)
        {
            return repositorio.BuscarPorNSS(nss);
        }

        public decimal CalcularPagoEmpleado(string nss)
        {
            var emp = BuscarEmpleado(nss);
            return emp != null ? emp.Ingresos() : 0;
        }

        public string GenerarReporte()
        {
            string reporte = "----- REPORTE DE NÓMINA -----\n";
            foreach (var emp in repositorio.ListarEmpleados())
            {
                reporte += emp.ToString() + "\n";
                reporte += "Pago semanal: " + emp.Ingresos().ToString("C") + "\n\n";
            }
            return reporte;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return repositorio.ListarEmpleados();
        }

        public bool ActualizarEmpleado(Empleado empleadoActualizado)
        {
            var existente = repositorio.BuscarPorNSS(empleadoActualizado.GetNumeroSeguroSocial());
            if (existente != null)
            {
                repositorio.ActualizarEmpleado(empleadoActualizado);
                return true;
            }
            return false;
        }

    }
}