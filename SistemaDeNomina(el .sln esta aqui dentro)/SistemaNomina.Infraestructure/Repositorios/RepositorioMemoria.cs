using System.Collections.Generic;
using SistemaNomina.Domain.Empleados;
using SistemaNomina.Domain.Interfaces;
using System.Linq;

namespace SistemaNomina.Infrastructure.Repositorios
{
    public class RepositorioMemoria : IRepositorioEmpleado
    {
        private readonly List<Empleado> empleados;

        public RepositorioMemoria()
        {
            empleados = new List<Empleado>();
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        public void EliminarEmpleado(string numeroSeguroSocial)
        {
            var empleado = BuscarPorNSS(numeroSeguroSocial);
            if (empleado != null)
            {
                empleados.Remove(empleado);
            }
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            var existente = BuscarPorNSS(empleado.GetNumeroSeguroSocial());
            if (existente != null)
            {
                empleados.Remove(existente);
                empleados.Add(empleado);
            }
        }

        public Empleado BuscarPorNSS(string numeroSeguroSocial)
        {
            return empleados.FirstOrDefault(e => e.GetNumeroSeguroSocial() == numeroSeguroSocial);
        }


        public List<Empleado> ListarEmpleados()
        {
            return empleados;
        }
    }
}