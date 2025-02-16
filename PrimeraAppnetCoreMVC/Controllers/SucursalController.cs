using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraAppnetCoreMVC.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            SucursalBL obj = new SucursalBL();
            obj.listarSucursal();
            return View();
        }


        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult SinMenu()
        {
            return View();
        }

        public List<SucursalCLS> listarSucursales()
        {
            SucursalBL obj = new SucursalBL();

            return obj.listarSucursal();
        }

        public string cadena()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");
            return cadenaDato;
        }


        public List<SucursalCLS> RecuperarSucursal(int id)
        {
            SucursalBL obj = new SucursalBL();
            List<SucursalCLS> lista = obj.recuperarSucursal(id);
            return lista;
        }

        public List<SucursalCLS> FiltrarSucursal(string nombre)
        {
            SucursalBL obj = new SucursalBL();
            List<SucursalCLS> lista = obj.filtrarSucursal(nombre);
            return lista;
        }


    }
}
