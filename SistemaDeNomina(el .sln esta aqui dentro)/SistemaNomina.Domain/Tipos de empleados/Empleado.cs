namespace SistemaNomina.Domain.Empleados
{
    public abstract class Empleado
    {
        private string primerNombre;
        private string apellidoPaterno;
        private string numeroSeguroSocial;

        protected Empleado(string primerNombre, string apellidoPaterno, string numeroSeguroSocial)
        {
            this.primerNombre = primerNombre;
            this.apellidoPaterno = apellidoPaterno;
            this.numeroSeguroSocial = numeroSeguroSocial;
        }

        public string GetPrimerNombre()
        {
            return primerNombre;
        }

        public void SetPrimerNombre(string value)
        {
            this.primerNombre = value;
        }

        public string GetApellidoPaterno()
        {
            return apellidoPaterno;
        }

        public void SetApellidoPaterno(string value)
        {
            this.apellidoPaterno = value;
        }

        public string GetNumeroSeguroSocial()
        {
            return numeroSeguroSocial;
        }

        public void SetNumeroSeguroSocial(string value)
        {
            this.numeroSeguroSocial = value;
        }

        public abstract decimal Ingresos();

        public override string ToString()
        {
            return $"Nombre: {primerNombre}\n" +
                   $"Apellido: {apellidoPaterno}\n" +
                   $"NSS: {numeroSeguroSocial}";
        }
    }
}
