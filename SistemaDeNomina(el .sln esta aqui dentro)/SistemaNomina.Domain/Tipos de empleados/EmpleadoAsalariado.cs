using SistemaNomina.Domain.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Tipos_de_empleados
{
    public class EmpleadoAsalariado : Empleado
    {
        private decimal salarioSemanal;
        public EmpleadoAsalariado(string nombre, string apellido, string nss, decimal salario)
                 : base(nombre, apellido, nss)
        {
            this.SetSalarioSemanal(salario);
        }

        public decimal GetSalarioSemanal()
        {
            return salarioSemanal;
        }
        //esta es una validacion para que el salario no sea negativo
        public void SetSalarioSemanal(decimal value)
        {
            this.salarioSemanal = (value < 0) ? 0 : value;
        }

        public override decimal Ingresos()
        {
            return this.salarioSemanal;
        }


        public override string ToString()
        {
            return "Empleado asalariado:\n" +
                  base.ToString() + "\n" +
                  $"Salario semanal: {salarioSemanal:N2}";
        }
    }
}