using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Tipos_de_empleados
{
    public class EmpleadoAsalariadoPorComision : EmpleadoPorComision
    {
        private decimal salarioBase;

        public EmpleadoAsalariadoPorComision(string primerNombre, string apellidoPaterno, string numeroSeguroSocial,
            decimal ventasBrutas, decimal tarifaComision, decimal salarioBase)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial, ventasBrutas, tarifaComision)
        {
            SetSalarioBase(salarioBase);
        }

        public decimal GetSalarioBase()
        {
            return salarioBase;
        }

        public void SetSalarioBase(decimal value)
        {
            if (value < 0)
            {
                salarioBase = 0;
            }
            else
            {
                salarioBase = value;
            }
        }

        public override decimal Ingresos()
        {
            return GetSalarioBase() + base.Ingresos();
        }

        public override string ToString()
        {
            return "Empleado asalariado por comisión: \n" +
                    base.ToString() + "\n" +
                   $"Salario base: " + salarioBase.ToString("N2");
        }
    }
}