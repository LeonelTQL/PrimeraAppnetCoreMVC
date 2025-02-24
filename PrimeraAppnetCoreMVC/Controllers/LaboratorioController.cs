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


        public List<listarLaboratorioCLS> filtrarLaboratorio(listarLaboratorioCLS objLaboratorio)

        {
            LaboratorioBL obj = new LaboratorioBL();
            return obj.filtrarLaboratorio(objLaboratorio);
        }

        public int GuardarLaboratorio(listarLaboratorioCLS obj)
        {
            LaboratorioBL oSucursal = new LaboratorioBL();
            return oSucursal.guardarLaboratorio(obj);
        }

    }
}
