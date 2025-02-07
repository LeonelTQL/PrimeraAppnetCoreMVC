using Microsoft.AspNetCore.Mvc;

namespace PrimeraAppnetCoreMVC.Controllers
{
    public class MedicamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
