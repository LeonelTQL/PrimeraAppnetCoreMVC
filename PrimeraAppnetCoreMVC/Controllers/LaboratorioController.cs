using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using static CapaEntidad.LaboratorioCLS;

namespace PrimeraAppnetCoreMVC.Controllers
{
    public class LaboratorioController : Controller
    {
        public IActionResult Index()
        {
            LaboratorioBL obj = new LaboratorioBL();
            obj.listarLaboratorio();
            return View();
        }

        public List<listarLaboratorioCLS> listarLaboratorio()
        {
            LaboratorioBL obj = new LaboratorioBL();

            return obj.listarLaboratorio();
        }

        public string cadena()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");
            return cadenaDato;
        }

        public List<FiltrarLaboratorioCLS> filtrarLabotatorio(int idLaboratorio, string nombre, string direccion, string personacontacto)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.FiltrarLaboratorio(idLaboratorio, nombre, direccion, personacontacto);
        }


    }
}
