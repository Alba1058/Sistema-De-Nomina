using SistemaNomina.Application.Servicios;
using SistemaNomina.ConsolaApp.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNomina.Infrastructure.Repositorios;


namespace SistemaNomina.ConsolaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new RepositorioMemoria();

            var servicioNomina = new ServicioNomina(repositorio);

            var menu = new MenuPrincipal(servicioNomina);

            menu.MostrarMenu();
        }
    }
}
