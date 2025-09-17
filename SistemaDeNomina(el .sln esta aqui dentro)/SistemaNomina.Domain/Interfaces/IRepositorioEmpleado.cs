using System.Collections.Generic;
using SistemaNomina.Domain.Empleados;

namespace SistemaNomina.Domain.Interfaces
{
    public interface IRepositorioEmpleado
    {
        void AgregarEmpleado(Empleado empleado);
        void EliminarEmpleado(string numeroSeguroSocial);
        void ActualizarEmpleado(Empleado empleado);
        Empleado BuscarPorNSS(string numeroSeguroSocial);
        List<Empleado> ListarEmpleados();

    }
}
