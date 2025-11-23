using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;

namespace TallerMvcNet.Controllers
{
    public class TipsController : Controller
    {
        // GET: Muestra la calculadora vacía o con valores iniciales
        public IActionResult Index()
        {
            // Iniciamos con valores por defecto para que no se vea feo
            var model = new TipModel
            {
                BillAmount = 0,
                TipPercentage = 10
            };
            return View(model);
        }

        // POST: Recibe los datos del formulario y calcula
        [HttpPost]
        public IActionResult Calculate(TipModel model)
        {
            // Lógica del cálculo
            model.TipAmount = model.BillAmount * (model.TipPercentage / 100);
            model.TotalAmount = model.BillAmount + model.TipAmount;

            // Devolvemos la misma vista pero con los resultados llenos
            return View("Index", model);
        }
    }
}