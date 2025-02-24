using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraAppnetCoreMVC.Controllers
{
    public class MedicamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<MedicamentoCLS> listarMedicamento()
        {
            MedicamentoBL obj = new MedicamentoBL();

            return obj.listarMedicamento();
        }

        public List<MedicamentoCLS> FiltrarMedicamento(MedicamentoCLS objMedicamento)
        {

            MedicamentoBL obj = new MedicamentoBL();
            List<MedicamentoCLS> lista = obj.filtrarMedicamento(objMedicamento);
            return lista;
        }

        public int GuardarMedicamento(MedicamentoCLS obj)
        {
            MedicamentoBL oMedicamento = new MedicamentoBL();
            return oMedicamento.guardarMedicamento(obj);
        }

        public int EliminarMedicamento(int id)
        {
            MedicamentoBL obj = new MedicamentoBL();
            return obj.eliminarMedicamento(id);
        }
    }
}
