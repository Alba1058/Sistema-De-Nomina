using SistemaNomina.Domain.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNomina.Domain.Tipos_de_empleados
{
  
    public class EmpleadoPorHoras : Empleado
    {
        private decimal sueldoPorHora;
        private decimal horasTrabajadas;  

        public EmpleadoPorHoras(string nombre, string apellido, string nss,
            decimal sueldoPorHora, decimal horasTrabajadas)
            : base(nombre, apellido, nss)
        {
            this.sueldoPorHora = sueldoPorHora;
            this.horasTrabajadas = horasTrabajadas;
        }

        public decimal GetSueldoPorHora()
        {
            return sueldoPorHora;
        }

        public void SetSueldoPorHora(decimal value)
        {
            if (value < 0)
            {
                sueldoPorHora = 0;
            }
            else
            {
                sueldoPorHora = value;
            }
        }

        public decimal GetHorasTrabajadas()
        {
            return horasTrabajadas;
        }

        public void SetHorasTrabajadas(decimal value)
        {
            if (value < 0 || value > 168) 
            {
                horasTrabajadas = 0;
            }
            else
            {
                horasTrabajadas = value;
            }
        }

        public override decimal Ingresos()
        {
            if (horasTrabajadas <= 40)
            {
                return sueldoPorHora * horasTrabajadas;
            }
            else
            {
                return (40 * sueldoPorHora) + ((horasTrabajadas - 40) * sueldoPorHora * 1.5M);
            }
        }

        public override string ToString()
        {
            return "Empleado por horas: " +
                   "Sueldo por hora: " + sueldoPorHora.ToString("N2") + "\n" +
                   "Horas trabajadas: " + horasTrabajadas.ToString("F2");
        }
    }
}