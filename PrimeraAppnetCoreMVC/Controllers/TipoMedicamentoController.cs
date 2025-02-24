using CapaNegocio;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using CapaDatos;

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


        public void eliminarMed(int id)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            obj.EliminarMedicamento(id);
        }

        public List<TipoMedicamentoCLS> FiltrarTipoMedicamento(TipoMedicamentoCLS objTipoMedicamento)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            List<TipoMedicamentoCLS> lista = obj.filtrarTipoMedicamento(objTipoMedicamento);
            return lista;
        }

        public int guardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
           TipoMedicamentoBL obj = new TipoMedicamentoBL();
           return obj.guardarTipoMedicamento(oTipoMedicamentoCLS);
        }
    }   
}
