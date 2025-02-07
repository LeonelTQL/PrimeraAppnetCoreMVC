using CapaNegocio;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraAppnetCoreMVC.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        public IActionResult Index()
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            obj.listarMedicamento();
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

        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();

            return obj.listarMedicamento();
        }

        public string cadena()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");
            return cadenaDato;
        }
    }
}
