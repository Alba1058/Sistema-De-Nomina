using SistemaNomina.Domain.Empleados;
using System;

namespace SistemaNomina.Domain.Tipos_de_empleados
{
    public class EmpleadoPorComision : Empleado
    {
        private decimal ventasBrutas;
        private decimal tarifaComision;

        public EmpleadoPorComision(string primerNombre, string apellidoPaterno, string numeroSeguroSocial,
            decimal ventasBrutas, decimal tarifaComision)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            this.ventasBrutas = ventasBrutas < 0 ? 0 : ventasBrutas;
            this.tarifaComision = (tarifaComision >= 0 && tarifaComision <= 1) ? tarifaComision : 0;
        }

        public decimal GetVentasBrutas()
        {
            return ventasBrutas;
        }

        public void SetVentasBrutas(decimal value)
        {
            ventasBrutas = value < 0 ? 0 : value;
        }

        public decimal GetTarifaComision()
        {
            return tarifaComision;
        }

        public void SetTarifaComision(decimal value)
        {
          
            tarifaComision = (value >= 0 && value <= 1) ? value : 0;
        }

        public override decimal Ingresos()
        {
            return tarifaComision * ventasBrutas;
        }

        public override string ToString()
        {
            return "Empleado por comisión: " + base.ToString() +
                   "\nVentas brutas: " + ventasBrutas.ToString("N2") + "\n" +
                   $"Tarifa comisión: " + (tarifaComision * 100).ToString("F2") + "%";
        }
    }
}